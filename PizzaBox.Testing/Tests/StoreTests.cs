using Xunit;
using PizzaBox.Domain.Models;

namespace PizzaBox.Testing.Tests
{
    public class StoreTests
    {
        [Fact]
        public void Test_ChicagoStore()
        {
            //arrange
            var sut = new ChicagoStore();

            //act
            var actual = sut.Name;

            //assert
            Assert.True(actual == "ChicagoStore");
            Assert.True(sut.ToString() == "ChicagoStore");
        }
        [Fact]
        public void Test_NewYorkStore()
        {
            //arrange
            var sut = new NewYorkStore();

            //act
            var actual = sut.Name;

            //assert
            Assert.True(actual == "NewYorkStore");
            Assert.True(sut.Name.Equals("NewYorkStore"));
        }
    }
}