namespace LogisticLib
{
  public interface IShipper
  {
  	string Name { get; }
    void CalculateFee(ShippingProduct product);
  }
}
