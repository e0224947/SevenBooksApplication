using SevenBooksApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SevenBooksApplication.App_Code;
using System.Web.Security;

namespace SevenBooksApplication
{
    public partial class CartDetails : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                List<Book> bookList = Session["cartList"] as List<Book>;
                GridView1.DataSource = bookList;
                GridView1.DataBind();

                Double subtotal = 0;
                foreach (Book b in bookList)
                {
                    subtotal += (double)b.Price;
                }

                decimal discount = BusinessLogic.GetCurrentDiscount();

                Label1.Text = String.Format("S${0:0.00}", subtotal);
                Label2.Text = (discount * 100).ToString() + "%";
                Label3.Text = String.Format("S${0:0.00}", GrandTotal(subtotal, discount));
                Decimal SubTotal = Convert.ToDecimal(subtotal);
            }

        }
        public static Decimal GrandTotal(double subtotal, decimal discount)
        {
            decimal grandTotal = (decimal)subtotal * (1 - discount);
            return grandTotal;


        }

        protected void GridView1_SelectedIndexChanged1(object sender, EventArgs e)
        {

        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/User/CheckoutCart.aspx");
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            List<Book> bookList = Session["cartList"] as List<Book>;
            bookList.RemoveAt(e.RowIndex);
            GridView1.DataSource = bookList;
            GridView1.DataBind();
        }
    }
}