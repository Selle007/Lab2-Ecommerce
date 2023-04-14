using Microsoft.EntityFrameworkCore;


namespace backend.Data
{
    public class MSSQLContext : DbContext
    {
        public MSSQLContext(DbContextOptions<MSSQLContext> options)
            : base(options)
        {
        }

        //public DbSet<User> Users { get; set; }

        // Add more DbSet properties for other MSSQL entities as needed
    }
}
