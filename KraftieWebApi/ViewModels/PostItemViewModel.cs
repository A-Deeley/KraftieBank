using MySqlHelper.ModelHelper;
using System.Data;

namespace KraftieWebApi.ViewModels
{
    public class PostItemViewModel
    {
        public int Id { get; set; }
        public int Count { get; set; }

        public string Name { get; set; }

        public Quality Quality { get; set; }
        public string CharacterName { get; set; }
        public string CharacterServer { get; set; }

    }
}
