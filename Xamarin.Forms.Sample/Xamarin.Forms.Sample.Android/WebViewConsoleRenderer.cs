using Android.Content;
using Android.Util;
using Android.Webkit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(WebView), typeof(Xamarin.Forms.Sample.Droid.WebViewConsoleRenderer))]
namespace Xamarin.Forms.Sample.Droid
{
    public class WebViewConsoleRenderer : WebViewRenderer
    {
        public WebViewConsoleRenderer(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<WebView> e)
        {
            base.OnElementChanged(e);
            if (Control != null)
            {
                Control.Settings.JavaScriptEnabled = true;
                Control.Settings.AllowFileAccess = true;
                Control.Settings.AllowContentAccess = true;
                // Allow local file to access remote resources (file:// -> https://)
                Control.Settings.AllowUniversalAccessFromFileURLs = true;
                Control.Settings.AllowFileAccessFromFileURLs = true;

                Control.SetWebChromeClient(new LoggingWebChromeClient());
            }
        }

        class LoggingWebChromeClient : WebChromeClient
        {
            public override bool OnConsoleMessage(ConsoleMessage consoleMessage)
            {
                try
                {
                    var msg = $"[WebView Console] {consoleMessage.Message()} -- {consoleMessage.SourceId()}:{consoleMessage.LineNumber()}";
                    Log.Debug("WebViewConsole", msg);
                }
                catch (System.Exception ex)
                {
                    Log.Error("WebViewConsole", ex.ToString());
                }
                return base.OnConsoleMessage(consoleMessage);
            }
        }
    }
}
