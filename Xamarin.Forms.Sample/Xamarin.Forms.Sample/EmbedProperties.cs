namespace Xamarin.Forms.Sample
{
    public class EmbedProperties
    {
        public static string RootUrl = "http://localhost:12345/bi";//Dashboard Server BI URL
        public static string SiteIdentifier = "site/site1";//For Bold BI Enterprise edition, it should be like site1. For Bold BI Cloud, it should be empty string.
        public static string Environment = "onpremise";// Your Bold BI application environment. (If Cloud, you should use cloud, if  Enterprise, you should use onpremise)
        public static string EmbedType = "component";
        public static string UserEmail = ""; //Enter your BoldBI credentials here.
        public static string EmbedSecret = "";// Get the embedSecret key from Bold BI.
        public static string DashboardId = ""; // Dashboard Id which you want to render.
    }
}
