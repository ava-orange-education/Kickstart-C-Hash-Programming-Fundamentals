public class BuildingCode
{
    public const string Jurisdiction = "City of Northside"; // compile-time constant
    public static readonly decimal PermitFeeBase;            // runtime-initialized

    static BuildingCode()
    {
        // Example: load from configuration or calculation
        PermitFeeBase = 500.00m;
    }
}
