public static class PermitCalculator2
{
    public static decimal CalculatePermitCost(int floors, bool downtown)
    {
        decimal baseFee = 500m;
        return baseFee + (floors * 75m * (downtown ? 1.25m : 1.0m));
    }
}
