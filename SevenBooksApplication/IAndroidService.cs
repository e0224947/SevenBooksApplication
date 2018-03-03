using SevenBooksApplication.Models;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace SevenBooksApplication
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IAndroidService" in both code and config file together.
    [ServiceContract]
    public interface IAndroidService
    {
        [OperationContract]
        [WebGet(UriTemplate = "/Books", ResponseFormat = WebMessageFormat.Json)]
        WCFBook[] FindAllBooks();

        [OperationContract]
        [WebGet(UriTemplate = "/Categories", ResponseFormat = WebMessageFormat.Json)]
        string[] FindCategories();

        [OperationContract]
        [WebGet(UriTemplate = "/Book-category/{category}", ResponseFormat = WebMessageFormat.Json)]
        WCFBook[] FindBookByCategory(string category);

        [OperationContract]
        [WebGet(UriTemplate = "/Book-title/{title}", ResponseFormat = WebMessageFormat.Json)]
        WCFBook[] FindBookByTitle(string title);

        [OperationContract]
        [WebGet(UriTemplate = "/Book-author/{author}", ResponseFormat = WebMessageFormat.Json)]
        WCFBook[] FindBookByAuthor(string author);

        [OperationContract]
        [WebGet(UriTemplate = "/Book/{id}", ResponseFormat = WebMessageFormat.Json)]
        WCFBook FindBookById(string id);

    }

    [DataContract]
    public class WCFBook
    {

        int bookID;
        string title;
        string author;
        string isbn;
        string category;
        int stock;
        decimal price;

        [DataMember(Name = "id")]
        public int BookID
        {
            get
            {
                return bookID;
            }

            set
            {
                bookID = value;
            }
        }
        [DataMember(Name = "title")]
        public string Title
        {
            get
            {
                return title;
            }

            set
            {
                title = value;
            }
        }
        [DataMember(Name = "author")]
        public string Author
        {
            get
            {
                return author;
            }

            set
            {
                author = value;
            }
        }
        [DataMember(Name = "isbn")]
        public string ISBN
        {
            get
            {
                return isbn;
            }

            set
            {
                isbn = value;
            }
        }
        [DataMember(Name = "category")]

        public string Category
        {
            get
            {
                return category;
            }

            set
            {
                category = value;
            }
        }
        [DataMember(Name = "stock")]
        public int Stock
        {
            get
            {
                return stock;
            }

            set
            {
                stock = value;
            }
        }
        [DataMember(Name = "price")]
        public decimal Price
        {
            get
            {
                return price;
            }

            set
            {
                price = value;
            }
        }


        public static WCFBook MakeBook(Book book)
        {
            WCFBook wcfBook = new WCFBook();
            wcfBook.title = book.Title;
            wcfBook.bookID = book.BookID;
            wcfBook.author = book.Author;
            wcfBook.category = book.Category.Name;
            wcfBook.isbn = book.ISBN;
            wcfBook.stock = book.Stock;
            wcfBook.price = book.Price;
            return wcfBook;
        }


    }
}
