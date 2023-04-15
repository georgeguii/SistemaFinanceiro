using Entities.Entitites;
using Domain.Interfaces.Generics;

namespace Domain.Interfaces.IExpense;

public interface InterfaceExpense : InterfaceGeneric<Expense>
{
    Task<IList<Expense>> ListUserExpenses(string userEmail);

    Task<IList<Expense>> ListUnpaidUserExpenses(string userEmail);
}
