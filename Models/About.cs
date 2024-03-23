using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoPopsUI.Models
{
    public class About
    {
        public static string Title => AppInfo.Name;
        public static string Version => AppInfo.VersionString;
        public static string GitHubProjectUrl => "https://aka.ms/maui";
        public static string Message => @"This app is intended to browse any website on your Android or iOS phone," +
                                        " without popups and not using any 3rd party browser add-ons.";
    }
}
