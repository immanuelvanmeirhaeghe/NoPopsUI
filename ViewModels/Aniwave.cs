using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace NoPopsUI.Models
{
    public class Aniwave : ObservableObject
    {
        public static string BaseUrl { get; set; } = @"https://aniwave.to";
        public static Uri? SanitizedUrl { get; set; } = default;
        public static string FriendsMoviesBaseUrl => @"https://fmoviesz.to";
        public static string MangaFireBaseUrl => @"https://mangafire.to";
        public static string FriendsLiveBaseUrl => @"https://aniwave.live";
        public static string DisqusBaseUrl => @"https://disqus.com";
        public static string JoinOnTwitterUrl => @"https://twitter.com/9animeOfficial";
        public static string JoinOnDiscordInviteUrl => @"https://discord.com/invite/KRQQKzQ6CS";
        public static string JoinOnRedditUrl => @"https://www.reddit.com/r/9anime";

        public IRelayCommand GoBackCommand { get; private set; }

        public Aniwave()
        {
            GoBackCommand = new RelayCommand(
                execute: () =>
                {
                    Shell.Current.GoToAsync($"//main/home");
                    //Shell.SetTabBarIsVisible(Shell.Current, true);
                    //await Shell.Current.Navigation.PopToRootAsync();
                });
        }
    }
}
