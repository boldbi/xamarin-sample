using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace Xamarin.Forms.Sample
{
    public interface IBaseUrl { string Get(); }

    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            EmbedWebView.Source = new HtmlWebViewSource
            {
                Html = GetHtmlString(),
                BaseUrl = DependencyService.Get<IBaseUrl>().Get()
            };
        }

        public string GetHtmlString()
        {
            var token = GetEmbedDetails();
            var html = @"<!DOCTYPE html>
                  <!DOCTYPE html>
                  <html style=""height:100%;width:100%"">
                      <head>
                          <meta name=""viewport"" content=""width=device-width, initial-scale=1"">
                          <script type=""text/javascript"" src=""https://cdnjs.cloudflare.com/ajax/libs/jquery/3.6.0/jquery.min.js""></script>
                          <script type=""text/javascript"" src=""https://cdn.boldbi.com/embedded-sdk/latest/boldbi-embed.js""></script>
                          <script type=""text/javascript"">
                            $(document).ready(function() {
                                this.dashboard = BoldBI.create({
                                    serverUrl:""" + EmbedProperties.RootUrl + "/" + EmbedProperties.SiteIdentifier + "\","
                                    + "dashboardId: \"" + EmbedProperties.DashboardId + "\","
                                    + "embedContainerId: \"dashboard\","
                                    + "width: \"100%\","
                                    + "height: \"100%\","
                                    + "embedToken: " + token
                                + @"}
                            });
                            console.log(this.dashboard);
                            this.dashboard.loadDashboard();
                        });
                          </script>
                      </head>
                      <body style=""background-color: white;height:100%;width:100%"">
                          <div id =""viewer-section"" style=""background-color: white;height:100%;width:100%"">
                              <div id =""dashboard"">
                              </div>
                          </div>
                      </body>
                  </html>";
            return html;
        }

        public string GetEmbedDetails()
        {
            var siteId = string.IsNullOrEmpty(EmbedProperties.SiteIdentifier) ? "" : EmbedProperties.SiteIdentifier;

            // Prepare embed generation payload
            var embedDetails = new
            {
                email = EmbedProperties.UserEmail,
                serverurl = EmbedProperties.RootUrl,
                siteidentifier = siteId,
                embedsecret = EmbedProperties.EmbedSecret,
                dashboard = new { id = EmbedProperties.DashboardId }
            };

            string accessToken = null;

            using (var client = new HttpClient())
            {
                // POST to BoldBI embed authorize endpoint to get access token
                var requestUrl = EmbedProperties.RootUrl.TrimEnd('/') + "/api/" + siteId + "/embed/authorize";
                var jsonPayload = JsonConvert.SerializeObject(embedDetails);
                var httpContent = new StringContent(jsonPayload, Encoding.UTF8, "application/json");

                var result = client.PostAsync(requestUrl, httpContent).Result;
                var resultContent = result.Content.ReadAsStringAsync().Result;

                // Try to extract access token from response
                try
                {
                    dynamic tokenResp = JsonConvert.DeserializeObject<dynamic>(resultContent);
                    if (tokenResp != null)
                    {
                        if (tokenResp.Data != null && tokenResp.Data.access_token != null)
                            accessToken = (string)tokenResp.Data.access_token;
                        else if (tokenResp.access_token != null)
                            accessToken = (string)tokenResp.access_token;
                        else if (tokenResp.data != null && tokenResp.data.access_token != null)
                            accessToken = (string)tokenResp.data.access_token;
                    }
                }
                catch { /* ignore parse errors */ }

                if (string.IsNullOrEmpty(accessToken))
                {
                    // Fallback: use raw response if token extraction failed
                    accessToken = resultContent;
                }

                return accessToken;
            }
        }
    }
}
