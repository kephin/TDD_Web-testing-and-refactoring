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

        var blackcat = new Blackcat();
        blackcat.CalculateFee(product);
      }
      else if (product.Shipper == 2)
      {
        this.lblCompany.Text = "新竹貨運";
        // 選擇新竹貨運計算運費

        var hsinchu = new Hsinchu();
        hsinchu.CalculateFee(product);
      }
      else if (product.Shipper == 3)
      {
        this.lblCompany.Text = "郵局";
        // 選擇郵局計算運費

        var postoffice = new Postoffice();
        postoffice.CalculateFee(product);
      }
      else
      {
          var js = "alert('發生不預期錯誤，請洽系統管理者');location.href='http://tw.yahoo.com/';";
          this.ClientScript.RegisterStartupScript(this.GetType(), "back", js, true);
      }
      this.lblCharge.Text = product.ShippingFee.ToString();
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
