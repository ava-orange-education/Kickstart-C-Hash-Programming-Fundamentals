public class ZoningAuthority
{
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
}
