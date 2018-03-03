using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SevenBooksApplication.App_Code;

namespace SevenBooksApplication
{
    public partial class SetDiscount : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btnConfirm_Click(object sender, EventArgs e)
        {
            string from = DateFrom.Text;
            string to = DateTo.Text;

            DateTime startDate = GetDateFromString(from);
            DateTime endDate = GetDateFromString(to);

            decimal percent = Convert.ToDecimal(tbDiscount.Text) / 100;

            BusinessLogic.CreateDiscount(startDate, endDate, percent);
        }

        private DateTime GetDateFromString(string date)
        {
            string[] numbers = date.Split('/');
            int month = Convert.ToInt32(numbers[0]);
            int day = Convert.ToInt32(numbers[1]);
            int year = Convert.ToInt32(numbers[2]);
            DateTime output = new DateTime(year, month, day);
            return output;
        }
    }
}