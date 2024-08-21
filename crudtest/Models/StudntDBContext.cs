using Microsoft.EntityFrameworkCore;

namespace crudtest.Models
{
    public class StudntDBContext:DbContext
    {
        public StudntDBContext(DbContextOptions<StudntDBContext>options):base(options) { }

        public DbSet<Studnt> Studnt { get; set; }
    }

    
}
