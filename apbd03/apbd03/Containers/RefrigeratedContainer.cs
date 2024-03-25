namespace apbd03.Containers;

public class RefrigeratedContainer : Container
{
    public PossibleProducts ProductType { get; }
    public double Temperature { get; }


    public RefrigeratedContainer(double cargoWeight, double containerWeight, double height, double depth, double maxCapacity, PossibleProducts productType) 
        : base(cargoWeight, containerWeight, height, depth, maxCapacity)
    {
        ProductType = productType;
        Temperature = GetTemperature(productType);
    }
    
    private readonly Dictionary<PossibleProducts, double> _temperatures = new Dictionary<PossibleProducts, double>
    {
        { PossibleProducts.Banana, 13.3 },
        { PossibleProducts.Chocolate, 18.0 },
        { PossibleProducts.Fish, 2.0 },
        { PossibleProducts.Meat, -15.0 },
        { PossibleProducts.IceCream, -18.0 },
        { PossibleProducts.Cheese, 7.2 },
        { PossibleProducts.FrozenPizza, -30.0 },
        { PossibleProducts.Sausages, 5.0 },
        { PossibleProducts.Butter, 20.5 },
        { PossibleProducts.Eggs, 19.0 }
    };

    private double GetTemperature(PossibleProducts product)
    {
        if (_temperatures.TryGetValue(product, out double temperature))
        {
            return temperature;
        }
        else
        {
            throw new ArgumentException("Temperature not defined for the specified product.");
        }
    }

    protected override string GetTypeCode()
    {
        return "C";
    }
}