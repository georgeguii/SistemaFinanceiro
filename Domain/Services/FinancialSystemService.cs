using Domain.Interfaces.IExpense;
using Domain.Interfaces.IFinancialSystem;
using Domain.Interfaces.IServices;
using Entities.Entitites;

namespace Domain.Services;

public class FinancialSystemService : IFinancialSystemService
{
    private readonly InterfaceFinancialSystem _interfaceFinancialSystem;

    public FinancialSystemService(InterfaceFinancialSystem interfaceFinancialSystem)
    {
        _interfaceFinancialSystem = interfaceFinancialSystem;
    }

    public async Task AddFinancialSystem(FinancialSystem financialSystem)
    {
        var isValid = financialSystem.ValidateStringProperty(financialSystem.Name, "Name");

        if (isValid)
        {
            var date = DateTime.Now;

            financialSystem.ClosingDate = 1;
            financialSystem.Year = date.Year;
            financialSystem.Mouth = date.Month;
            financialSystem.CopyYear = date.Year;
            financialSystem.CopyMouth = date.Month;
            financialSystem.GenerateExpenseCopy = true;

            await _interfaceFinancialSystem.Add(financialSystem);
        }
    }

    public async Task UpdateFinancialSystem(FinancialSystem financialSystem)
    {
        var isValid = financialSystem.ValidateStringProperty(financialSystem.Name, "Name");

        if (isValid)
        {
            financialSystem.ClosingDate = 1;
            await _interfaceFinancialSystem.Add(financialSystem);
        }
    }
}
