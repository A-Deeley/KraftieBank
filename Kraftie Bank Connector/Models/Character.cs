using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kraftie_Bank_Connector.Models;

public class Character
{
    public string Name { get; set; }
    public string Server { get; set; }

    public Character(string name, string server)
    {
        Name = name;
        Server = server;
    }
}
