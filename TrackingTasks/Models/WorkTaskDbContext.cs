using Microsoft.EntityFrameworkCore;

namespace TrackingTasks.Models
{
    public class WorkTaskDbContext : DbContext
    {

        public WorkTaskDbContext()
        {
        }

        public WorkTaskDbContext(DbContextOptions<WorkTaskDbContext> options) : base(options)
        {
        }

        public DbSet<WorkTask> WorkTask { get; set;}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=EBA00021\\SQLEXPRESS; Initial Catalog=workTaskDB; Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
        }

    }
}
