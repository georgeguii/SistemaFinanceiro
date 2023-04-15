using Domain.Interfaces.Generics;
using Entities.Entitites;

namespace Domain.Interfaces.IUserFinancialSystem;

public interface InterfaceUserFinancialSystem : InterfaceGeneric<UserFinancialSystem>
{
    Task<IList<UserFinancialSystem>> ListSistemUsers(int idSystem);

    Task RemoveUsers(List<UserFinancialSystem> users);

    Task<UserFinancialSystem> GetUserByEmail(string userEmail);
}
