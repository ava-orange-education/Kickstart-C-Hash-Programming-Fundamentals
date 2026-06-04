public class PermitCalculator
{
    public static decimal CalculatePermitCost(int floors, bool downtown)
    {
        if (floors < 1) throw new ArgumentOutOfRangeException(nameof(floors));
        decimal baseFee = BuildingCode.PermitFeeBase;
        decimal multiplier = downtown ? 1.25m : 1.00m;
        return baseFee + (floors * 75m * multiplier);
    }
}
