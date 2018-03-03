using SevenBooksApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SevenBooksApplication.App_Code
{
    public class BusinessLogic
    {
        static BookContext context = new BookContext();

        public static void AddBook(string title, string categoryName, string isbn, string author, int stock, decimal price)
        {

            //using (BookContext context = new BookContext())
            //{
            Book book = new Book
            {
                Title = title,
                ISBN = isbn,
                Author = author,
                Stock = stock,
                CategoryID = GetCategoryID(categoryName),
                Price = price
            };
            context.Books.Add(book);
            context.SaveChanges();

            // }
        }
        public static void UpdateBook(int BookID, string Title, string CategoryName, string ISBN, string Author, int Stock, decimal Price)
        {
            //using (BookContext context = new BookContext())
            //{
            Book book = context.Books.Where(x => x.ISBN == ISBN).First();
            book.Title = Title;
            book.CategoryID = GetCategoryID(CategoryName);
            book.ISBN = ISBN;
            book.Author = Author;
            book.Stock = Stock;
            book.Price = Price;
            context.SaveChanges();
            //}
        }
        public static void DeleteBook(string ISBN)
        {
            //using (BookContext context = new BookContext())
            //{
            Book book = context.Books.Where(x => x.ISBN == ISBN).First();
            context.Books.Remove(book);
            context.SaveChanges();
            // }
        }
        public static List<Category> FindAllCategories()
        {
            //using (BookContext context = new BookContext())
            //{
            return context.Categories.ToList<Category>();
            //}
        }

        public static List<Book> SearchAllBooks()
        {
            //using (BookContext context = new BookContext())
            //{
            return context.Books.ToList<Book>();
            // }
        }
        public static List<Book> SearchBookByTitle(string Title)
        {
            // using (BookContext context = new BookContext())
            // {
            return context.Books.Where(x => x.Title.ToLower().Contains(Title.ToLower().Trim())).ToList<Book>();
            //}
        }

        public static List<Book> SearchBookByAuthor(string Author)
        {
            // using (BookContext context = new BookContext())
            //{
            return context.Books.Where(x => x.Author.ToLower().Contains(Author.ToLower().Trim())).ToList<Book>();
            //}
        }
        public static Book SearchBookByISBN(string ISBN)
        {
            // using (BookContext context = new BookContext())
            //{
            return context.Books.Where(x => x.ISBN.Contains(ISBN.Trim())).ToList<Book>().FirstOrDefault();
            // }
        }

        public static List<Book> SearchBookByISBNList(string ISBNa)
        {
            List<Book> Booker = new List<Book>();
            Booker.Add(SearchBookByISBN(ISBNa));
            return Booker;
        }

        public static Book SearchBookByBookId(int bookID)
        {
            //using (BookContext context = new BookContext())
            //{
            Book searchedID = context.Books.Where(x => x.BookID == bookID).FirstOrDefault();
            return searchedID;
            //}
        }
        public static int GetCategoryID(string category)
        {
            //using (BookContext context = new BookContext())
            //{

            Category c = context.Categories.Where(x => x.Name == category).FirstOrDefault();
            if (c == null) { return 0; }
            else
                return c.CategoryID;

            //}
        }
        public static List<Book> SearchBookByCategory(string category)
        {
            // using (BookContext context = new BookContext())
            // {
            int categoryID = GetCategoryID(category);
            return context.Books.Where(x => x.CategoryID == categoryID).ToList<Book>();

            //}
        }
        public static List<Order> SearchAllOrder()
        {
            // using (BookContext context = new BookContext())
            //{
            return context.Orders.ToList<Order>();
            //}
        }
        public static List<Order> SearchOrderByUserID(string UserID)
        {
            //using (BookContext context = new BookContext())
            //{
            return context.Orders.Where(x => x.UserID == UserID).ToList<Order>();
            //}
        }
        public static Order SearchByOrderID(int OrderID)
        {
            // using (BookContext context = new BookContext())
            //{
            return context.Orders.Where(x => x.OrderID == OrderID).FirstOrDefault();
            //}
        }
        public static void UpdateOrder(int OrderID, string OrderStatus)
        {
            //using (BookContext context = new BookContext())
            //{
            Order order = context.Orders.Where(x => x.OrderID == OrderID).First();
            order.OrderStatus = OrderStatus;
            context.SaveChanges();
            //}
        }

        public static void CreateOrder(List<Book> books, string userID)
        {
            List<Order> orders = new List<Order>();

            Dictionary<Book, int> dict = books.GroupBy(x => x.ISBN).ToDictionary(k => k.First(), v => v.Count());
            foreach (Book book in dict.Keys)
            {
                Order o = new Order()
                {
                    BookID = book.BookID,
                    UserID = userID,
                    DatePurchase = DateTime.Today,
                    Price = Math.Round((book.Price * (1 - GetCurrentDiscount()) * dict[book]), 4),
                    Discount = GetCurrentDiscount(),
                    Quantity = dict[book],
                    OrderStatus = "Processing",
                };

                orders.Add(o);
            }

            // using (BookContext context = new BookContext())
            //{
            context.Orders.AddRange(orders);
            try
            {
                context.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception(e.ToString(), e.InnerException);
            }

            foreach (Book book in dict.Keys)
            {
                Book b = context.Books.Where(x => x.BookID == book.BookID).First();
                b.Stock -= dict[book];
            }
            try
            {
                context.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception(e.ToString(), e.InnerException);
            }

            //            }

        }

        public static void CreateDiscount(DateTime startDate, DateTime endDate, decimal percent)
        {
            using (BookContext context = new BookContext())
            {
                Discount discount = new Discount()
                {
                    StartDate = startDate,
                    EndDate = endDate,
                    PercentDiscount = percent
                };

                context.Discounts.Add(discount);
                context.SaveChanges();
            }
        }

        //
        // Summary:
        //     Gets the latest discount percent.
        //
        // Returns:
        //     Discount percent (eg. 0.50). Return 0 if expired or no current discount.
        public static decimal GetCurrentDiscount()
        {
            // using (BookContext context = new BookContext())
            //{
            Discount discount = context.Discounts.OrderByDescending(d => d.EndDate).FirstOrDefault();
            if (discount == null || discount.EndDate < DateTime.Today || discount.StartDate > DateTime.Today)
            {
                return 0;
            }
            return discount.PercentDiscount;
            //}
        }

        public static DateTime GetCurrentDiscountEndDate()
        {
            // using (BookContext context = new BookContext())
            // {
            Discount discount = context.Discounts.OrderByDescending(d => d.EndDate).FirstOrDefault();
            if (discount == null || discount.EndDate < DateTime.Today || discount.StartDate > DateTime.Today)
            {
                return DateTime.Today.AddDays(-1);
            }
            return discount.EndDate;
            // }
        }

        public static List<Order> GetOrderHistory(string userID)
        {
            // using (BookContext context = new BookContext())
            // {
            List<Order> orderHistory = (from x in context.Orders
                                        where x.UserID == userID
                                        orderby x.DatePurchase descending
                                        select x).ToList();
            return orderHistory;
            // }
        }
        public static String GetBookTitle(int bookID)
        {
            //using (BookContext context = new BookContext())
            //{
            return context.Books.Where(x => x.BookID == bookID).FirstOrDefault().Title;
            //}
        }


    }
}