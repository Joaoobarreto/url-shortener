using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace url_shortener.Domain.Entities;
public class Link
{
    public int Id { get; set; }
    public string OriginalUrl { get; set; } = string.Empty;
    public string ShortenedUrl { get; set; } = string.Empty;

    private Link(string originalUrl, string shortenerUrl)
    {
        OriginalUrl = originalUrl;
        ShortenedUrl = shortenerUrl;
    }

    public static Link CriarLink(string originalUrl, string shortenerUrl)
    {
        return new Link(originalUrl, shortenerUrl);
    }
}
