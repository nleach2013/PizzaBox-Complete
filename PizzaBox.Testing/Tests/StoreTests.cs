using System.Collections.Generic;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Models.Stores;
using PizzaBox.Domain.Models.Pizzas;
using Xunit;

namespace PizzaBox.Testing.Tests
{
  public class StoreTests
  {
    public static IEnumerable<object[]> values = new List<object[]>()
    {
      new object[] { new ChicagoStore() },
      new object[] { new NewYorkStore() }
    };

    public static IEnumerable<object[]> PizzaValues = new List<object[]>()
    {
      new object[] { new MeatPizza() },
      new object[] { new VeggiePizza() },
      new object[] { new CustomPizza()}
    };

    /// <summary>
    /// 
    /// </summary>
    [Fact]
    public void Test_ChicagoStore()
    {
      // arrange
      var sut = new ChicagoStore();

      // act
      var actual = sut.Name;

      // assert
      Assert.True(actual == "ChicagoStore");
      Assert.True(sut.ToString() == actual);
    }

    /// <summary>
    /// 
    /// </summary>
    [Fact]
    public void Test_NewYorkStore()
    {
      var sut = new NewYorkStore();

      Assert.True(sut.Name.Equals("NewYorkStore"));
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="store"></param>
    [Theory]
    [MemberData(nameof(values))]
    public void Test_StoreName(AStore store)
    {
      Assert.NotNull(store.Name);
      Assert.Equal(store.Name, store.ToString());
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="storeName"></param>
    /// <param name="x"></param>
    [Theory]
    [InlineData("ChicagoStore")]
    [InlineData("NewYorkStore")]
    public void Test_StoreNameSimple(string storeName)
    {
      Assert.NotNull(storeName);
    }

    [Theory]
    [MemberData(nameof(PizzaValues))]
    public void Pizza_Testing(APizza pizza)
    {
      Assert.NotNull(pizza.Crust);
      Assert.NotNull(pizza.Size);
      Assert.NotEmpty(pizza.Toppings);
    }

    [Theory]
    [MemberData(nameof(PizzaValues))]
    public void Pizza_Prices(APizza pizza)
    {
      Assert.True(pizza.getPrice() > 0.00M);
    }
  }
}
