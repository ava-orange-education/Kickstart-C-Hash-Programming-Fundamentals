using System;

public class ServiceManager
{
    public void AddServiceRequest(RV rv)
    {
        Console.WriteLine($"Service scheduled for RV with VIN: {rv.VIN}");
    }
}
