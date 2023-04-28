namespace backend.Data;
using Microsoft.EntityFrameworkCore;


    public class MssqlDBContext : DbContext
    {
        public MssqlDBContext(DbContextOptions<MssqlDBContext> options)
            : base(options)
        {
        }

        //public DbSet<User> Users { get; set; }

        // Add more DbSet properties for other MSSQL entities as needed
    }

