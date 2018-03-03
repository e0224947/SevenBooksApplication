using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SevenBooksApplication.App_Code;
using SevenBooksApplication.Models;
using System.Security.Principal;
using System.Web.Security;

namespace SevenBooksApplication
{
    public partial class MyAccount : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                MembershipUser currentUser = Membership.GetUser();
                Guid currentUserId = (Guid) currentUser.ProviderUserKey;

                List<Order> orderHistory = BusinessLogic.GetOrderHistory(currentUserId.ToString());
                if(orderHistory.Count == 0)
                {
                    this.MultiView1.ActiveViewIndex = 0;
                }
                else
                {
                    this.MultiView1.ActiveViewIndex = 1;
                    this.gvOrderHistory.DataSource = BusinessLogic.GetOrderHistory(currentUserId.ToString());
                    this.gvOrderHistory.DataBind();
                }
            }
        }

        protected void gvOrderHistory_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if(e.Row.RowType == DataControlRowType.DataRow)
            {
                Order order = e.Row.DataItem as Order;
                Book book = BusinessLogic.SearchBookByBookId(order.BookID);

                ((Label)e.Row.FindControl("lblTitle")).Text = book.Title;
            }
        }
    }
}