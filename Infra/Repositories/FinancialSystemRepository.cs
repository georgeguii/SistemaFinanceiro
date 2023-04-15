using Infra.Context;
using Entities.Entitites;
using Infra.Repositories.Generics;
using Domain.Interfaces.IFinancialSystem;

namespace Infra.Repositories;

public class FinancialSystemRepository : RepositoryGenerics<FinancialSystem>, InterfaceFinancialSystem
{
    public FinancialSystemRepository(ContextBase context) : base(context)
    {
    }

    public Task<IList<FinancialSystem>> ListUserSystems(string userEmail)
    {
        throw new NotImplementedException();
    }
}
