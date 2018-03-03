using System;
using SevenBooksApplication.App_Code;
using SevenBooksApplication.Models;
using System.Collections.Generic;

namespace SevenBooksApplication
{
    public class AndroidService : IAndroidService
    {

        public WCFBook[] FindAllBooks()
        {
            return ConvertFromBookList(BusinessLogic.SearchAllBooks());
        }

        public string[] FindCategories()
        {
            List<Category> c = BusinessLogic.FindAllCategories();
            string[] categories = new string[c.Count];
            for (int i = 0; i < categories.Length; i++)
            {
                categories[i] = c[i].Name;
            }
            return categories;
        }

        public WCFBook[] FindBookByCategory(string category)
        {
            return ConvertFromBookList(BusinessLogic.SearchBookByCategory(category));
        }

        public WCFBook[] FindBookByTitle(string title)
        {
            return ConvertFromBookList(BusinessLogic.SearchBookByTitle(title));

        }

        public WCFBook[] FindBookByAuthor(string author)
        {
            return ConvertFromBookList(BusinessLogic.SearchBookByAuthor(author));
        }

        public WCFBook FindBookById(string id)
        {
            int bookId;
            bool result = Int32.TryParse(id, out bookId);
            if (result)
            {
                return WCFBook.MakeBook(BusinessLogic.SearchBookByBookId(bookId));
            }
            return null;
        }

        //helper method
        private WCFBook[] ConvertFromBookList(List<Book> bList)
        {
            WCFBook[] bk = new WCFBook[bList.Count];
            for (int i = 0; i < bList.Count; i++)
            {
                bk[i] = WCFBook.MakeBook(bList[i]);
            }
            return bk;
        }
    }
}
