using SevenBooksApplication.App_Code;
using SevenBooksApplication.Models;
using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Linq;


namespace SevenBooksApplication
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                repBookList.DataSource = BusinessLogic.SearchAllBooks();
                repBookList.DataBind();
            }

        }


        protected void AddToCartbtn_Click(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "AddToCart")
            {

                List<Book> books = (List<Book>)Session["cartList"];
                if(books != null && books.Where(x => x.ISBN == e.CommandArgument.ToString()).ToList().Count > 0)
                {
                    Book book = books.Where(x => x.ISBN == e.CommandArgument.ToString()).First();
                    int currentCountInCart = books.Where(x => x.ISBN == e.CommandArgument.ToString()).ToList().Count;

                    if (book.Stock - currentCountInCart < 0)
                    {
                        string msg = string.Format("<script>alert('Out of stock.');</script>");
                        Response.Write(msg);
                        return;
                    }
                }

                ((List<Book>)Session["cartList"]).Add(BusinessLogic.SearchBookByISBN(e.CommandArgument.ToString()));
                Response.Redirect(Request.RawUrl);

            }
        }
    }
}