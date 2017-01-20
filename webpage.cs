using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Product : System.Web.UI.Page
{
  protected void Page_Load(object sender, EventArgs e)
  {
  }

  protected void btnCalculate_Click(object sender, EventArgs e)
  {
    if (this.IsValid)
    {
      var product = this.GetShippingProduct();
      if (product.Shipper == 1)
      {
        this.lblCompany.Text = "黑貓";
        // 選擇黑貓計算運費

        CalculateFeeByBlackcat(product);
      }
      else if (product.Shipper == 2)
      {
        this.lblCompany.Text = "新竹貨運";
        // 選擇新竹貨運計算運費

        CalculateFeeByHsinchu(product);
      }
      else if (product.Shipper == 3)
      {
        this.lblCompany.Text = "郵局";
        // 選擇郵局計算運費

        CalculateFeeByPostoffice(product);
      }
      else
      {
          var js = "alert('發生不預期錯誤，請洽系統管理者');location.href='http://tw.yahoo.com/';";
          this.ClientScript.RegisterStartupScript(this.GetType(), "back", js, true);
      }
      this.lblCharge.Text = product.ShippingFee.ToString();
    }
  }

  private static void CalculateFeeByPostoffice(ShippingProduct product)
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

  private static void CalculateFeeByHsinchu(ShippingProduct product)
  {
    var size = product.Size.Length * product.Size.Width * product.Size.Height;
    //長 x 寬 x 高（公分）x 0.0000353
    if (product.Size.Length > 100 || product.Size.Width > 100 || product.Size.Height > 100)
    {
      product.ShippingFee = size * 0.0000353 * 1100 + 500;
    }
    else
    {
      product.ShippingFee = size * 0.0000353 * 1200;
    }
  }

  private static void CalculateFeeByBlackcat(ShippingProduct product)
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

  private ShippingProduct GetShippingProduct()
  {
    var result = new ShippingProduct
    {
      Name = this.txtProductName.Text,
      Weight = Convert.ToDouble(this.txtProductWeight.Text),
      Size = new Size
      {
        Length = Convert.ToDouble(this.txtProductLength.Text),
        Width = Convert.ToDouble(this.txtProductWeight),
        Height = Convert.ToDouble(this.txtProductHeight),
      },
      Shipper = Convert.ToInt32(this.drpCompany.SelectedValue),
    };
    return result;
  }
}

public class ShippingProduct
{
  public string Name { get; set; }
  public double Weight { get; set; }
  public Size Size { get; set; }
  public int Shipper { get; set; }
  public double ShippingFee { get; set; }
}

public struct Size
{
  public double Length { get; set; }
  public double Width { get; set; }
  public double Height { get; set; }
}
