using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using PizzaBox.Domain.Models;
using PizzaBox.Domain.Models.Pizzas;

namespace PizzaBox.Domain.Abstracts
{
  /// <summary>
  /// 
  /// </summary>
  [XmlInclude(typeof(CustomPizza))]
  [XmlInclude(typeof(MeatPizza))]
  [XmlInclude(typeof(VeggiePizza))]
  public abstract class APizza : AModel
  {
    public Crust Crust { get; set; }
    public long CrustEntityId { get; set; }
    public Size Size { get; set; }
    public long SizeEntityId { get; set; }
    public List<Topping> Toppings { get; set; }

    /// <summary>
    /// 
    /// </summary>
    protected APizza()
    {
      Factory();
    }

    /// <summary>
    /// 
    /// </summary>
    protected virtual void Factory()
    {
      AddCrust();
      AddSize();
      AddToppings();
    }

    /// <summary>
    /// 
    /// </summary>
    public abstract void AddCrust(Crust crust = null);

    /// <summary>
    /// 
    /// </summary>
    public abstract void AddSize(Size size = null);

    /// <summary>
    /// 
    /// </summary>
    public abstract void AddToppings(params Topping[] toppings);

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public override string ToString()
    {
      var stringBuilder = new StringBuilder();
      var separator = ", ";
      var Price = 0.00M;

      Price += Crust.Price;
      Price += Size.Price;

      foreach (var item in Toppings)
      {
        stringBuilder.Append($"{item}{separator}");
        Price += item.Price;
      }

      return $"{Crust} - {Size} - {stringBuilder.ToString().TrimEnd(separator.ToCharArray())} - {Price}";
    }

    public decimal getPrice()
    {
      var Price = 0.00M;

      Price += Crust.Price;
      Price += Size.Price;

      foreach (var item in Toppings)
      {
        Price += item.Price;
      }

      return Price;
    }

    public string ToppingList()
    {
      var stringBuilder = new StringBuilder();
      var separator = ", ";

      foreach (var item in Toppings)
      {
        stringBuilder.Append($"{item}{separator}");
      }

      return $"{stringBuilder.ToString().TrimEnd(separator.ToCharArray())}";
    }
  }
}
