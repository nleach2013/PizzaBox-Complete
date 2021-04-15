using System.Collections.Generic;
using System;
using sc = System.Console;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Models;

namespace PizzaBox.Client
{
    public class Program
    {
        private static void Main()
        {
            var stores = new List<AStore> { new ChicagoStore(), new NewYorkStore() };

            for (var x = 0; x < stores.Count; x += 1)
            {
                sc.WriteLine($"{x} {stores[x]}");
            }

            sc.WriteLine("Make a selection");
            string input = sc.ReadLine();
            int entry = int.Parse(input);

            sc.WriteLine(stores[entry]);
        }
    }
}