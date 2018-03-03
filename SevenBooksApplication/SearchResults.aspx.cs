using SevenBooksApplication.App_Code;
using SevenBooksApplication.Models;
using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;


namespace SevenBooksApplication
{
    public partial class SearchResults : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!(string.IsNullOrEmpty(Request.QueryString["Term"])) && !(string.IsNullOrEmpty(Request.QueryString["Term"])))
                {
                    string searchTerm = Request.QueryString["Term"];
                    string searchBy = Request.QueryString["SearchBy"];

                    switch (searchBy)
                    {
                        case "Title":
                            repBookListSearch.DataSource = BusinessLogic.SearchBookByTitle(searchTerm);
                            break;
                        case "ISBN":
                            repBookListSearch.DataSource = BusinessLogic.SearchBookByISBNList(searchTerm);
                            break;
                        case "Category":
                            repBookListSearch.DataSource = BusinessLogic.SearchBookByCategory(searchTerm);
                            break;
                        default:
                            repBookListSearch.DataSource = BusinessLogic.SearchBookByTitle(searchTerm);
                            break;
                            //default case if person edit the query string in address bad          
                    }
                }
                else
                {
                    Server.Transfer("~/Default.aspx");
                }
                repBookListSearch.DataBind();
            }


        }
        protected void AddToCartbtn_Click(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "AddToCart")
            {
                ((List<Book>)Session["cartList"]).Add(BusinessLogic.SearchBookByISBN(e.CommandArgument.ToString()));
                Response.Redirect(Request.RawUrl);
            }
        }
    }
}