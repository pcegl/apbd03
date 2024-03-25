using apbd03.Exceptions;
using apbd03.Interfaces;

namespace apbd03.Containers;

public abstract class Container : IContainer
{
    private static int _nextSerialNumber = 1;
    public double CargoWeight { get; set; }
    public double ContainerWeight { get; set; } 
    public double Height { get; set; }
    public double Depth { get; set; }
    public string SerialNumber { get; }
    public double MaxCapacity { get; }
    public Container(double cargoWeight, double containerWeight, double height, double depth, double maxCapacity)
    {
        CargoWeight = cargoWeight;
        ContainerWeight = containerWeight;
        Height = height;
        Depth = depth;
        SerialNumber = GenerateSerialNumber();
        MaxCapacity = maxCapacity;
    }
    
    private string GenerateSerialNumber()
    {
        string typeCode = GetTypeCode();
        return $"KON-{typeCode}-{_nextSerialNumber++}";
    }

    protected abstract string GetTypeCode();

    public virtual void Unload()
    {
        CargoWeight = 0;
    }
  
    public virtual void Load(double cargoWeight)
    {
        if (cargoWeight > MaxCapacity)
        {
            throw new OverfillException("Cargo weight exceeds maximum capacity.");
        }

        CargoWeight += cargoWeight;
    }
}