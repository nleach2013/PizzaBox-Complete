using PizzaBox.Domain.Abstracts;

namespace PizzaBox.Domain.Models
{
    public class Topping : AComponent
    {
        public Topping() : base()
        {
            Name = "Cheese";

            Price = 2.00f;
        }
    }
}