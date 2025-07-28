using MediatR;
using SCI.Domain._SharedKernel.Abstractions;
using url_shortener.Domain.Entities;

namespace url_shortener.Projection.Queries;
public class GetOriginalUrlQueryHandler(IRepository<Link> linkRepository) : IRequestHandler<GetOriginalUrlQuery, string>
{
    public Task<string> Handle(GetOriginalUrlQuery request, CancellationToken cancellationToken)
    {
        return linkRepository.GetByShortUrlOrThrow(request.shortenerUrl);
    }
}
