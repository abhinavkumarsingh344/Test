using CourseApplication.Context;
using CourseApplication.Model;
using Microsoft.EntityFrameworkCore;

namespace CourseApplication.Repository
{
    public class CourseRepository : ICourserepository
    {
        CourseDbContext _courseDbContext;
        public CourseRepository(CourseDbContext courseDbContext)
        {
            _courseDbContext = courseDbContext;
        }

        public void AddCourse(Course course)
        {
            _courseDbContext.Courses.Add(course);
            _courseDbContext.SaveChanges();
        }

        public bool Delete(int id)
        {
            _courseDbContext.Courses.Remove(GetCourseById(id));
            return _courseDbContext.SaveChanges()==1 ? false:true;
        }

        public Course Details(int id)
        {

            return _courseDbContext.Courses.Where(x => x.Id == id).FirstOrDefault();

        }

        public int EditCourse(Course course)
        {
            _courseDbContext.Entry(course).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            return _courseDbContext.SaveChanges();
        }

        public List<Course> GetAllCourses()
        {
            return _courseDbContext.Courses.ToList();
        }

        public Course GetCourseById(int id)
        {
            return _courseDbContext.Courses.Where(p => p.Id == id).FirstOrDefault();
        }

        public Course GetCourseByName(string name)
        {
            return _courseDbContext.Courses.Where(p => p.Name == name).FirstOrDefault();
        }
    }
}
