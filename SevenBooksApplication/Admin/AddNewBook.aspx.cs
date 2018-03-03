using SevenBooksApplication.App_Code;
using System;

namespace SevenBooksApplication
{
    public partial class AddNewBook : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            StatusLabel.Visible = false;
            Message.Visible = false;
        }

        protected void Add_onClick(object sender, EventArgs e)
        {
            if (FileUpload1.HasFile)
            {
                try
                {
                    string filename = FileUpload1.FileName;
                 

                   FileUpload1.SaveAs(Server.MapPath(@"~/Image/") + filename);
                    StatusLabel.Text = "Upload status: File uploaded!";
                    StatusLabel.Visible = true;
                }
                catch (Exception ex)
                {
                    StatusLabel.Text =
                    "Upload status: The file could not be uploaded." +
                    "The following error occurred: " + ex.Message;
                    StatusLabel.Visible = true;
                }
            }

            string title = tbTitle.Text;
            string author = tbAuthor.Text;

            string isbn = tbISBN.Text;
            decimal price = Convert.ToDecimal(tbPrice.Text);
            string categoryName = ddlCategory.SelectedValue;
            int stock = Convert.ToInt32(tbQuantity.Text);
            Message.Visible = true;
            try
            {
                BusinessLogic.AddBook(title, categoryName, isbn, author, stock, price);
                Message.Text = "Added Successfully";
            }
            catch (Exception exp)
            {
                Message.Text = "Cannot Add Book";
          
                Response.Write(exp.ToString());
            }
        }

    }
}