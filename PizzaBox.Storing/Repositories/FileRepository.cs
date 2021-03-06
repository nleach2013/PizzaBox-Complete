using System;
using System.IO;
using System.Xml.Serialization;
using PizzaBox.Domain;

namespace PizzaBox.Storing.Repositories
{
  /// <summary>
  /// 
  /// </summary>
  public class FileRepository
  {
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public T ReadFromFile<T>(string path) where T : class
    {
      try
      {
        var reader = new StreamReader(path);
        var xml = new XmlSerializer(typeof(T));

        return xml.Deserialize(reader) as T;
      }
      catch (Exception e)
      {
        System.Console.WriteLine($"Error caught was:\n\n {e}\n\n\n\n");
        return null;
      }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public bool WriteToFile<T>(string path, T items) where T : class
    {
      try
      {
        var writer = new StreamWriter(path);
        var xml = new XmlSerializer(typeof(T));

        xml.Serialize(writer, items);

        return true;
      }
      catch
      {
        return false;
      }
    }
  }
}
