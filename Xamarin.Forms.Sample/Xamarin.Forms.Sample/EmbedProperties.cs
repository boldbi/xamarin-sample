namespace Xamarin.Forms.Sample
{
    public static class EmbedProperties
    {
        // No default fallbacks here — values come exclusively from the loaded config.
        // Each property returns the configured value or null if the config wasn't loaded.
        public static string RootUrl => ConfigStore.Current?.RootUrl;
        public static string SiteIdentifier => ConfigStore.Current?.SiteIdentifier;
        public static string Environment => ConfigStore.Current?.Environment;
        public static string EmbedType => ConfigStore.Current?.EmbedType;
        public static string UserEmail => ConfigStore.Current?.UserEmail;
        public static string EmbedSecret => ConfigStore.Current?.EmbedSecret;
        public static string DashboardId => ConfigStore.Current?.DashboardId;
    }
}