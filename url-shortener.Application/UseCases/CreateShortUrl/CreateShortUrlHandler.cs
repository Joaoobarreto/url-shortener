using MediatR;
using SCI.Domain._SharedKernel.Abstractions;
using url_shortener.Data.Contexts.Default;
using url_shortener.Domain._SharedKernel;
using url_shortener.Domain.Entities;

namespace url_shortener.Application.UseCases.CreateShortUrl;
public sealed class CreateShortUrlHandler(
    IUnitOfWork<DefaultDbContext> unitOfWork,
    IRepository<Link> linkRepository
    ) : IRequestHandler<CreateShortUrlCommand, string>
{
    public async Task<string> Handle(CreateShortUrlCommand request, CancellationToken cancellationToken)
    {
        var link = Link.Criar(request.OriginalUrl);

        await linkRepository.AddAsync(link);

        await unitOfWork.SaveChangesAsync();

        return link.ShortenedUrl;
    }
}
