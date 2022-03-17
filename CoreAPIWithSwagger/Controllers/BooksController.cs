using CoreAPIWithSwagger.Dtos;
using CoreAPIWithSwagger.Models;
using CoreAPIWithSwagger.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreAPIWithSwagger.Controllers
{
    [ApiController]
    [Route("books")]
    public class BooksController : ControllerBase
    {
        private IBook _bookRepo;
        public BooksController(IBook bookRepo)
        {
            _bookRepo = bookRepo;
            //_bookRepo = new InMemoryBookRepo();
        }
        [HttpGet]
        public ActionResult<IEnumerable<BookDTO>> GetBooks()
        {
            return _bookRepo.GetBooks()
                .Select(x => new BookDTO { Id = x.Id, Title = x.Title, Price = x.Price })
                .ToList();
        }
        [HttpGet("{id}")]
        public ActionResult<BookDTO> GetBook(Guid id)
        {
            var book = _bookRepo.GetBook(id);
            if (book == null)
                return NotFound();
            var bookDTO = new BookDTO { Id = book.Id, Title = book.Title, Price = book.Price };
            return bookDTO;
        }
        [HttpPost]
        public ActionResult CreateBook(CreateOrUpdateBookDTO book)
        {
            var myBook = new Book();
            myBook.Id = Guid.NewGuid();
            myBook.Title = book.Title;
            myBook.Price = book.Price;

            _bookRepo.CreateBook(myBook);
            return Ok();
        }
        [HttpPut("{id}")]
        public ActionResult UpdateBook(Guid id, CreateOrUpdateBookDTO book)
        {
            var myBook = _bookRepo.GetBook(id);

            if (myBook == null)
                return NotFound();
            _bookRepo.UpdateBook(id, myBook);
            return Ok();
        }
        [HttpDelete("{id}")]
        public ActionResult DeleteBook(Guid id)
        {
            var myBook = _bookRepo.GetBook(id);

            if (myBook == null)
                return NotFound();
            _bookRepo.DeleteBook(id);
            return Ok();
        }
    }
}
