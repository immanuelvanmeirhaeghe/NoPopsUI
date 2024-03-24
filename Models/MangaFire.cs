namespace NoPopsUI.Models
{
    public class MangaFire
    {
        public static string BaseUrl { get; set; } = @"https://mangafire.to";
        public static Uri? SanitizedUrl { get; set; } = default;
        public static string DisqusBaseUrl => @"https://disqus.com";
        public static string ShareOnFacebookUrl => @"https://www.facebook.com/sharer.php?t=MangaFire%20-%20Read%20Manga%20Online%20Free&u=https%3A%2F%2Fmangafire.to";
        public static string ShareOnTwitterUrl => @"https://twitter.com/intent/tweet?text=MangaFire%20-%20Read%20Manga%20Online%20Free&url=https%3A%2F%2Fmangafire.to";
        public static string ShareOnFacebookMessengerUrl => @"fb-messenger://share/?link=https%3A%2F%2Fmangafire.to&app_id=291494419107518";
        public static string ShareOnRedditUrl => @"https://reddit.com/submit?title=MangaFire%20-%20Read%20Manga%20Online%20Free&url=https%3A%2F%2Fmangafire.to";
        public static string JoinUsOnRedditUrl => @"https://www.reddit.com/r/Mangafire";
        public static string DiscordInviteUrl => @"https://discord.com/invite/KRQQKzQ6CS";
    }
}
