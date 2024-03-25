using apbd03;
using apbd03.Containers;

/*var container = new Container(10.0, 15.0)
{
    CargoWeight = 12,
    Height = 12.0
};*/
// container.CargoWeight = 10.0;

int? a = 1;
a = null;

Exception? ex = new Exception();
ex = null;

// ArrayList
List<int> numbers = new List<int>() {1, 2, 3};
List<int> numbers2 = new() {1, 3, 4};
var numbers3 = new List<int>() {4, 5, 6};

// HashMap
Dictionary<PossibleProducts, double> products = new();

Ship ship = new Ship(1000, 80, 5);
ship.PrintShipInfo();
Container c1 = new LiquidContainer(40,10,40,4,200,false);
ship.LoadShip(c1);
ship.LoadShip(c1);
ship.LoadContainer(c1, 34.5);
Container c2 = new LiquidContainer(200, 50, 100, 50, 500, true);
Container c3 = new GasContainer(100, 20, 10, 10, 300, 150);
Container c4 = new RefrigeratedContainer(500, 100, 200, 100, 600, PossibleProducts.Meat);
ship.LoadShip(c2);
ship.LoadShip(c3);
var containersToLoad = new List<Container>() { c3, c4 };
ship.LoadShip(containersToLoad);
// ship.LoadShip(c4);
ship.PrintShipInfo();
ship.RemoveContainer(c2);
ship.PrintShipInfo();
ship.UnloadContainer(c2);
ship.UnloadContainer(c3);
ship.PrintShipInfo();
Ship ship2 = new Ship(700, 50, 2);
ship2.LoadShip(c4);
ship2.PrintShipInfo();
ship2.ReplaceContainer(c4, c3);
ship2.PrintShipInfo();
ship.TransferContainer(c1, ship2);
ship2.PrintShipInfo();
ship.PrintShipInfo();