using Domain.Interfaces.Generics;
using Entities.Entitites;

namespace Domain.Interfaces.IFinancialSystem;

public interface InterfaceFinancialSystem : InterfaceGeneric<FinancialSystem>
{
    Task<IList<FinancialSystem>> ListUserSystems (string userEmail);
}
