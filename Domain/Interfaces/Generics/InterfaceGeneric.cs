namespace Domain.Interfaces.Generics;

public interface InterfaceGeneric<T> where T : class
{
    Task<IList<T>> GetAll();

    Task<T> GetById(int id);

    Task Add(T obj);

    Task Update(T obj);

    Task Remove(T obj);
}
