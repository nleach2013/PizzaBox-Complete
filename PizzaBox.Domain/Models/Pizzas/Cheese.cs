using PizzaBox.Domain.Abstracts;

namespace PizzaBox.Domain.Models
{
    public class Cheese : APizza
    {
        public Cheese() : base()
        {
            Crust = new Crust();
            Size = new Size();
            Toppings.Add(new Topping());
        }
    }
}