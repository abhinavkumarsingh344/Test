using Microsoft.EntityFrameworkCore;
using CourseApplicationWithWebApi.Model;

namespace CourseApplicationWithWebApi.Context
{
    public class UserDbContext: DbContext
    {
        public UserDbContext(DbContextOptions<UserDbContext> Context) : base(Context)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserLogin>().HasNoKey();
            //modelBuilder.Entity<PayBill>().HasNoKey();
        }

        public DbSet<User> Users { get; set; }
        public DbSet<CourseApplicationWithWebApi.Model.UserLogin> UserLogin { get; set; }

    }

}
