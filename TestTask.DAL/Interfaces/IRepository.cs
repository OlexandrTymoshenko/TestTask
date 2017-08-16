using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTask.Models.Base;

namespace TestTask.DAL.Interfaces
{
    public interface IRepository<T> where T : Entity
    {
        IEnumerable<T> GetAll();
        T Get(Guid id);
        IEnumerable<T> Find(Func<T, Boolean> predicate);
        T Create(T item);
        void Update(T item);
        void Delete(Guid id);
    }
}
