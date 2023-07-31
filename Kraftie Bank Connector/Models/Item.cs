using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kraftie_Bank_Connector.Models;

internal class Item
{
    public int Id { get; set; }
    public int Count { get; set; }

    public string Name { get; set; }

    public Quality Quality { get; set; }
    public string CharacterName { get; set; }
    public string CharacterServer { get; set; }

    public Item(object id, object count, object quality, object itemLink, Character character)
    {
        Id = Convert.ToInt32(id);
        Count = Convert.ToInt32(count);
        CharacterName = character.Name;
        CharacterServer = character.Server;
        int qualityInt = Convert.ToInt32(quality);
        Quality = (Quality)qualityInt;

        string[] itemLinkSplit = ((string)itemLink).Split("|h");
        Name = itemLinkSplit[1];
    }
}
