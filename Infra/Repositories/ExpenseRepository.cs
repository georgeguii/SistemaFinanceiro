using Infra.Context;
using Entities.Entitites;
using Domain.Interfaces.IExpense;
using Infra.Repositories.Generics;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositories;
public class ExpenseRepository : RepositoryGenerics<Expense>, InterfaceExpense
{
    public ExpenseRepository(ContextBase context) : base(context)
    {
    }

    protected override DbSet<Expense> _dbSet => _context.Set<Expense>();

    public async Task<IList<Expense>> ListUnpaidUserExpenses(string userEmail) =>
        await _dbSet
        .Include(e => e.Category)
        .ThenInclude(c => c.FinancialSystem)
        .Where(e => e.Category.FinancialSystem.UserFinancialSystem.UserEmail.Equals(userEmail) &&
                    e.Category.FinancialSystem.Mouth == e.Mouth &&
                    e.Category.FinancialSystem.Year == e.Year)
        .AsNoTracking()
        .ToListAsync();

    public async Task<IList<Expense>> ListUserExpenses(string userEmail) =>
        await _dbSet
        .Include(e => e.Category)
        .ThenInclude(c => c.FinancialSystem)
        .Where(e => e.Category.FinancialSystem.UserFinancialSystem.UserEmail.Equals(userEmail) &&
                    e.Mouth < DateTime.Now.Month &&
                    !e.Paid)
        .AsNoTracking()
        .ToListAsync();
}
