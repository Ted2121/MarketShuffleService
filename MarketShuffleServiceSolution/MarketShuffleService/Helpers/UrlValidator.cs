namespace MarketShuffleService.Helpers;

public static class UrlValidator
{
    public static bool ValidateHttps(string url)
    {
        return Uri.TryCreate(url, UriKind.Absolute, out Uri? validatedUri)
               && validatedUri.Scheme == Uri.UriSchemeHttps;
    }
}
