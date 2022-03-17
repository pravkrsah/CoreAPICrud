using CoreAPIWithSwagger.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreAPIWithSwagger.Repository
{
    public interface IBook
    {
        public IEnumerable<Book> GetBooks();
        Book GetBook(Guid id);
        void CreateBook(Book book);
        void UpdateBook(Guid id, Book book);
        void DeleteBook(Guid id);

    }
}
