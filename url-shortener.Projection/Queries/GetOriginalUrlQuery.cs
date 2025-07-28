using MediatR;

namespace url_shortener.Projection.Queries;
public record GetOriginalUrlQuery(string shortenerUrl) : IRequest<string> { }
