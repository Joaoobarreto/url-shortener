using MediatR;
using url_shortener.Application.UseCases.CreateShortUrl;

namespace url_shortener.Requests;

public record CreateShortUrlRequest(string OriginalUrl, string ShortenerUrl)
{
    public IRequest<string> GetCommand() => new CreateShortUrlCommand(OriginalUrl, ShortenerUrl.Trim().Replace(" ", "-"));
}
