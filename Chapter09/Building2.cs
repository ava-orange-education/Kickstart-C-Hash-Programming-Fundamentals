public class Building2
{
    // Shared across all buildings
    public static int TotalPermitsIssued = 0;

    // Instance data
    public string Name { get; }
    public int Floors { get; }

    public Building2(string name, int floors)
    {
        Name = name;
        Floors = floors;
        TotalPermitsIssued++; // increments the shared counter
    }
}
