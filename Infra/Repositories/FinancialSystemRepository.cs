using Infra.Context;
using Entities.Entitites;
using Infra.Repositories.Generics;
using Domain.Interfaces.IFinancialSystem;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositories;

public class FinancialSystemRepository : RepositoryGenerics<FinancialSystem>, InterfaceFinancialSystem
{
    public FinancialSystemRepository(ContextBase context) : base(context)
    {
    }

    protected override DbSet<FinancialSystem> _dbSet => _context.Set<FinancialSystem>();

    public async Task<IList<FinancialSystem>> ListUserSystems(string userEmail) =>
        await _dbSet
        .Where(fs => fs.UserFinancialSystem.UserEmail.Equals(userEmail))
        .AsNoTracking()
        .ToListAsync();
}
