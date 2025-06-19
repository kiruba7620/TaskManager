using Microsoft.EntityFrameworkCore;
using TaskManager.Model;

namespace TaskManager.Data
{
    public class DataBaseContext:DbContext
    {
        public DataBaseContext(DbContextOptions options):base(options)
        {
        }
        public DbSet<Tasks> Tasks { get; set; }
    }
}
