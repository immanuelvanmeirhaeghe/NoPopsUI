using NoPopsUI.Models;
using NoPopsUI.Views;

namespace NoPopsUI
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
        }

        protected override async void OnNavigating(ShellNavigatingEventArgs args)
        {
            base.OnNavigating(args);

            ShellNavigatingDeferral token = args.GetDeferral();

            if (token != null) 
            {
                var navTarget = args.Target.Location.OriginalString;
                if ((navTarget != null)
                    && (Navigation.ModalStack.Count == 0)
                    && (navTarget.EndsWith(aniwaveTab.Route, StringComparison.CurrentCultureIgnoreCase)
                    || navTarget.EndsWith(mangafireTab.Route, StringComparison.CurrentCultureIgnoreCase)))
                {                    
                    if (navTarget.EndsWith(aniwaveTab.Route, StringComparison.CurrentCultureIgnoreCase))
                    {                       
                        await Navigation.PushModalAsync(new AniwavePage());
                    }
                    else if (navTarget.EndsWith(mangafireTab.Route, StringComparison.CurrentCultureIgnoreCase))
                    {
                        await Navigation.PushModalAsync(new MangaFirePage());
                    }
                }
               
                token.Complete();
            }
        }
    }
}
