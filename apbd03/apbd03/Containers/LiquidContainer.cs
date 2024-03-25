using apbd03.Exceptions;
using apbd03.Interfaces;

namespace apbd03.Containers;

public class LiquidContainer : Container, IHazardNotifier
{
    public bool IsDangerousCargo { get; }

    public LiquidContainer(double cargoWeight, double containerWeight, double height, double depth, double maxCapacity, bool isDangerous) 
        : base(cargoWeight, containerWeight, height, depth, maxCapacity)
    {
        IsDangerousCargo = isDangerous;
    }

    protected override string GetTypeCode()
    {
        return "L";
    }

    public override void Load(double cargoWeight)
    {
        if (CargoWeight > 0)
        {
            Console.WriteLine("Container is already loaded. Cannot load cargo again.");
            return;
        }
        
        if (cargoWeight > MaxCapacity)
        {
            throw new OverfillException("Cargo weight exceeds maximum capacity.");
        }

        if (IsDangerousCargo)
        {
            if (cargoWeight > (MaxCapacity * 0.5))
            {
                NotifyDangerousSituation(SerialNumber);
            }
        }
        else
        {
            if (cargoWeight > (MaxCapacity * 0.9))
            {
                NotifyDangerousSituation(SerialNumber);
            }
        }

        CargoWeight = cargoWeight;
    }

    public void NotifyDangerousSituation(string containerNumber)
    {
        Console.WriteLine($"Dangerous operation detected in liquid container {containerNumber}");

    }
}