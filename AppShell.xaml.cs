using NoPopsUI.Maui.Interfaces;
using NoPopsUI.Maui.Services;
using DefaultBrowser = Microsoft.Maui.ApplicationModel.Browser;

namespace NoPopsUI;

public partial class AppShell : Shell
{
    public Uri? CurrentLocation { get; set; }
    public Uri? TargetLocation { get; set; }
    public IWebsite? CurrentBaseWebsite { get; set; }
    public IWebsite? CurrentTargetWebsite { get; set; }

    public AppShell()
    {
        InitializeComponent();
    }

    /// <summary>
    /// Overrides <seealso cref="DefaultBrowser.Default"/> browser navigation.
    /// </summary>
    /// <param name="sender">The default Browser</param>
    /// <param name="e"></param>
    public async void CustomBrowser_OnNavigating(object? sender, ShellNavigatingEventArgs e)
    {
        try
        {
            ShellNavigatingDeferral token = e.GetDeferral();
            if (PreferenceManager.UserOptions != null && PreferenceManager.UserOptions.UseDefaultBrowser
                && sender != null && e != null
                && e.Current != null && e.Current.Location != null
                && e.Target != null && e.Target.Location != null)
            {
                CurrentLocation = e.Current.Location;
                TargetLocation = e.Target.Location;
                if (CurrentLocation != null && TargetLocation != null)
                {
                    CurrentBaseWebsite ??= IWebsite.Create(CurrentLocation);
                    CurrentTargetWebsite = IWebsite.Create(TargetLocation);
                    if (CurrentBaseWebsite != null && CurrentTargetWebsite != null
                        && CurrentTargetWebsite.BasePath.ToLowerInvariant().Trim().StartsWith(CurrentBaseWebsite.BasePath.ToLowerInvariant().Trim()))
                    {
                        token.Complete();
                    }
                    else
                    {
                        e.Cancel();
                    }
                }
                else
                {
                    e.Cancel();
                }
            }
            else
            {
                base.OnNavigating(e);
            }
        }
        catch (Exception exc)
        {
            await ExceptionManager.DisplayErrorAlert(exc.Message, exc, sender ?? new(), e);
            e.Cancel();
        }
    }

    /// <summary>
    /// Overrides default shell navigation.
    /// </summary>
    /// <param name="e">Default <see cref="ShellNavigatingEventArgs"/></param>
    protected override async void OnNavigating(ShellNavigatingEventArgs e)
    {
        try
        {
            ShellNavigatingDeferral token = e.GetDeferral();
            if (e.Current != null && e.Current.Location != null && e.Target != null && e.Target.Location != null)
            {
                CurrentLocation = e.Current.Location;
                TargetLocation = e.Target.Location;
                if (CurrentLocation != null && TargetLocation != null)
                {
                    var cachedRoute = RoutingManager.GetCachedRoute(TargetLocation.OriginalString);
                    if (cachedRoute != null)
                    {
                        //Shell navigation
                        token.Complete();
                    }
                    else
                    {
                        //Browser navigation
                        CustomBrowser_OnNavigating(DefaultBrowser.Default, e);
                    }
                }
                else
                {
                    e.Cancel();
                }
            }
            else
            {
                base.OnNavigating(e);
            }
        }
        catch (Exception exc)
        {
            await ExceptionManager.DisplayErrorAlert(exc.Message, exc, e);
            e.Cancel();
        }
    }
}
