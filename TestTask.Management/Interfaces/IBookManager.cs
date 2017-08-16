using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTask.Models;

namespace TestTask.Management.Interfaces
{
    public interface IBookManager : IDisposable
    {
        Book Create(Book book);
        void Remove(Guid id);
        void Update(Book book);
        IEnumerable<Book> SearchByAuthorTitle(string searchText);
        IEnumerable<Book> GetAll();
    }
}
