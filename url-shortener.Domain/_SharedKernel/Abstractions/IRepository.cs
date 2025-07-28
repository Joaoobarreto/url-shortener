namespace SCI.Domain._SharedKernel.Abstractions;
public interface IRepository<T>
{
    Task AddAsync(T entity);
    Task<string> GetByShortUrlOrThrow(string shortUrl);
    Task<string> GetByOriginalUrl(string originalUrl);
}