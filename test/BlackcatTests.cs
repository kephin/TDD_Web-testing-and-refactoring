using Microsoft.VisualStudio.TestTools.UnitTesting;
using LogisticLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LogisticLib.Tests
{
  [TestClass()]
  public class BlackcatTests
  {
    [TestMethod()]
    public void CalculateFeeTest()
    {
      //arrange
      var target = new Blackcat();
      var product = new ShippingProduct
      {
        Name = "book",
        Weight = 10,
        Size = new Size
        {
          Length = 30,
          Width = 20,
          Height = 10,
        },
      };
      //act
      target.CalculateFee(product);
      //assert
      var expected = 200;
      Assert.AreEqual(expected, product.ShippingFee);
    }
  }
}
