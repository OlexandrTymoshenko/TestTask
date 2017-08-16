using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTask.Models;

namespace TestTask.DAL.EF
{
    public class DataContext : DbContext
    {
        public DbSet<Book> Books { get; set; }

        static DataContext()
        {
            Database.SetInitializer<DataContext>(new DropCreateDatabaseIfModelChanges<DataContext>());
        }
        public DataContext(string connectionString)
            : base(connectionString)
        {
        }
    }
}
