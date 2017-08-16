using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TestTask.DAL.EF;
using TestTask.DAL.Interfaces;
using TestTask.DAL.Interfaces.Repositories;
using TestTask.DAL.Repositories;

namespace TestTask.DAL.Infrastructure
{
    public class EFUnitOfWork : IUnitOfWork, IDisposable
    {
        #region Private

        private DataContext _context;
        private IBookRepository _bookRepository;
        private bool _disposed = false;

        private static T SafeCreateOrGet<T>(ref T obj, Func<T> valueFactory) where T : class
        {
            if (obj != null)
            {
                return obj;
            }

            Interlocked.CompareExchange(ref obj, valueFactory(), null);
            return obj;
        }
        #endregion
        public EFUnitOfWork(string connectionString)
        {
            _context = new DataContext(connectionString);
        }

        #region Repositories
        public IBookRepository BookRepository => SafeCreateOrGet(ref _bookRepository, () => new BookRepository(_context));

        #endregion

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            _disposed = true;
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
