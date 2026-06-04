public class PermitRegistry
{
    public static readonly List<string> IssuedPermits;

    static PermitRegistry()
    {
        Console.WriteLine("Loading existing permits from central database...");
        IssuedPermits = LoadPermitsFromDatabase();
    }

    private static List<string> LoadPermitsFromDatabase()
    {
        // Simulated database retrieval
        return new List<string> { "PERMIT-001", "PERMIT-002" };
    }

    public static void AddPermit(string permitNumber)
    {
        IssuedPermits.Add(permitNumber);
    }
}
