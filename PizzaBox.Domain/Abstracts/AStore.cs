using System;
using System.Xml.Serialization;
using PizzaBox.Domain.Models;

namespace PizzaBox.Domain.Abstracts
{
    [XmlInclude(typeof(ChicagoStore))]
    [XmlInclude(typeof(NewYorkStore))]
    public abstract class AStore
    {
        public string Name { get; protected set; }

        public override string ToString()
        {
            return Name;
        }
    }
}