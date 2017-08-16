using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTask.DAL.EF;
using TestTask.DAL.Infrastructure;
using TestTask.DAL.Interfaces;
using TestTask.DAL.Interfaces.Repositories;
using TestTask.Models;

namespace TestTask.DAL.Repositories
{
    public class BookRepository : Repository<Book>, IRepository<Book>, IBookRepository
    {
        public BookRepository(DataContext context) : base(context)
        {
        }
    }
}
