using Infra.Context;
using Entities.Entitites;
using Infra.Repositories.Generics;
using Domain.Interfaces.IUserFinancialSystem;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositories;

public class UserFinancialSystemRepository : RepositoryGenerics<UserFinancialSystem>, InterfaceUserFinancialSystem
{
    public UserFinancialSystemRepository(ContextBase context) : base(context)
    {
    }

    protected override DbSet<UserFinancialSystem> _dbSet => _context.Set<UserFinancialSystem>();

    public async Task<UserFinancialSystem> GetUserByEmail(string userEmail) =>
        await _dbSet.AsNoTracking().FirstOrDefaultAsync(uf => uf.UserEmail.Equals(userEmail));

    public async Task<IList<UserFinancialSystem>> ListSistemUsers(int idSystem) =>
        await _dbSet.Where(uf => uf.FinancialSystem.Id == idSystem).AsNoTracking().ToListAsync();

    public async Task RemoveUsers(List<UserFinancialSystem> users)
    {
        _dbSet.RemoveRange(users);
        await _context.SaveChangesAsync();
    }
}
