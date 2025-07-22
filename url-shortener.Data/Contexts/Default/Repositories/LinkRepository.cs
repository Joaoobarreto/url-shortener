using SCI.Domain._SharedKernel.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using url_shortener.Domain.Entities;

namespace url_shortener.Data.Contexts.Default.Repositories;
public class LinkRepository(DefaultDbContext dbContext) : IRepository<Link>
{
    public async Task AddAsync(Link entity) => await dbContext.Links.AddAsync(entity);
    
}
