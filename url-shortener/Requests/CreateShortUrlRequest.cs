using MediatR;
using url_shortener.Application.UseCases.CreateShortUrl;

namespace url_shortener.Requests;

public record CreateShortUrlRequest(string OriginalUrl)
{
    public IRequest<string> GetCommand() => new CreateShortUrlCommand(OriginalUrl);
}
