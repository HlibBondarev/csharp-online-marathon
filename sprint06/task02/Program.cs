using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Collections.Generic;
using System.Runtime.Intrinsics.X86;
using System.Threading.Tasks;
using System.Collections;
using static System.Reflection.Metadata.BlobBuilder;
using System.Linq;

namespace task02
{
    //Please, implement class Library with public property Books of generic IEnumerable type that can be set only inside the class,
    //and public property Filter(generic predicate) that sets a condition on book.The default value of Filter: any book satisfies
    //the condition.
    //The constructor of Library class takes 1 parameter for initialization Books property.

    //Implement GetEnumerator method that will allow to enumerate by only those books that satisfy the condition in Filter.
    //Do not use yields in this task.
    //Create MyEnumerator class that implements IEnumerator<Book>.
    //The constructor of MyEnumerator takes 2 parameters: for initialization books and filter.
    //Implement all the necessary methods and properties in MyEnumerator.

    //Implement MyUtils class with public static method GetFiltered that takes generics IEnumerable and Predicate and returns list
    //of filtered books using Library class and its enumerator.

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }

    public class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public int PageCount { get; set; }

        public Book(string title, string author, int pageCount)
        {
            Title = title;
            Author = author;
            PageCount = pageCount;
        }
    }

    public class Library : IEnumerable<Book>
    {
        // Properties:
        public IEnumerable<Book> Books { get; }
        public Predicate<Book> Filter { get; set; } = (Book t) => true;

        // Ctor:
        public Library(IEnumerable<Book> books)
        {
            Books = books;
        }

        // Implementation of IEnumerator and IEnumerator<Book>
        public IEnumerator<Book> GetEnumerator()
        {
            return new MyEnumerator(Books, Filter);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    public sealed class MyEnumerator : IEnumerator<Book>
    {
        readonly IEnumerator<Book> bookEnumerator;
        public IEnumerable<Book> Books { get; }
        public Predicate<Book> Filter { get; set; } = (Book t) => true;

        public MyEnumerator(IEnumerable<Book> books, Predicate<Book> predicate)
        {
            Books = books;
            Filter = predicate;
            bookEnumerator = (from book in Books
                              where Filter(book)
                              select book).GetEnumerator();
        }

        public Book Current { get; private set; }

        object IEnumerator.Current { get => Current; }

        public void Dispose()
        {
            bookEnumerator.Dispose();
        }

        public bool MoveNext()
        {
            bool result = bookEnumerator.MoveNext();
            if (result)
            {
                Current = bookEnumerator.Current;
            }
            return result;
        }

        public void Reset()
        {
            bookEnumerator.Reset();
        }
    }
    public class MyUtils
    {
        public static List<Book> GetFiltered(IEnumerable<Book> books, Predicate<Book> predicate)
        {
            var library = new Library(books);
            library.Filter = predicate;
            return library.ToList();
        }
    }
}