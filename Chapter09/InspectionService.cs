public static class InspectionService
{
    public static bool RequiresElevator(Building2 building2)
        => building2.Floors >= 4;
}
