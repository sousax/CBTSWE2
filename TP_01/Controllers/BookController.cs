using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using TP_01.Interfaces;
using TP_01.Models;
using TP_01.Repositories;

//Feito por Eduardo Miranda CB3026604 & Cauã Barros CB3025179
namespace TP_01.Controllers
{
    public class BookController
    {
        private readonly IBookRepository _bookRepository;

        public BookController()
        {
            this._bookRepository = new BookRepository("C:\\Eduardo Sousa\Desktop\Faculdade\CBTSWE2\books.csv");
        }

        // B1 - Retorna o nome de todos os livros
        public Task GetBookName(HttpContext context)
        {
            var books = _bookRepository.GetAllBooks();
            if (!books.Any())
                return context.Response.WriteAsync("Nenhum livro encontrado.");

            var result = string.Join(Environment.NewLine, books.Select(b => b.getName()));
            return context.Response.WriteAsync(result);
        }

        // B2 - Retorna o resultado do método ToString() do primeiro livro
        public Task GetBookToString(HttpContext context)
        {
            var books = _bookRepository.GetAllBooks();
            if (!books.Any())
                return context.Response.WriteAsync("Nenhum livro encontrado.");

            var result = string.Join(Environment.NewLine, books.Select(b => b.ToString()));
            return context.Response.WriteAsync(result);
        }

        // B3 - Retorna o resultado do método getAuthorNames() do primeiro livro
        public Task GetBookAuthorNames(HttpContext context)
        {
            var books = _bookRepository.GetAllBooks();
            if (!books.Any())
                return context.Response.WriteAsync("Nenhum livro encontrado.");

            var result = string.Join(Environment.NewLine, books.Select(b => b.getAuthorNames()));
            return context.Response.WriteAsync(result);
        }

        // B4 - Retorna uma página HTML com o nome do livro e a lista de autores
        public Task ApresentarLivro(HttpContext context)
        {
            var books = _bookRepository.GetAllBooks();
            string html;
            if (books == null || !books.Any())
            {
                html = "<html><body><h1>Nenhum livro encontrado</h1></body></html>";
            }
            else
            {
                var sb = new StringBuilder();
                sb.Append("<html><body>");
                sb.Append("<h1>Livros</h1>");
                sb.Append("<ul>");
                foreach (var book in books)
                {
                    sb.Append($"<li><b>{book.getName()}</b><ul>");
                    foreach (var author in book.getAuthors())
                    {
                        sb.Append($"<li>{author.name}</li>");
                    }
                    sb.Append("</ul></li>");
                }
                sb.Append("</ul>");
                sb.Append("</body></html>");
                html = sb.ToString();
            }
            context.Response.ContentType = "text/html; charset=utf-8";
            return context.Response.WriteAsync(html);
        }
    }
}