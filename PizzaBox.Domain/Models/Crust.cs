using PizzaBox.Domain.Abstracts;

namespace PizzaBox.Domain.Models
{
    public class Crust : AComponent
    {
        public Crust() : base()
        {
            Name = "Normal Crust";

            Price = 1.00f;
        }
    }
}