using CoreAPIWithSwagger.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreAPIWithSwagger.Repository
{
    public class InMemoryBookRepo : IBook
    {
        private List<Book> _books;
        public InMemoryBookRepo()
        {
            _books = new() { new Book { Id = Guid.NewGuid(), Title = "First Love", Price = 100 } };
        }
        public void CreateBook(Book book)
        {
             _books.Add(book);
        }

        public void DeleteBook(Guid id)
        {
            var bookIndex = _books.FindIndex(x => x.Id == id);
            if (bookIndex > -1)
                _books.RemoveAt(bookIndex);
        }

        public Book GetBook(Guid id)
        {
            var books = _books.Where(x => x.Id == id).FirstOrDefault();
            return books;
        }

        public IEnumerable<Book> GetBooks()
        {
            return _books;
        }

        public void UpdateBook(Guid id, Book book)
        {
            var bookIndex = _books.FindIndex(x => x.Id == id);
            if (bookIndex > -1)
                _books[bookIndex] = book;
        }
    }
}
