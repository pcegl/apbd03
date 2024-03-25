using apbd03.Interfaces;

namespace apbd03.Containers;

public class GasContainer : Container, IHazardNotifier
{
    public double Pressure { get; }

    public GasContainer(double cargoWeight, double containerWeight, double height, double depth, double maxCapacity, double pressure)
        : base(cargoWeight, containerWeight, height, depth, maxCapacity)
    {
        Pressure = pressure;
    }

    public override void Unload()
    {
        CargoWeight = MaxCapacity * 0.05;
    }
    protected override string GetTypeCode()
    {
        return "G";
    }

    public void NotifyDangerousSituation(string containerNumber)
    {
        Console.WriteLine($"Dangerous situation detected in gas container {containerNumber}");
    }
}