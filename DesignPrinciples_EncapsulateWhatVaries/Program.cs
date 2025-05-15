using Test_ProblemSolving;

Pizaa pizaa1 = Pizaa.Order(PizzaConstants.CHEESEPIZZA);
Console.WriteLine(pizaa1);

Pizaa pizaa2 = Pizaa.Order(PizzaConstants.VEGETERIANPIZZA);
Console.WriteLine(pizaa2);

Pizaa pizaa3 = Pizaa.Order(PizzaConstants.CHICKENPIZZA);
Console.WriteLine(pizaa3);

class Pizaa
{
    public virtual string Title => nameof(Pizaa);
    public virtual decimal Price => 10m;
    private static void Prepare()
    {
        Console.WriteLine("Preparing ...");
        Thread.Sleep(500);
        Console.WriteLine("Completed");
    }

    private static void Cook()
    {
        Console.WriteLine("Cooking ...");
        Thread.Sleep(500);
        Console.WriteLine("Completed");
    }

    private static void Cut()
    {
        Console.WriteLine("Cuting & Boxing ...");
        Thread.Sleep(500);
        Console.WriteLine("Completed");
    }

    public override string ToString()
    {
        return $"\n{Title}" +
               $"\n\tPrice: {Price.ToString() + "$\n"}"; 
    }

    private static Pizaa Create(string Pizzatype)
    {
        Pizaa pizaa = new Pizaa();

        if (Pizzatype.Equals("Cheese"))
        {
            pizaa = new Cheese();
        }
        else if (Pizzatype.Equals("Chicken"))
        {
            pizaa = new Chicken();
        }
        else if (Pizzatype.Equals("Vegeterian"))
        {
            pizaa = new Vegeterian();
        }

        return pizaa;
    }

    public static Pizaa Order(string Pizzatype)
    {
        Pizaa pizaa = Create(Pizzatype);
        Prepare();
        Cook();
        Cut();

        return pizaa;
    }
}

class Cheese :Pizaa
{
    public override string Title => base.Title + " " + nameof(Cheese);
    public override decimal Price => base.Price + 3m;
}

class Chicken : Pizaa
{
    public override string Title => base.Title + " "+ nameof(Chicken);
    public override decimal Price => base.Price + 8m;
}

class Vegeterian : Pizaa
{
    public override string Title => base.Title + " " + nameof(Vegeterian);
    public override decimal Price => base.Price + 5m;
}