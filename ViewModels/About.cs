namespace NoPopsUI.Models
{
    public class About
    {
        public string? AppTitle { get; set; }
        public string? AppVersion { get; set; }
        public string AppDescription =>
            $"This app is intended to let you browse Aniwave and MangaFire on your mobile or portable device without popups and not using any 3rd party browser add-ons. Currently, you can enjoy watching series on Aniwave or reading them on MangaFire.";
        public string GitHubScheme =>
            @"git://immanuelvanmeirhaeghe/NoPopsUI";
        public string GitHubProjectUrl =>
            @"https://github.com/immanuelvanmeirhaeghe/NoPopsUI";
    }
}
