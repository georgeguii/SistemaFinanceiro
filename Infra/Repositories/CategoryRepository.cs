using Entities.Entitites;
using Domain.Interfaces.ICategory;
using Infra.Context;
using Infra.Repositories.Generics;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositories;

public class CategoryRepository : RepositoryGenerics<Category>, InterfaceCategory
{
    public CategoryRepository(ContextBase context) : base(context)
    {
    }

    protected override DbSet<Category> _dbSet => _context.Set<Category>();

    public async Task<IList<Category>> ListUserCategories(string userEmail) =>
        await _dbSet
        .Include(c => c.FinancialSystem)
        .Where(x => x.FinancialSystem.UserFinancialSystem.UserEmail.Equals(userEmail) && x.FinancialSystem.UserFinancialSystem.CurrentSystem)
        .AsNoTracking()
        .ToListAsync();
}
