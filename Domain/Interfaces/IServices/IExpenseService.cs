using Entities.Entitites;

namespace Domain.Interfaces.IServices;

public interface IExpenseService
{
    Task AddExpense(Expense expense);
    Task UpdateExpense(Expense expense);
}