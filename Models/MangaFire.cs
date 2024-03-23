namespace NoPopsUI.Models
{
    public class MangaFire
    {
        public static string MangaFireBaseUrl => @"https://mangafire.to/";
        public static string FacebookDomain => @"https://www.facebook.com/sharer.php?t=MangaFire%20-%20Read%20Manga%20Online%20Free&u=https%3A%2F%2Fmangafire.to";
        public static string XDomain => @"https://twitter.com/intent/tweet?text=MangaFire%20-%20Read%20Manga%20Online%20Free&url=https%3A%2F%2Fmangafire.to";
        public static string MessengerDomain => @"fb-messenger://share/?link=https%3A%2F%2Fmangafire.to&app_id=291494419107518";
        public static string RedditDomain => @"https://reddit.com/submit?title=MangaFire%20-%20Read%20Manga%20Online%20Free&url=https%3A%2F%2Fmangafire.to";
        public static Uri? SanitizedUrl { get; set; }
    }
}
