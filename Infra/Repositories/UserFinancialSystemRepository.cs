using Infra.Context;
using Entities.Entitites;
using Infra.Repositories.Generics;
using Domain.Interfaces.IUserFinancialSystem;

namespace Infra.Repositories;

public class UserFinancialSystemRepository : RepositoryGenerics<UserFinancialSystem>, InterfaceUserFinancialSystem
{
    public UserFinancialSystemRepository(ContextBase context) : base(context)
    {
    }

    public Task<UserFinancialSystem> GetUserByEmail(string userEmail)
    {
        throw new NotImplementedException();
    }

    public Task<IList<UserFinancialSystem>> ListSistemUsers(int idSystem)
    {
        throw new NotImplementedException();
    }

    public Task RemoveUsers(List<UserFinancialSystem> users)
    {
        throw new NotImplementedException();
    }
}
