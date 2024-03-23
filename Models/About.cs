namespace NoPopsUI.Models
{
    public class About
    {
        public static string Title => AppInfo.Name;
        public static string Version => AppInfo.VersionString;
        public static string GitHubProjectUrl => @"https://github.com/immanuelvanmeirhaeghe/NoPopsUI";
        public static string Message => @"This app is intended to browse any website on your mobile or portable device without popups and not using any 3rd party browser add-ons.";        
    }
}
