public class CommercialBuilding2
{
    // Shared policy and counters (class-level)
    public static int TotalCommercialCertificatesIssued { get; private set; }

    // Instance state (object-level)
    public string Name { get; }
    public int Floors { get; }
    public string Address { get; }

    public CommercialBuilding2(string name, int floors, string address)
    {
        Name = name;
        Floors = floors;
        Address = address;

        if (MeetsOccupancyRules(this))
        {
            TotalCommercialCertificatesIssued++;
        }
    }

    // Static method: policy check independent of instance identity
    public static bool MeetsOccupancyRules(CommercialBuilding2 building)
    {
        // Example policy: buildings with 3+ floors must meet additional criteria
        return building.Floors >= 3;
    }
}
