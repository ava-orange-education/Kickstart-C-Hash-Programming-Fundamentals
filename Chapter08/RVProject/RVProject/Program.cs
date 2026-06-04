using RVProject;

class Program
{
    static void Main(string[] args)
    {
        // Use the new constructor
        RV myRV = new RV("2Y7C45678M2025RV", "Gasoline")
        {
            VIN = "2Y7C45678M2025RV",
            EngineType = "Gasoline"
        };
        myRV.Mileage = 8000;

        myRV.StartEngine();
        Console.WriteLine($"VIN: {myRV.VIN}, Engine: {myRV.EngineType}, Mileage: {myRV.Mileage}");

        myRV.PrintDetails();

        ServiceManager manager = new();
        myRV.ScheduleService(manager);

        // Declare and instantiate a ClassA RV
        ClassA luxuryRV = new ClassA
        {
            VIN = "3ZXC45678RV2025",
            EngineType = "Diesel",
            HasLuxuryPackage = true,
            Mileage = 12000
        };

        RV travelRV = new()
        {
            VIN = "5RV9087XGT",
            EngineType = "Gasoline",
            Mileage = 6700
        };

        travelRV.PrintDetails();

        _ = new ServiceManager();

        manager.AddServiceRequest(new RV
        {
            VIN = "8NEWXRV112",
            EngineType = "Diesel",
            Mileage = 4000
        });

        RV configuredRV = new()
        {
            VIN = "9CFG889RV",
            EngineType = "Diesel",
            Mileage = 14500
        };


        // Use the ClassA specific method
        luxuryRV.DisplayLuxuryDetails();

        // Schedule service for the ClassA RV
        luxuryRV.ScheduleService(manager);

        // Print details of the ClassA RV
        luxuryRV.PrintDetails();

        // Demonstrate the use of the ServiceManager
        manager.AddServiceRequest(luxuryRV);


        ClassA demoRV = new ClassA
        {
            VIN = "DEMO999CLASSA",
            EngineType = "Diesel",
            HasLuxuryPackage = false,
            Mileage = 3000
        };

        // Access and print each property
        Console.WriteLine($"VIN: {demoRV.VIN}");
        Console.WriteLine($"Engine Type: {demoRV.EngineType}");
        Console.WriteLine($"Mileage: {demoRV.Mileage}");
        Console.WriteLine($"Luxury Package: {demoRV.HasLuxuryPackage}");

        demoRV.Mileage += 500;
        Console.WriteLine($"Updated Mileage: {demoRV.Mileage}");

    }


    /*            
                     // Set and retrieve mileage using the property
                     luxuryRV.Mileage = 13190.5;
                     Console.WriteLine($"Current mileage: {luxuryRV.Mileage}");

                     luxuryRV.StartEngine();
                     Console.WriteLine($"Luxury package included: {luxuryRV.HasLuxuryPackage}");

                     luxuryRV.Drive(250.7);
                     luxuryRV.Drive(-10); // test invalid input

                     luxuryRV.DisplayLuxuryDetails();

                 }  */
              

              

}
