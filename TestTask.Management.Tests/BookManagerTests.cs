using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using TestTask.Management.Interfaces;
using TestTask.DAL.Interfaces;
using TestTask.Management.Managers;
using Ninject.MockingKernel.Moq;
using TestTask.DAL.Interfaces.Repositories;
using TestTask.Models;

namespace TestTask.Management.Tests
{
    [TestFixture]
    public class BookManagerTests
    {
        private IBookManager _bookManager;
        private Mock<IBookRepository> _bookRepositoryMock;
        private Mock<IUnitOfWork> _unioOfWorkMock;

        public BookManagerTests()
        {
            _unioOfWorkMock = new Mock<IUnitOfWork>();
            _bookRepositoryMock = new Mock<IBookRepository>();
            _unioOfWorkMock.Setup(x => x.BookRepository).Returns(_bookRepositoryMock.Object);

            _bookManager = new BookManager(_unioOfWorkMock.Object);
        }

        [SetUp]
        public void SetUp()
        {
            _bookRepositoryMock.Setup(x => x.GetAll())
                .Returns(new List<Book>() {
                    new Book { Author = "a1", Title = "t1" },
                    new Book { Author = "a2", Title = "t2" },
                    new Book { Author = "t1", Title = "t3" }
                });
        }

        [Test]
        public void SearchByAuthorTitleTest()
        {
            IEnumerable<Book> books = _bookManager.SearchByAuthorTitle("t1");
            Assert.AreEqual(2, books.Count());
        }
    }
}
