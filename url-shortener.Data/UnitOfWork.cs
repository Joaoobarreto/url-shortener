
using Microsoft.EntityFrameworkCore;
using url_shortener.Domain._SharedKernel;

namespace url_shortener.Data;
public sealed class UnitOfWork<TContext>(
    TContext context
    ) : IUnitOfWork<TContext> where TContext : DbContext
{
    private readonly TContext _context = context;
    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}
