namespace SCI.Domain._SharedKernel.Abstractions;
public interface IRepository<T>
{
    Task AddAsync(T entity);
}