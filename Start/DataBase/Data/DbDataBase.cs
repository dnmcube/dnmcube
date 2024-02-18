using Configurate;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Data;
    using Context;

    internal class DbDataBase : DbContext
    {
        private readonly string _connectionString;

        public DbDataBase(IOptions<AppSettings> options)
        {
            _connectionString = options.Value.ConnectionString;
        }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql(_connectionString);
            }
        }

        public DbSet<User> User { get; set; }
        public DbSet<Book> Book { get; set; }
    }
