namespace NoPopsUI.Models
{
    public class Custom
    {
        public string BaseUrl { get; set; } = @$"{Uri.UriSchemeHttps}{Uri.SchemeDelimiter}";
        public string Placeholder =>
             @"Give the address";
        public string TargetUrl { get; set; } = @$"about:blank";
        public Uri? SanitizedUrl { get; set; } = default;
    }
}
