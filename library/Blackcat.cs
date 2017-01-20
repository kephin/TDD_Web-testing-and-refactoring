using System;

namespace LogisticLib
{
  public class Blackcat : IShipper
  {
    public Blackcat()
    {
    }

    public void CalculateFee(ShippingProduct product)
    {
      var weight = product.Weight;
      if (weight > 20)
      {
        product.ShippingFee = 500;
      }
      else
      {
        var fee = 100 + weight * 10;
        product.ShippingFee = fee;
      }
    }
  }
}