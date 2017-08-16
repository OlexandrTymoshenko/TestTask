using System;
using TestTask.DAL.Infrastructure;
using TestTask.DAL.Interfaces;

namespace TestTask.Management
{
    public abstract class BaseManager : IDisposable
    {
        private bool _disposed = false;
        protected BaseManager(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }

        protected IUnitOfWork UnitOfWork { get; }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                UnitOfWork.Dispose();
            }
            _disposed = true;
        }
    }
}
