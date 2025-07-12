using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using universidad.Models;

namespace universidad.Data
{
    public class universidadContext : DbContext
    {
        public universidadContext (DbContextOptions<universidadContext> options)
            : base(options)
        {
        }

        public DbSet<universidad.Models.Student> Student { get; set; } = default!;
    }
}
