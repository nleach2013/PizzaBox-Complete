using System.Collections.Generic;
using System.Linq;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Storing;
using PizzaBox.Storing.Repositories;

namespace PizzaBox.Client.Singletons
{
  /// <summary>
  /// 
  /// </summary>
  public class StoreSingleton
  {
    private const string _path = @"data/stores.xml";
    private readonly FileRepository _fileRepository = new FileRepository();
    private readonly PizzaBoxContext _context = new PizzaBoxContext();
    private static StoreSingleton _instance;

    public List<AStore> Stores { get; }
    public static StoreSingleton Instance
    {
      get
      {
        if (_instance == null)
        {
          _instance = new StoreSingleton();
        }

        return _instance;
      }
    }

    /// <summary>
    /// 
    /// </summary>
    private StoreSingleton()
    {
      if (Stores == null)
      {
        _context.Stores.AddRange(_fileRepository.ReadFromFile<List<AStore>>(_path));
        _context.SaveChanges();

        Stores = _context.Stores.ToList();
      }
    }
  }
}
