using Domain.Interfaces.IServices;
using Domain.Interfaces.IUserFinancialSystem;

namespace Domain.Services;

public class UserFinancialSystem : IUserFinancialSystem
{
    private readonly InterfaceUserFinancialSystem _userFinancialSystem;

    public UserFinancialSystem(InterfaceUserFinancialSystem userFinancialSystem)
    {
        _userFinancialSystem = userFinancialSystem;        
    }

    public async Task AddUserFinancialSystem(Entities.Entitites.UserFinancialSystem userFinancialSystem) =>
        await _userFinancialSystem.Add(userFinancialSystem);

}
