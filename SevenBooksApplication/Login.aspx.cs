using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SevenBooksApplication.App_Code;
using System.Web.Security;
using SevenBooksApplication.Models;

namespace SevenBooksApplication
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void Login1_LoggedIn(object sender, EventArgs e)
        {
            Redirect();
        }

        protected void CreateUserWizard1_CreatedUser(object sender, EventArgs e)
        {
            string username = CreateUserWizard1.UserName;
            Roles.AddUserToRole(username, "user");
        }

        protected void CreateUserWizard1_ContinueButtonClick(object sender, EventArgs e)
        {
            Redirect();
        }

        private void Redirect()
        {
            Session["cartList"] = new List<Book>();

            bool isAdmin = Roles.IsUserInRole("admin");
            if(isAdmin)
            {
                Response.Redirect("~/Admin/Default.aspx");
            }
            else
            {
                if (Request.QueryString["ReturnUrl"] != null)
                {
                    string returnUrl = Request.QueryString["ReturnUrl"];
                    Response.Redirect(returnUrl);
                }
                Response.Redirect("~/Default.aspx");
            }
        }
    }
}