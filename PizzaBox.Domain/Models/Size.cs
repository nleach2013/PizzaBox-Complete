using PizzaBox.Domain.Abstracts;

namespace PizzaBox.Domain.Models
{
    public class Size : AComponent
    {
        public Size() : base()
        {
            Name = "Small";

            Price = 4.00f;
        }
    }
}