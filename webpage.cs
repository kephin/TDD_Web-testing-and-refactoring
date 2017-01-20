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
      IShipper shipper = GetShipper(product.Shipper);

      if (shipper != null)
      {
        this.lblCompany.Text = shipper.Name;
        shipper.CalculateFee(product);
        this.lblCharge.Text = product.ShippingFee.ToString();
      }
      else
      {
        var js = "alert('發生不預期錯誤，請洽系統管理者');location.href='http://tw.yahoo.com/';";
        this.ClientScript.RegisterStartupScript(this.GetType(), "back", js, true);
      }
    }
  }

  private IShipper GetShipper(int shipper)
  {
    IShipper result = null;
    switch (shipper)
    {
      case 1:
        result = new Blackcat();
        break;

      case 2:
        result = new Hsinchu();
        break;

      case 3:
        result = new Postoffice();
        break;

      default:
        break;
    }
    return result;
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
