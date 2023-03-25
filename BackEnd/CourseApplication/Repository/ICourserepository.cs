using CourseApplication.Model;

namespace CourseApplication.Repository
{
    public interface ICourserepository
    {
        void AddCourse(Course course);
        bool Delete(int id);
        Course Details(int id);
   
        int EditCourse(Course course);
        List<Course> GetAllCourses();
        Course GetCourseById(int id);
        Course GetCourseByName(string name);
    }
}
