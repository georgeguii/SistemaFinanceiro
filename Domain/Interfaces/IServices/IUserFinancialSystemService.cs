using Entities.Entitites;

namespace Domain.Interfaces.IServices;

public interface IUserFinancialSystemService
{
    Task AddUserFinancialSystem(UserFinancialSystem userFinancialSystem);
}
