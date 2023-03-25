using CourseApplication.Model;
using CourseApplication.Repository;

namespace CourseApplication.Service
{
    public class CourseService : ICourseService
    {
        readonly ICourserepository _courseRepository;
        //Constructor DI
        public CourseService(ICourserepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        public bool AddCourse(Course course)
        {
            var courseExistStatus = _courseRepository.GetCourseByName(course.Name);
            if (courseExistStatus == null)
            {
                _courseRepository.AddCourse(course);
            }
            return true; 
        }

    public bool Delete(int id)
        {
            var courseExists = _courseRepository.GetCourseById(id);
            if (courseExists != null)
            {
                return _courseRepository.Delete(id);
            }
            else
            {
                return true;
            }
        }


        public Course Details(int id)
        {
            return _courseRepository.Details(id);
        }

        

        public bool EditCourse(int id, Course course)
        {
            course.Id = id;
            int userEditstatus = _courseRepository.EditCourse(course);
            if (userEditstatus == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<Course> GetAllCourses()
        {
            return _courseRepository.GetAllCourses();
        }

        public Course GetCourseById(int id)
        {
            return _courseRepository.GetCourseById(id);
        }
    }
}
