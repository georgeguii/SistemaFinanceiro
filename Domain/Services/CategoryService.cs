using Domain.Interfaces.ICategory;
using Domain.Interfaces.IServices;
using Entities.Entitites;

namespace Domain.Services;

public class CategoryService : ICategoryService
{
    private readonly InterfaceCategory _interfaceCategory;

    public CategoryService(InterfaceCategory interfaceCategory)
    {
        _interfaceCategory = interfaceCategory;
    }

    public async Task AddCategory(Category category)
    {
        var isValid = category.ValidateStringProperty(category.Name, "Name");
        if (isValid)
            await _interfaceCategory.Add(category);
    }

    public async Task UpdateCategory(Category category)
    {
        var isValid = category.ValidateStringProperty(category.Name, "Name");
        if (isValid)
            await _interfaceCategory.Update(category);
    }
}
