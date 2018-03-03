using SevenBooksApplication.Models;
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using SevenBooksApplication.App_Code;
using System.Drawing;

namespace SevenBooksApplication
{
    public partial class MasterPage : System.Web.UI.MasterPage

    {
        string userName = "";
        bool isAdmin = false;

        public List<Book> CartList
        {
            get
            {
                if (Session["cartList"] == null)
                {
                    Session["cartList"] = new List<Book>();
                }
                return (List<Book>)Session["cartList"];
            }
            set
            {
                Session["cartList"] = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

            if (CartList.Count == 0)
            {
                btnCart.Text = "View Cart";
            }
            else
            {
                btnCart.Text = string.Format("View Cart ({0})", CartList.Count);
            }

            if (System.Web.HttpContext.Current != null)
            {
                userName = HttpContext.Current.User.Identity.Name;
                isAdmin = Roles.IsUserInRole("admin");
            }

            if (userName == "")
            {
                btnWelcome.Text = "Welcome, Guest";
            }
            else
            {
                btnWelcome.Text = string.Format("Welcome, {0}", userName);
            }

            if (isAdmin)
            {
                btnManageBook.Visible = true;
                btnManageOrder.Visible = true;
                btnManageDiscount.Visible = true;
            }
            else
            {
                btnManageBook.Visible = false;
                btnManageOrder.Visible = false;
                btnManageDiscount.Visible = false;
            }
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                          
            Color[] colourarray = new Color[] { Color.Cyan, Color.LightGoldenrodYellow, Color.WhiteSmoke, Color.Chartreuse, Color.Ivory};
            Color[] colourarray2 = new Color[] { Color.Black, Color.CornflowerBlue, Color.LightSlateGray, Color.MidnightBlue, Color.CadetBlue };
            Random r = new Random();

            if (BusinessLogic.GetCurrentDiscount() == 0)
            {
                Label1.Visible = false;
            }
            else
            {
                Label1.Text = "Storewide Discount " + String.Format("{0:##}", BusinessLogic.GetCurrentDiscount() * 100) + "% " + " until " + (BusinessLogic.GetCurrentDiscountEndDate()).Date.ToString("d");
                Label1.ForeColor = colourarray[r.Next(0, colourarray.Length)];
                Label1.DataBind();
                Label1.BackColor = colourarray2[r.Next(0, colourarray2.Length)];
            }

        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            if (tbSearch.Text != string.Empty)
            {
                Response.Redirect("~/SearchResults.aspx?SearchBy=" + ddlSearch.Text + "&Term=" + tbSearch.Text);
            }
            else
            {
                Response.Redirect("~/Default.aspx");
            }

        }

        protected void btnChildren_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/SearchResults.aspx?SearchBy=" + "Category" + "&Term=" + btnChildren.Text);
        }

        protected void btnFinance_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/SearchResults.aspx?SearchBy=" + "Category" + "&Term=" + btnFinance.Text);
        }

        protected void btnNonFiction_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/SearchResults.aspx?SearchBy=" + "Category" + "&Term=" + btnNonFiction.Text);
        }

        protected void btnTechnical_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/SearchResults.aspx?SearchBy=" + "Category" + "&Term=" + btnTechnical.Text);
        }

        protected void btnManageBook_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Admin/AddNewBook.aspx");
        }

        protected void btnManageOrder_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Admin/ViewAllOrders.aspx");
        }

        protected void btnManageDiscount_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Admin/SetDiscount.aspx");
        }

        protected void btnHome_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Default.aspx");
        }

        protected void btnCart_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/CartDetails.aspx");
        }

        protected void btnWelcome_Click(object sender, EventArgs e)
        {
            if(userName != "")
            {
                Response.Redirect("~/User/MyAccount.aspx");
            }
        }

        protected void LoginStatus_LoggingOut(object sender, System.Web.UI.WebControls.LoginCancelEventArgs e)
        {
            Session["cartList"] = new List<Book>();
        }
    }
}