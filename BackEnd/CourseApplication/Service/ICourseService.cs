using CourseApplication.Model;

namespace CourseApplication.Service
{
    public interface ICourseService
    {
        bool AddCourse(Course course);
        bool Delete(int id);
        Course Details(int id);
     
        bool EditCourse(int id, Course course);
        List<Course> GetAllCourses();
        Course GetCourseById(int id);
    }
}
