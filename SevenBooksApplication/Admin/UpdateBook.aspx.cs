using SevenBooksApplication.App_Code;
using SevenBooksApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SevenBooksApplication
{
    public partial class UpdateBook : System.Web.UI.Page
    {
        
       
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                Message.Visible = false;
                // string isbn = Request.QueryString["ISBN"];
                string isbn = "9780812996937";
                Book b = BusinessLogic.SearchBookByISBN(isbn);
                tbBookId.Text = b.BookID + " ";
                tbAuthor.Text = b.Author;
                tbISBN.Text = b.ISBN;
                tbTitle.Text = b.Title;
                tbQuantity.Text = b.Stock + "";
                tbPrice.Text = b.Price + "";

                ddlCategory.Items[b.CategoryID - 1].Selected = true;
            }
        }

        protected void update(object sender, EventArgs e)
        {
            int bookID = Convert.ToInt32(tbBookId.Text);
            string title = tbTitle.Text;
            string author = tbAuthor.Text;

            string isbn = tbISBN.Text;
            decimal price = Convert.ToDecimal(tbPrice.Text);
            string categoryName = ddlCategory.SelectedValue;
            int stock = Convert.ToInt32(tbQuantity.Text);
            Message.Visible = true;

            try
            {

                BusinessLogic.UpdateBook(bookID, title, categoryName, isbn, author, stock, price);
                Message.Text = "Updated Successfully ";
            }
            catch (Exception exp)
            {
                Response.Write(exp.ToString());
                Message.Text = "Cannot be Updated ";
            }
        }
    }
}