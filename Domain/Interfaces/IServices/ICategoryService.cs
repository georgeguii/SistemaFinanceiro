using Entities.Entitites;

namespace Domain.Interfaces.IServices;

public interface ICategoryService
{
    Task AddCategory(Category category);
    Task UpdateCategory(Category category);
}