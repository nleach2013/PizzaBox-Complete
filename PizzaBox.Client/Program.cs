using System.Collections.Generic;
using System;
using sc = System.Console;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Models;
using PizzaBox.Client.Singletons;

namespace PizzaBox.Client
{
    public class Program
    {
        private static readonly StoreSingleton _storeSingleton = StoreSingleton.Instance;
        private static void Main()
        {
            Run();
        }

        private static void Run()
        {
            /*
            var order = new Order();

            //Greet
            */
            PrintStoreList();
            /*

            order.Customer = new Customer();
            order.Store = SelectStore();
            order.Pizza = SelectPizza();
            */



            sc.WriteLine("Make a selection");
            string input = sc.ReadLine();
            int entry = int.Parse(input);

            sc.WriteLine(_storeSingleton.Stores[entry]);
        }

        private static void PrintStoreList()
        {
            for (var x = 0; x < _storeSingleton.Stores.Count; x += 1)
            {
                sc.WriteLine($"{x} {_storeSingleton.Stores[x]}");
            }
        }
    }
}