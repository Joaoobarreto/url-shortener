using Microsoft.EntityFrameworkCore;
using SCI.Domain._SharedKernel.Abstractions;
using url_shortener.Domain.Entities;

namespace url_shortener.Data.Contexts.Default.Repositories;
public class LinkRepository(DefaultDbContext dbContext) : IRepository<Link>
{
    public async Task AddAsync(Link entity) => await dbContext.Links.AddAsync(entity);

    public async Task<string> GetByOriginalUrl(string originalUrl)
    {
        var link = await dbContext.Links
            .FirstOrDefaultAsync(l => l.OriginalUrl == originalUrl);

        return link is not null ? link.OriginalUrl : null;
    }

    public async Task<string> GetByShortUrlOrThrow(string shortUrl)
    {
        var link = await dbContext.Links
            .FirstOrDefaultAsync(l => l.ShortenedUrl == shortUrl);

        if (link is null)
        {
            throw new KeyNotFoundException($"Link with short URL '{shortUrl}' not found.");
        }
        return link.OriginalUrl;
    }
}
