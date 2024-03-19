namespace apbd03.Containers;

public class LiquidContainer : Container
{
    public LiquidContainer(double cargoWeight, double height) : base(cargoWeight, height)
    {
    }

    public virtual void Load(double cargoWeight)
    {
        base.Load(cargoWeight);
    }
}