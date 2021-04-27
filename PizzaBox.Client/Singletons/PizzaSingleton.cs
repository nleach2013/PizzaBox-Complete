using System.Collections.Generic;
using System.Linq;
using PizzaBox.Domain.Abstracts;
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

      _context.SaveChanges();

      Pizzas = _context.Pizzas.ToList();
    }
  }
}
