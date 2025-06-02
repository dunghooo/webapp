using crud.Models;
using Microsoft.EntityFrameworkCore;

namespace crud.Services
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Product> products { get; set; }

    }
}
