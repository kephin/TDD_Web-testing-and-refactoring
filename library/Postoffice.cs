using System;

namespace LogisticLib
{
  public class Postoffice : IShipper
  {
    public Postoffice()
    {
    }

    public void CalculateFee(ShippingProduct product)
    {
      var feeByWeight = 80 + product.Weight * 10;

      var size = product.Size.Length * product.Size.Width * product.Size.Height;

      var feeBySize = size * 0.0000353 * 1100;

      if (feeByWeight < feeBySize)
      {
        product.ShippingFee = feeByWeight;
      }
      else
      {
        product.ShippingFee = feeBySize;
      }
    }
  }
}