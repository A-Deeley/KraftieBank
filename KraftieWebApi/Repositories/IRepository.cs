using MySqlHelper.ModelHelper;
using KraftieWebApi.ViewModels;
namespace KraftieWebApi.Repositories;

public interface IRepository<T>
    where T : Model
{
    public IEnumerable<T> Get();

    public IEnumerable<TOther> GetManyToMany<TOther>(T entity)
        where TOther : class, IMySqlObject, new();

    public T Get(int id);

    public void Insert(T entity);

    public void Update(T entity);

    public void Delete(T entity);
}
