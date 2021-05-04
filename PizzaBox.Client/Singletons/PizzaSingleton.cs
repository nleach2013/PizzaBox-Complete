using System.Collections.Generic;
using System.Linq;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Models;
using PizzaBox.Domain.Models.Pizzas;
using PizzaBox.Storing;
using PizzaBox.Storing.Repositories;

namespace PizzaBox.Client.Singletons
{
  /// <summary>
  /// 
  /// </summary>
  public class PizzaSingleton
  {
    private readonly FileRepository _fileRepository = new FileRepository();
    private static PizzaSingleton _instance;
    private const string _path = @"data/pizzas.xml";
    private readonly PizzaBoxContext _context = new PizzaBoxContext();

    public List<APizza> Pizzas { get; set; }
    public List<Topping> Toppings { get; set; }
    public List<ToppingRelation> ToppingRelations { get; set; }
    public static PizzaSingleton Instance
    {
      get
      {
        if (_instance == null)
        {
          _instance = new PizzaSingleton();
        }

        return _instance;
      }
    }

    public void AddPizza(APizza pizza)
    {
      //order.Pizza.Crust = _context.Crusts.FirstOrDefault(s => s.Name == order.Pizza.Crust.Name);
      pizza.Crust = _context.Crusts.FirstOrDefault(s => s.Name == pizza.Crust.Name);
      pizza.Size = _context.Sizes.FirstOrDefault(s => s.Name == pizza.Size.Name);
      var temp = new List<Topping>();
      foreach (var item in pizza.Toppings)
      {
        temp.Add(_context.Toppings.FirstOrDefault(s => s.Name == item.Name));
      }
      pizza.Toppings = temp;
      _context.Pizzas.Add(pizza);
      _context.SaveChanges();
    }

    /// <summary>
    /// 
    /// </summary>
    private PizzaSingleton()
    {
      //_context.Pizzas.AddRange(_fileRepository.ReadFromFile<List<APizza>>(_path));
      //var cp = new CustomPizza();

      //_context.SaveChanges();
      //var query = from Pizzas in _context.Pizzas
      //            where ToppingRelations.All(requiredId => Pizzas.EntityId.Any(Topping => Toppings.EntityId == requiredId));

      Pizzas = _context.Pizzas.ToList();
      Toppings = _context.Toppings.ToList();
      // var test = new ToppingRelation();
      // test.PizzaEntityId = 1;
      // test.ToppingEntityId = 1;
      // ToppingRelations = new List<ToppingRelation>();

      foreach (var item in Pizzas)
      {
        var query = from topping in _context.Toppings
                    where topping.Pizzas.Any(p => p.EntityId == item.EntityId)
                    select topping;
        item.Toppings = (query.ToList());
      }

      //ToppingRelations.AddRange(_context.ToppingRelations.ToList());
    }
  }
}
