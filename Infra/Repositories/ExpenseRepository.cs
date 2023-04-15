using Infra.Context;
using Entities.Entitites;
using Domain.Interfaces.IExpense;
using Infra.Repositories.Generics;

namespace Infra.Repositories;
public class ExpenseRepository : RepositoryGenerics<Expense>, InterfaceExpense
{
    public ExpenseRepository(ContextBase context) : base(context)
    {
    }

    public Task<IList<Expense>> ListUnpaidUserExpenses(string userEmail)
    {
        throw new NotImplementedException();
    }

    public Task<IList<Expense>> ListUserExpenses(string userEmail)
    {
        throw new NotImplementedException();
    }
}
