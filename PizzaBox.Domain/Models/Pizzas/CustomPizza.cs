using System.Collections.Generic;
using PizzaBox.Domain.Abstracts;

namespace PizzaBox.Domain.Models.Pizzas
{
  /// <summary>
  /// 
  /// </summary>
  public class CustomPizza : APizza
  {
    /// <summary>
    /// 
    /// </summary>
    public override void AddCrust(Crust crust = null)
    {
      Crust = crust ?? new Crust() { Name = "Original", Price = 2.00M };
    }

    /// <summary>
    /// 
    /// </summary>
    public override void AddSize(Size size = null)
    {
      Size = size ?? new Size() { Name = "Small", Price = 2.00M };
    }

    /// <summary>
    /// 
    /// </summary>
    public override void AddToppings(params Topping[] toppings)
    {
      var defaultToppings = new List<Topping>()
      {
        new Topping() { Name = "Mozzarella", Price = 1.00M  },
        new Topping() { Name = "Marinara", Price = 1.00M  }
      };
      if (toppings.Length == 0)
      {
        Toppings = defaultToppings;
      }
      else
      {
        Toppings = new List<Topping>();
        Toppings.AddRange(toppings);
      }
    }
  }
}
