using Domain.Interfaces.ICategory;
using Entities.Entitites;

using Infra.Context;
using Infra.Repositories.Generics;

namespace Infra.Repositories;

public class CategoryRepository : RepositoryGenerics<Category>, InterfaceCategory
{
    public CategoryRepository(ContextBase context) : base(context)
    {
    }

    public Task<IList<Category>> ListUserCategories(string userEmail)
    {
        throw new NotImplementedException();
    }
}
