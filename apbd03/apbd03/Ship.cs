using apbd03.Containers;
using apbd03.Exceptions;

namespace apbd03;

public class Ship
{
    public List<Container> Containers { get; } = new List<Container>();
    public double MaxSpeed { get; }
    public int MaxContainers { get; }
    public double MaxWeight { get; }
    
    public Ship(double maxWeight, double maxSpeed, int maxContainers)
    {
        MaxWeight = maxWeight;
        MaxSpeed = maxSpeed;
        MaxContainers = maxContainers;
    }

    public void LoadContainer(Container container, double weight)
    {
        container.Load(weight);
    }

    public void LoadShip(Container container)
    {
        double totalWeight = Containers.Sum(c => c.CargoWeight) + Containers.Sum(c => c.ContainerWeight) + container.CargoWeight + container.ContainerWeight;

        if (Containers.Count + 1 > MaxContainers)
            throw new InvalidOperationException("Cannot load container, ship has reached maximum capacity.");

        if (totalWeight > MaxWeight)
            throw new OverfillException("Cannot load container, ship has reached maximum weight capacity.");

        Containers.Add(container);
    }

    public void LoadShip(List<Container> containers)
    {
        double totalWeight = Containers.Sum(c => c.CargoWeight) + Containers.Sum(c=> c.ContainerWeight) + containers.Sum(c => c.CargoWeight) + containers.Sum(c => c.ContainerWeight);

        if (Containers.Count + containers.Count > MaxContainers)
            throw new InvalidOperationException("Cannot load containers, ship has reached maximum capacity.");

        if (totalWeight > MaxWeight)
            throw new OverfillException("Cannot load containers, ship has reached maximum weight capacity.");

        Containers.AddRange(containers);
    }

    public void RemoveContainer(Container container)
    {
        Containers.Remove(container);
    }

    public void UnloadContainer(Container container)
    {
        container.Unload();
    }

    public void ReplaceContainer(Container c1, Container c2)
    {
        if (!Containers.Contains(c1))
            throw new ArgumentException("Container not found on the ship.");

        int index = Containers.IndexOf(c1);
        Containers[index] = c2;
    }

    public void TransferContainer(Container container, Ship targetShip)
    {
        if (!Containers.Contains(container))
            throw new ArgumentException("Container not found on the ship.");

        targetShip.LoadContainer(container, container.CargoWeight);
        Containers.Remove(container);   
    }

    public void PrintContainerInfo(Container container)
    {
        Console.WriteLine($"Container Serial Number: {container.SerialNumber}");
        Console.WriteLine($"Cargo Weight: {container.CargoWeight} kg");
    }

    public void PrintShipInfo()
    {
        Console.WriteLine($"Ship Max Speed: {MaxSpeed}");
        Console.WriteLine($"Ship Max Weight: {MaxWeight}");
        Console.WriteLine($"Ship Max Containers: {MaxContainers}");
        Console.WriteLine($"Number of Containers on the Ship: {Containers.Count}");
        Console.WriteLine("Containers on the Ship:");
        if (Containers.Count == 0)
        {
            Console.WriteLine("There are no containers on the ship.");
        }
        else
        {
            foreach (var container in Containers)
            {
                Console.WriteLine($"- Container Serial Number: {container.SerialNumber}, Cargo Weight: {container.CargoWeight} kg");
            }
        }
    }
}