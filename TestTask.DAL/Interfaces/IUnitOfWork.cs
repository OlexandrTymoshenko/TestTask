using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTask.DAL.Interfaces.Repositories;

namespace TestTask.DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IBookRepository BookRepository { get; }
        void Save();
    }
}
