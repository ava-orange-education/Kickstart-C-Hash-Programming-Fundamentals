public class ZoningAuthority2
{
    // Static read-only field: shared constant
    public static readonly string Jurisdiction = "City of Northside";

    // Static property with controlled access
    private static int _maximumFloors = 60;
    public static int MaximumFloors
    {
        get => _maximumFloors;
        set
        {
            if (value < 1) throw new ArgumentOutOfRangeException(nameof(value));
            _maximumFloors = value;
        }
    }

    // Static utility method
    public static bool IsCompliant(int floors) => floors <= _maximumFloors;
}
