using KraftieWebApi.ViewModels;

namespace KraftieWebApi.Exceptions;

public class ModelNotFoundException<T> : Exception
    where T : Model
{
    public ModelNotFoundException()
        : base($"{typeof(T)} does not exist.")
    { }

    public ModelNotFoundException(int id)
        : base($"{typeof(T)} with id {id} does not exist.")
    { }
}
