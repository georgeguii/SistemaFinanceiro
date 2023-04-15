using Entities.Entitites;

using Domain.Interfaces.Generics;

namespace Domain.Interfaces.ICategory;

public interface InterfaceCategory : InterfaceGeneric<Category>
{
    Task<IList<Category>> ListUserCategories(string userEmail);
}
