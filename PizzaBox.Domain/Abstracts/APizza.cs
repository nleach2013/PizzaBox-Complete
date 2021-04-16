using System.Collections.Generic;
using PizzaBox.Domain.Models;

namespace PizzaBox.Domain.Abstracts
{
    public abstract class APizza
    {
        public Crust Crust { get; set; }
        public Size Size { get; set; }
        public List<Topping> Toppings = new List<Topping>();

        public void AddTopping(Topping NewTopping)
        {
            Toppings.Add(NewTopping);
        }

    }

}