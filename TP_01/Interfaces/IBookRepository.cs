using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP_01.Models;

//Feito por Eduardo Miranda CB3026604 & Cauã Barros CB3025179

namespace TP_01.Interfaces
{
    public interface IBookRepository
    {
        ICollection<Book> GetAllBooks();
        void AddBook(Book book);
    }
}
