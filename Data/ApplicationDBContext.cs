using Microsoft.EntityFrameworkCore;
using StudentCRUD.Models.Entities;

namespace StudentCRUD.Data
{
    public class ApplicationDBContext:DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options):base(options)
        {
        }

        public DbSet<Student> Students { get; set; }

    }
}
