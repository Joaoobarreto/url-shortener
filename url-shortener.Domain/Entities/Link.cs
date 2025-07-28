namespace url_shortener.Domain.Entities;
public class Link
{
    public int Id { get; set; }
    public string OriginalUrl { get; set; } = string.Empty;
    public string ShortenedUrl { get; set; } = string.Empty;

    protected Link () { }
    private Link(string originalUrl, string shortenerUrl)
    {
        OriginalUrl = originalUrl;
        ShortenedUrl = shortenerUrl;
    }

    public static Link Criar(string originalUrl, string shortenerUrl)
    {
        return new Link(originalUrl, shortenerUrl);
    }
}
