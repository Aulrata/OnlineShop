namespace OnlineShop.Domain.Abstractions;

public interface IRepository<T>
{
    Task Create(T entity);

    Task<List<T>> Get();

    Task<T> Update(T entity);

    Task Delete(T entity);
}