using System.Collections.Generic;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Storing.Repositories;

namespace PizzaBox.Client.Singletons
{
  /// <summary>
  /// 
  /// </summary>
  public class CrustSingleton
  {
    private readonly FileRepository _fileRepository = new FileRepository();
    private static CrustSingleton _instance;
    private const string _path = @"data/crusts.xml";

    public List<AComponent> Crusts { get; set; }
    public static CrustSingleton Instance
    {
      get
      {
        if (_instance == null)
        {
          _instance = new CrustSingleton();
        }

        return _instance;
      }
    }

    /// <summary>
    /// 
    /// </summary>
    private CrustSingleton()
    {
      Crusts = _fileRepository.ReadFromFile<List<AComponent>>(_path);
    }
  }
}
