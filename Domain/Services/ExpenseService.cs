using Domain.Interfaces.IExpense;
using Domain.Interfaces.IServices;
using Entities.Entitites;

namespace Domain.Services;

public class ExpenseService : IExpenseService
{
    private readonly InterfaceExpense _interfaceExpense;

    public ExpenseService(InterfaceExpense interfaceExpense)
    {
        _interfaceExpense = interfaceExpense;
    }

    public async Task AddExpense(Expense expense)
    {
        var date = DateTime.UtcNow;
        expense.SignUpDate = date;
        expense.Year = date.Year;
        expense.Mouth = date.Month;

        var isValid = expense.ValidateStringProperty(expense.Name, "Name");

        if (isValid)
            await _interfaceExpense.Add(expense);
    }

    public async Task UpdateExpense(Expense expense)
    {
        var date = DateTime.UtcNow;
        expense.UpdateDate = date;

        if (expense.Paid)
        {
            expense.PaymentDate = date;
        }

        var isValid = expense.ValidateStringProperty(expense.Name, "Name");

        if (isValid)
            await _interfaceExpense.Update(expense);
    }
}
