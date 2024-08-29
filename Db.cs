namespace PizzaStore.Db;

public record Pizza
{
    public int Id { get; set; }
    public string? Name { get; set; }
}

public class PizzaDB
{

    public static int Delay { get; set; }
    public static bool Error { get; set; }

    private static List<Pizza> _pizzas = new List<Pizza>()
   {
     new Pizza{ Id=1, Name="Montemagno, Pizza shaped like a great mountain" },
     new Pizza{ Id=2, Name="The Galloway, Pizza shaped like a submarine, silent but deadly"},
     new Pizza{ Id=3, Name="The Noring, Pizza shaped like a Viking helmet, where's the mead"}
   };

    public static List<Pizza> GetPizzas()
    {
        if (Delay > 0)
        {
            Thread.Sleep(Delay);
        }
        if (Error)
        {
            throw new Exception("");
        }
        return _pizzas;
    }

    public static Pizza? GetPizza(int id)
    {
        if (Delay > 0)
        {
            Thread.Sleep(Delay);
        }
        if (Error)
        {
            throw new Exception("");
        }
        return _pizzas.SingleOrDefault(pizza => pizza.Id == id);
    }

    public static Pizza CreatePizza(Pizza pizza)
    {
        if (Delay > 0)
        {
            Thread.Sleep(Delay);
        }
        if (Error)
        {
            throw new Exception("");
        }
        _pizzas.Add(pizza);
        return pizza;
    }

    public static Pizza UpdatePizza(Pizza update)
    {
        if (Delay > 0)
        {
            Thread.Sleep(Delay);
        }
        if (Error)
        {
            throw new Exception("");
        }
        _pizzas = _pizzas.Select(pizza =>
        {
            if (pizza.Id == update.Id)
            {
                pizza.Name = update.Name;
            }
            return pizza;
        }).ToList();
        return update;
    }

    public static void RemovePizza(int id)
    {
        if (Delay > 0)
        {
            Thread.Sleep(Delay);
        }
        if (Error)
        {
            throw new Exception("");
        }
        _pizzas = _pizzas.FindAll(pizza => pizza.Id != id).ToList();
    }
}