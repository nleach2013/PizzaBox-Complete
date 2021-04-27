using System.Collections.Generic;
using System.Linq;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Models;
using PizzaBox.Storing;
using PizzaBox.Storing.Repositories;

namespace PizzaBox.Client.Singletons
{
  /// <summary>
  /// 
  /// </summary>
  public class OrderSingleton
  {
    private readonly FileRepository _fileRepository = new FileRepository();
    private static OrderSingleton _instance;
    private readonly PizzaBoxContext _context = new PizzaBoxContext();
    //private const string _path = @"data/Orders.xml";

    public List<Order> Orders { get; set; }
    public static OrderSingleton Instance
    {
      get
      {
        if (_instance == null)
        {
          _instance = new OrderSingleton();
        }

        return _instance;
      }
    }

    public void AddOrder(Order order)
    {
      //_context.Sizes.FirstOrDefault(s => s.Name == "Medium")
      order.Store = _context.Stores.FirstOrDefault(s => s.Name == order.Store.Name);
      order.Pizza.Crust = _context.Crusts.FirstOrDefault(s => s.Name == order.Pizza.Crust.Name);
      order.Pizza.Size = _context.Sizes.FirstOrDefault(s => s.Name == order.Pizza.Size.Name);

      var temp = new List<Topping>();
      foreach (var item in order.Pizza.Toppings)
      {
        temp.Add(_context.Toppings.FirstOrDefault(s => s.Name == item.Name));
      }
      order.Pizza.Toppings = temp;

      order.Pizza = _context.Pizzas.FirstOrDefault(s => s.EntityId == order.Pizza.EntityId);
      order.Customer = _context.Customers.FirstOrDefault(s => s.EntityId == order.Customer.EntityId);
      _context.Add(order);
      _context.SaveChanges();
    }

    public List<Order> ViewOrders(Customer cus)
    {
      var temp = new List<Order>();
      temp.AddRange(_context.Orders.Where(s => s.Customer.EntityId == cus.EntityId).ToList<Order>());
      return temp;
    }

    /// <summary>
    /// 
    /// </summary>
    private OrderSingleton()
    {
      //Orders = _fileRepository.ReadFromFile<List<AComponent>>(_path);
      Orders = _context.Orders.ToList();
    }
  }
}
