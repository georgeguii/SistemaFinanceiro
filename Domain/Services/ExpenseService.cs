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

    public async Task<object> LoadGraphics(string userEmail)
    {
        IList<Expense> userExpenses = await _interfaceExpense.ListUserExpenses(userEmail);
        IList<Expense> previousExpenses = await _interfaceExpense.ListUnpaidUserExpenses(userEmail);

        decimal previousMounthUnpaidExpenses = previousExpenses.Any() ? 
                                                previousExpenses.ToList().Sum(x => x.Value) :
                                                0;

        decimal paidExpenses = userExpenses
                                .Where(d => d.Paid && d.ExpenseType == Entities.Enums.ExpenseType.Contas)
                                .Sum(x => x.Value);

        decimal pendentsExpenses = userExpenses
                                .Where(d => !d.Paid && d.ExpenseType == Entities.Enums.ExpenseType.Contas)
                                .Sum(x => x.Value);

        decimal investments = userExpenses
                                .Where(d => d.ExpenseType == Entities.Enums.ExpenseType.Investimento).Sum(x => x.Value);

        return new
        {
            sucess = "Ok",
            paidExpenses = paidExpenses,
            pendentsExpenses = pendentsExpenses,
            previousMounthUnpaidExpenses = previousMounthUnpaidExpenses,
            investments = investments
        };
    }
}
