using System;
using System.Collections.Generic;
using System.Linq;
using TP_01.Interfaces;
using TP_01.Models;

//Feito por Eduardo Miranda CB3026604 & Cauã Barros CB3025179
namespace TP_01.Repositories
{
    public class FakeBookRepository : IBookRepository
    {
        private readonly List<Book> _books = new();

        public FakeBookRepository()
        {
            
            var autor1 = new Author("Erich Gamma", "erich@gof.com", 'M');
            var autor2 = new Author("Richard Helm", "richard@gof.com", 'M');

           
            var book = new Book("Design Patterns", new[] { autor1, autor2 }, 200.00, 3);

           
            _books.Add(book);

         
            Console.WriteLine("Demonstração dos métodos da classe Book:");
            Console.WriteLine("getName(): " + book.getName());

            Console.WriteLine("getAuthors():");
            foreach (var author in book.getAuthors())
            {
                Console.WriteLine("  " + author.ToString());
            }

            Console.WriteLine("getPrice(): " + book.getPrice());
            Console.WriteLine("getQty(): " + book.getQty());

            
            book.setPrice(180.00);
            book.setQty(5);

            Console.WriteLine("Após setPrice(180.00) e setQty(5):");
            Console.WriteLine("getPrice(): " + book.getPrice());
            Console.WriteLine("getQty(): " + book.getQty());

            Console.WriteLine("getAuthorNames(): " + book.getAuthorNames());
            Console.WriteLine("ToString(): " + book.ToString());
            Console.WriteLine("\n");
        }

        public void AddBook(Book book)
        {
            _books.Add(book);
        }

        public ICollection<Book> GetAllBooks()
        {
            return _books;
        }
    }
}