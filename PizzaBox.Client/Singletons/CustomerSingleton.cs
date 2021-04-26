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
  public class CustomerSingleton
  {
    private readonly FileRepository _fileRepository = new FileRepository();
    private static CustomerSingleton _instance;
    private readonly PizzaBoxContext _context = new PizzaBoxContext();
    //private const string _path = @"data/Customers.xml";

    public List<Customer> Customers { get; set; }
    public static CustomerSingleton Instance
    {
      get
      {
        if (_instance == null)
        {
          _instance = new CustomerSingleton();
        }

        return _instance;
      }
    }

    public long AddCustomer(Customer customer)
    {
      //_context.Sizes.FirstOrDefault(s => s.Name == "Medium")
      _context.Add(customer);
      _context.SaveChanges();
      return _context.Customers.FirstOrDefault(s => s.Name == customer.Name).EntityId;
    }

    public Customer GetCustomerByID(int ID)
    {
      Customer temp = _context.Customers.FirstOrDefault(s => s.EntityId == ID);
      return temp;
    }

    /// <summary>
    /// 
    /// </summary>
    private CustomerSingleton()
    {
      //Customers = _fileRepository.ReadFromFile<List<AComponent>>(_path);
      Customers = _context.Customers.ToList();
    }
  }
}
