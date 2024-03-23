namespace NoPopsUI.Models
{
    public class AniWave
    {
        public static string AniWaveBaseUrl => @"https://aniwave.to/";        
        public static string XDomain => @"https://twitter.com/9animeOfficial";
        public static string DiscordDomain => @"https://discord.com/invite/KRQQKzQ6CS";
        public static string RedditDomain => @"https://www.reddit.com/r/9anime/";
        public static Uri? SanitizedUrl { get; set; }
    }
}
