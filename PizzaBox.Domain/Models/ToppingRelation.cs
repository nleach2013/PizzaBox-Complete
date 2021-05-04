using System.Collections.Generic;
using PizzaBox.Domain.Abstracts;

namespace PizzaBox.Domain.Models
{
  /// <summary>
  /// 
  /// </summary>
  public class ToppingRelation : AModel
  {
    public int PizzaEntityId { get; set; }
    public int ToppingEntityId { get; set; }
  }
}