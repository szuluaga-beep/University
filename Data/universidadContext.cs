using Microsoft.EntityFrameworkCore;

namespace universidad.Data
{
    public class universidadContext : DbContext
    {
        public universidadContext(DbContextOptions<universidadContext> options)
            : base(options)
        {
        }

        public DbSet<universidad.Models.Student> Student { get; set; } = default!;
        public DbSet<universidad.Models.Course> Course { get; set; } = default!;
    }
}