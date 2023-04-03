using Microsoft.EntityFrameworkCore;
using RegistrationApllication.Modal;

namespace RegistrationApllication.Data
{
    public class UserDbContext : DbContext
    {
        public UserDbContext(DbContextOptions<UserDbContext> options) : base(options)
        {

        }


        public DbSet<LeaveDetails> LeaveDetail { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           
            modelBuilder.Entity<LeaveDetails>().ToTable("leavedetails");


        }
    }
}
