using System;
using System.Collections.Generic;
using System.Linq;
using TestTask.DAL.Interfaces;
using TestTask.Management.Interfaces;
using TestTask.Models;

namespace TestTask.Management.Managers
{
    public class BookManager : BaseManager, IBookManager
    {
        public BookManager(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public Book Create(Book book)
        {
            Book b = UnitOfWork.BookRepository.Create(new Book()
            {
                Author = book.Author,
                EditionDate = book.EditionDate,
                Title = book.Title
            });
            UnitOfWork.Save();
            return b;
        }

        public IEnumerable<Book> GetAll()
        {
            return UnitOfWork.BookRepository.GetAll();
        }

        public void Remove(Guid id)
        {
            UnitOfWork.BookRepository.Delete(id);
            UnitOfWork.Save();
        }

        public IEnumerable<Book> SearchByAuthorTitle(string searchText)
        {
            var books = UnitOfWork.BookRepository.GetAll().AsQueryable();
            var searchBoks = books.Where(x => x.Title.Contains(searchText) || x.Author.Contains(searchText));
            return searchBoks;
            //return UnitOfWork.BookRepository.Find(x =>x.Author.Contains(searchText) || x.Title.Contains(searchText));
        }

        public void Update(Book book)
        {
            UnitOfWork.BookRepository.Update(book);
            UnitOfWork.Save();
        }
    }
}
