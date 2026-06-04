public class Building
{
    public string Name;
    public int Floors;
    public string Address;

    // Master constructor with all parameters
    public Building(string name, int floors, string address)
    {
        Name = name;
        Floors = floors;
        Address = address;
    }

    // Constructor with name and floors only
    public Building(string name, int floors) 
        : this(name, floors, "Not specified")
    {
    }

    // Default constructor
    public Building() 
        : this("Unnamed Building", 1, "Not specified")
    {
    }
}
