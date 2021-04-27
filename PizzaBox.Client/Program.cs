using System;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Models;
using PizzaBox.Client.Singletons;
using PizzaBox.Storing;
using PizzaBox.Domain.Models.Stores;
using PizzaBox.Domain.Models.Pizzas;
using System.Collections.Generic;

namespace PizzaBox.Client
{
  /// <summary>
  /// 
  /// </summary>
  public class Program
  {
    private static readonly PizzaSingleton _pizzaSingleton = PizzaSingleton.Instance;
    private static readonly StoreSingleton _storeSingleton = StoreSingleton.Instance;
    private static readonly OrderSingleton _orderSingleton = OrderSingleton.Instance;
    private static readonly CustomerSingleton _customerSingleton = CustomerSingleton.Instance;

    /// <summary>
    /// 
    /// </summary>
    private static void Main()
    {
      Run();
    }

    /// <summary>
    /// 
    /// </summary>
    private static void Run()
    {
      Console.WriteLine("Welcome to PizzaBox");

      var cus = GetCustomer();
      var PizzaCollection = new List<Order>();

      Boolean inUse = true;
      while (inUse)
      {
        Console.WriteLine("What do you want to do?");
        Console.WriteLine("\no-Order A Pizza\nc-Show Cart\np-Purchase All Pizzas\nv-View Past Orders\nq-Quit\n");
        var choice = Console.ReadLine();
        switch (choice.ToLower())
        {
          case "c":
            PrintCart(PizzaCollection);
            break;
          case "o":
            if (PizzaCollection.Count < 50)
            {
              PizzaCollection.Add(OrderPizza(cus));
              Console.WriteLine("Pizzas in Cart: " + PizzaCollection.Count);
            }
            else
            {
              Console.WriteLine("Too many pizzas!");
            }
            break;
          case "p":
            purchase(PizzaCollection);
            break;
          case "v":
            ViewOrders(cus);
            break;
          case "q":
            inUse = false;
            break;
          default:
            Console.WriteLine("Error: Unknown option");
            break;
        }
      }




    }

    private static void PrintCart(List<Order> pizzaCollection)
    {
      if (pizzaCollection.Count > 0)
      {
        int index = 0;
        foreach (var item in pizzaCollection)
        {
          Console.WriteLine($"{++index} - {item.Pizza}");
        }
      }
    }

    private static void purchase(List<Order> pizzaCollection)
    {
      if (pizzaCollection.Count > 0)
      {
        foreach (var item in pizzaCollection)
        {
          Console.WriteLine(item.Pizza);
          _orderSingleton.AddOrder(item);
        }
      }

    }

    private static void ViewOrders(Customer cus)
    {
      foreach (var item in _orderSingleton.ViewOrders(cus))
      {
        Console.WriteLine(item.Pizza);
      }

    }

    private static Customer GetCustomer()
    {
      var cus = new Customer();

      Console.WriteLine("Enter your customer ID or enter a name for a new account:");
      var choice = Console.ReadLine();
      if (int.TryParse(choice, out int ID))
      {
        cus = _customerSingleton.GetCustomerByID(ID);
        Console.WriteLine($"Welcome back {cus.Name}!");
      }
      else
      {
        cus.Name = choice;
        long Id = _customerSingleton.AddCustomer(cus);
        Console.WriteLine($"Hello {cus.Name}, your ID is {Id}");

      }

      return cus;
    }

    private static Order OrderPizza(Customer cus)
    {
      var order = new Order();

      PrintStoreList();

      order.Customer = cus;
      order.Store = SelectStore();
      order.Pizza = SelectPizza();

      order.Pizza.Size = getSize();
      order.Pizza.Crust = getCrust();

      PrintOrder(order);

      return order;
    }

    /// <summary>
    /// 
    /// </summary>
    private static void PrintOrder(Order order)
    {
      Console.WriteLine($"Your order is: {order.Pizza}");
    }

    /// <summary>
    /// 
    /// </summary>
    private static void PrintPizzaList()
    {
      var index = 0;

      foreach (var item in _pizzaSingleton.Pizzas)
      {
        Console.WriteLine($"{++index} - {item.ToppingList()}");
      }
    }

    /// <summary>
    /// 
    /// </summary>
    private static void PrintStoreList()
    {
      var index = 0;

      foreach (var item in _storeSingleton.Stores)
      {
        Console.WriteLine($"{++index} - {item}");
      }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    private static APizza SelectPizza()
    {
      PrintPizzaList();
      Console.WriteLine("Or press 99 for custom pizza");
      var valid = int.TryParse(Console.ReadLine(), out int input);

      if (!valid)
      {
        return null;
      }
      else if (input == 99)
      {
        return MakeCustomPizza();
      }

      var pizza = _pizzaSingleton.Pizzas[input - 1];

      return pizza;
    }

    private static CustomPizza MakeCustomPizza()
    {
      var cp = new CustomPizza();
      cp.Toppings = GetToppings();
      _pizzaSingleton.AddPizza(cp);
      return cp;
    }

    private static Size getSize()
    {
      Console.WriteLine("Enter size:\ns- Small\nm-medium\nl-large");
      var input = Console.ReadLine();
      var result = new Size();
      switch (input.ToLower())
      {
        case "s":
          result.Name = "Small";
          result.Price = 2.00m;
          break;
        case "m":
          result.Name = "Medium";
          result.Price = 4.00m;
          break;
        case "l":
          result.Name = "Large";
          result.Price = 6.00m;
          break;
        default:
          Console.WriteLine("Invalid Option, Try Again");
          result = getSize();
          break;
      }
      return result;
    }

    private static Crust getCrust()
    {
      Console.WriteLine("Enter size:\no- Original\nn-Neapolitan\ns-Stuffed");
      var input = Console.ReadLine();
      var result = new Crust();
      switch (input.ToLower())
      {
        case "o":
          result.Name = "Original";
          result.Price = 1.00m;
          break;
        case "n":
          result.Name = "Neapolitan";
          result.Price = 2.00m;
          break;
        case "s":
          result.Name = "Stuffed";
          result.Price = 3.00m;
          break;
        default:
          Console.WriteLine("Invalid Option, Try Again");
          result = getCrust();
          break;
      }
      return result;
    }

    private static List<Topping> GetToppings()
    {
      Boolean adding = true;
      var result = new List<Topping>();
      while (adding)
      {
        Console.WriteLine("Add Minimum 2 Maximum 5 Toppings:\n1-Mozzarella\n2-Marinara\n3-Pepperoni\nd-Done");
        var input = Console.ReadLine();
        Topping temp = new Topping();
        switch (input.ToLower())
        {
          case "1":
            temp.Name = "Mozzarella";
            temp.Price = 1.00m;
            result.Add(temp);
            break;
          case "2":
            temp.Name = "Marinara";
            temp.Price = 1.00m;
            result.Add(temp);
            break;
          case "3":
            temp.Name = "Pepperoni";
            temp.Price = 2.00m;
            result.Add(temp);
            break;
          case "d":
          case "D":
            if (result.Count > 2) { adding = false; }
            else { Console.WriteLine("Not enough Toppings!\n"); }
            break;
          default:
            Console.WriteLine("Invalid Option, Try Again");
            result = GetToppings();
            break;
        }
        if (result.Count > 4) { adding = false; }
      }
      return result;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    private static AStore SelectStore()
    {
      var valid = int.TryParse(Console.ReadLine(), out int input);

      if (!valid)
      {
        return null;
      }

      return _storeSingleton.Stores[input - 1];
    }
  }
}
