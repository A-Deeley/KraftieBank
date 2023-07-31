using MySql.Data.MySqlClient;
using MySqlHelper.ModelHelper;
using MySqlHelper.QueryHelper;
using KraftieWebApi.Exceptions;
using KraftieWebApi.ViewModels;

namespace KraftieWebApi.Repositories;

public class Repository<T> : IRepository<T>
    where T : Model, new()
{
    protected string _connectionString;

    public Repository(IConfiguration config)
    {
        string? connectionString = config.GetConnectionString("mysql");

        if (connectionString is null)
            throw new ArgumentException(nameof(config), "Configuration file does not contain a valid connection string for the database. Specify a connection string value using the key \"mysql\".");

        _connectionString = connectionString;
    }

    public void Delete(T entity)
    {
        throw new NotImplementedException();
    }

    public T Get(int id)
    {
        using MySqlConnectionInstance instance = MySqlQueryBuilder
            .CreateBuilder(_connectionString)
            .Select<T>()
            .From<T>()
            .Where("id=@id")
            .AddParameter("@id", id)
            .Build();

        T? result = instance.ReadFirst<T>();

        return (result is null) ?
            throw new ModelNotFoundException<T>(id) :
            result;
    }

    public IEnumerable<T> Get()
    {
        using MySqlConnectionInstance instance = MySqlQueryBuilder
            .CreateBuilder(_connectionString)
            .Select<T>()
            .From<T>()
            .Build();

        using MySqlDataReader reader = instance.OpenReader();

        return reader.GetRows<T>();
    }

    public IEnumerable<TOther> GetManyToMany<TOther>(T entity)
        where TOther : class, IMySqlObject, new()
    {
        using MySqlConnectionInstance instance = MySqlQueryBuilder
            .CreateBuilder(_connectionString)
            .Select<TOther>()
            .From<TOther>()
            .InnerJoin<T, TOther>()
            .Where<T, TOther>(entity)
            .Build();

        using MySqlDataReader reader = instance.OpenReader();

        return reader.GetRows<TOther>();
    }

    public void Insert(T entity)
    {
        using MySqlConnectionInstance instance = MySqlQueryBuilder
            .CreateBuilder(_connectionString)
            .InsertInto<T>()
            .Value(entity)
            .Build();

        int newId = -1;
        try
        {
            newId = instance.Insert();
        }
        catch(Exception e)
        {
            throw new ModelNotInsertedException(typeof(T), e);
        }

        if (newId == -1)
            throw new ModelNotInsertedException(typeof(T));

        entity.Id = newId;
    }

    public void Update(T entity)
    {
        throw new NotImplementedException();
    }
}
