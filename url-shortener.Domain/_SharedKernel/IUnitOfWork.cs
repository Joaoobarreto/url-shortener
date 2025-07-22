namespace url_shortener.Domain._SharedKernel;
public interface IUnitOfWork<in TContext>
{
    Task SaveChangesAsync();
}
