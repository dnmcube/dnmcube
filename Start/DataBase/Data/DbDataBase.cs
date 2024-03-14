using Configurate;
using Data.Configur;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Data;
    using Context;

    internal class DbDataBase : DbContext
    {
        public DbSet<UserDto> User { get; set; }
        public DbSet<BookDto> Book { get; set; }
        
        private readonly string _connectionString;

        public DbDataBase(IOptions<AppSettings> options)
        {
            _connectionString = options.Value.ConnectionString;
        }
        public DbDataBase()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql(_connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new BookConfigure());
            modelBuilder.ApplyConfiguration(new UserConfugure());
        }
    }
