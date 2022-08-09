using Microsoft.EntityFrameworkCore;

namespace pmAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<StatusHos> StatusesHos { get; set; }
    }
}
