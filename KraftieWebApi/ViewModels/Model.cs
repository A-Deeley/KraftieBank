using MySqlHelper.ModelHelper;

namespace KraftieWebApi.ViewModels;

public abstract class Model : IMySqlObject
{
    [ColumnData("id")]
    public int Id { get; set; }
}
