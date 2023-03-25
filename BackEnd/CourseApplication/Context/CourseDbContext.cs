using CourseApplication.Model;
using Microsoft.EntityFrameworkCore;

namespace CourseApplication.Context
{
    public class CourseDbContext:DbContext
    {
        public CourseDbContext(DbContextOptions<CourseDbContext> Context) : base(Context)
        {

        }
        public DbSet<Course> Courses { get; set; }

    }
}
