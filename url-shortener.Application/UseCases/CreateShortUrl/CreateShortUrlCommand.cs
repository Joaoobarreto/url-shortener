using MediatR;

namespace url_shortener.Application.UseCases.CreateShortUrl;
public record CreateShortUrlCommand(string OriginalUrl) : IRequest<string> { }
