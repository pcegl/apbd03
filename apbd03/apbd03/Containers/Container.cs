using apbd03.Exceptions;
using apbd03.Interfaces;

namespace apbd03.Containers;

public abstract class Container : IContainer
{
    public double CargoWeight { get; set; }
    public double Height { get; set; }

    public Container(double cargoWeight, double height)
    {
        CargoWeight = cargoWeight;
        Height = height;
    }

    public void Unload()
    {
        throw new NotImplementedException();
    }

    public virtual void Load(double cargoWeight)
    {
        CargoWeight = cargoWeight;
        throw new OverfillException();
    }
}