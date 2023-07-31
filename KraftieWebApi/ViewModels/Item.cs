using MySqlHelper.ModelHelper;
using System.Data;

namespace KraftieWebApi.ViewModels
{
    [TableData("item")]
    public class Item : Model
    {
        [ColumnData("count")]
        public int Count { get; set; }

        [ColumnData("name")]
        public string Name { get; set; }

        [ColumnData("quality", DbType = typeof(int))]
        public Quality Quality { get; set; }

        [ColumnData("character_name")]
        public string Character { get; set; }

        public Item()
        {
            
        }

        public Item(PostItemViewModel vm)
        {
            Id = vm.Id;
            Name = vm.Name;
            Quality = vm.Quality;
            Count = vm.Count;
            Character = $"{vm.CharacterName}-{vm.CharacterServer}";
        }
    }
}
