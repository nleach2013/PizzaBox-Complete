using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Models;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace PizzaBox.Client.Singletons
{
    public class StoreSingleton
    {

        private static readonly StoreSingleton _instance;
        public List<AStore> Stores { get; }

        public static StoreSingleton Instance
        {
            get
            {
                if (_instance == null)
                {

                    return new StoreSingleton();
                }

                return _instance;
            }
        }

        private StoreSingleton()
        {
            Stores = new List<AStore>()
            {
                new NewYorkStore(),
                new ChicagoStore()
            };
        }

        private void WriteToFiles()
        {
            //File Path
            var path = @"store.xml"; // @ = literal explicit string
            //Open File
            var writer = new StreamWriter(path);
            //Convert Object to Text
            var xml = new XmlSerializer(typeof(List<AStore>));
            //Write to File
            xml.Serialize(writer, Stores);
        }
    }
}