using SevenBooksApplication.App_Code;
using SevenBooksApplication.Models;
using System;
using System.Collections.Generic;
using System.Web.Security;
using System.Linq;

namespace SevenBooksApplication
{
    public partial class BookDetails : System.Web.UI.Page
    {
        
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Request.QueryString["ISBN"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }

            if (!IsPostBack)
            {
                string isbn;
                Book b;

                isbn = Request.QueryString["ISBN"];
                b = BusinessLogic.SearchBookByISBN(isbn);

                tbAuthor.Text = b.Author;
                tbTitle.Text = b.Title;
                Title = b.Title + "- SevenBooks";
                tbPrice.Text = Convert.ToString(b.Price);

                int currentCountInCart = 0;
                List<Book> books = (List<Book>)Session["cartList"];
                if(books != null && books.Where(x => x.ISBN == Request.QueryString["ISBN"]).Count() > 0)
                {
                    Book book = books.Where(x => x.ISBN == Request.QueryString["ISBN"]).First();
                    currentCountInCart = books.Where(x => x.ISBN == Request.QueryString["ISBN"].ToString()).ToList().Count;
                }

                int stock = b.Stock - currentCountInCart;

                if(stock > 0)
                {
                    int[] stockArray = new int[stock];
                    for (int i = 0; i < stock; i++)
                    {
                        stockArray[i] = i + 1;
                    }
                    ddlQty.DataSource = stockArray;
                    ddlQty.DataBind();
                }
                else
                {
                    btAdd.Enabled = false;
                    btAdd.Text = "Out of stock.";
                }
                
                Image1.ImageUrl = string.Format("image/{0}.jpg", isbn);

                bool isAdmin = Roles.IsUserInRole("admin");
                if (isAdmin)
                {
                    btDelete.Visible = true;
                    btUpdate.Visible = true;
                }
                else
                {
                    btAdd.Visible = true;

                }
            }


        }

        protected void addCart(object sender, EventArgs e)
        {
            Book b = BusinessLogic.SearchBookByISBN(Request.QueryString["ISBN"]);
            tbTitle.Text = b.ISBN;

            int qty = Convert.ToInt32(ddlQty.SelectedValue);
            for (int i = 0; i < qty; i++)
            {
                ((List<Book>)Session["cartList"]).Add(b);
            }
            
            Response.Redirect(Request.RawUrl);
            SetVisible();
        }


        protected void update_button(object sender, EventArgs e)
        {
            SetVisible();
            Response.Redirect("UpdateBook.aspx?ISBN=" + Request.QueryString["ISBN"]);
        }

        protected void delete_book(object sender, EventArgs e)
        {
            // BusinessLogic.DeleteBook(ISBN);
            //neeed to change business logic
            SetVisible();
            Response.Redirect("Default.aspx");

        }

        public void SetVisible()
        {
            btAdd.Visible = false;
            btDelete.Visible = false;
            btUpdate.Visible = false;
        }


    }
}