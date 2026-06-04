namespace RVProject
{
    public class ClassA : RV
    {
        public ClassA()
        {
        }

        public ClassA(string VIN, string EngineType) : base(VIN, EngineType)
        {
        }

        public bool HasLuxuryPackage { get; set; }

        // Add a method specific to ClassA
        public void DisplayLuxuryDetails()
        {
            if (HasLuxuryPackage)
                Console.WriteLine("This Class A RV includes a full luxury package!");
            else
                Console.WriteLine("This Class A RV is standard trim.");
        }
    }
}