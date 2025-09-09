using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP_01.Interfaces;
using TP_01.Models;

Feito por Eduardo Miranda CB3026604 & Cauã Barros CB3025179

namespace TP_01.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly string _csvPath;
        private readonly List<Book> _books = new ();

        public BookRepository(string csvPath = "D:/Programação/Visual Studio/Repositories/TP_01/books.csv")
        {
            _csvPath = csvPath;
            LoadBooksFromCsv();
        }

        public void AddBook(Book book)
        {
            _books.Add(book);
            SaveBooksToCsv();
        }

        public ICollection<Book> GetAllBooks()
        {
            return _books;
        }

        private void LoadBooksFromCsv()
        {
            Console.WriteLine(_csvPath);
            if (!File.Exists(_csvPath))
                return;

            _books.Clear();
            var lines = File.ReadAllLines(_csvPath);

            foreach (var line in lines)
            {
                if (string.IsNullOrWhiteSpace(line)) continue;

                var parts = line.Split(',');
                if (parts.Length < 4) continue;

                var name = parts[0];
                var authorsRaw = parts[1];
                var price = double.Parse(parts[2], CultureInfo.InvariantCulture);
                var qty = int.Parse(parts[3]);

                var authors = authorsRaw.Split(';')
                    .Select(a =>
                    {
                        var authorParts = a.Split('|');
                        return new Author(
                            authorParts[0],
                            authorParts[1],
                            authorParts[2][0]
                        );
                    })
                    .ToArray();

                var book = new Book(name, authors, price, qty);
                _books.Add(book);
            }
        }

        private void SaveBooksToCsv()
        {
            var lines = _books.Select(book =>
            {
                var authors = string.Join(";", book.getAuthors()
                    .Select(a => $"{a.name}|{a.email}|{a.gender}"));
                return $"{book.getName()},{authors},{book.getPrice().ToString(CultureInfo.InvariantCulture)},{book.getQty()}";
            });

            File.WriteAllLines(_csvPath, lines);
        }
    }
}
