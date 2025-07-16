using SQLite.CodeFirst;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class DataContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DataContext() : base("name=DataContext")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            var sqliteInitializer = new SqliteCreateDatabaseIfNotExists<DataContext>(modelBuilder);
            Database.SetInitializer(sqliteInitializer);

            base.OnModelCreating(modelBuilder);
        }
    }
}