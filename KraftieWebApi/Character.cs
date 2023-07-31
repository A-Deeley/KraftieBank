namespace KraftieWebApi;

public class Character
{
    public string Name { get; set; }
    public string Server { get; set; }

    public Character(string name, string server)
    {
        Name = name;
        Server = server;
    }

    public Character()
    {

    }
}
