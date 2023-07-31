namespace KraftieWebApi.Exceptions;

public class ModelNotInsertedException : Exception
{
    public ModelNotInsertedException(Type type)
        : base($"Failed to insert entity of type {type}.")
    { }

    public ModelNotInsertedException(Type type, Exception? innerException)
        : base($"An exception has caused the insertion of entity of type {type} to fail. See inner exception for details.", innerException)
    { }
}
