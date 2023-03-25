using CourseApplication.Model;
using CourseApplication.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CourseApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        readonly ICourseService _courseService;
        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;

        }
        [Route("GetAllCourses")]
        [HttpGet]
        public ActionResult GetAllCourses()
        {
            List<Course> allcourses = _courseService.GetAllCourses();
            return Ok(allcourses);
        }
        [Route("AddCourse")]
        [HttpPost]
        
        public ActionResult AddCourse(Course course)
        {
           
              bool addCoursestatus=  _courseService.AddCourse(course);
            return Created("api/created", addCoursestatus);
        }
        [Route("DeleteCourse")]
        [HttpDelete]
        public ActionResult Delete(int id)
        {
           bool deletestatus= _courseService.Delete(id);
            return Ok(deletestatus);
        }
        [Route("Details")]
        [HttpGet]
        public ActionResult Details(int id)
        {
            Course course = _courseService.Details(id);
            return Ok(course);
        }
       
      
        [HttpGet]
        public ActionResult GetCoursebyId(int id)
        {
            Course course = _courseService.GetCourseById(id);
            return Ok(course);
        }
        [HttpPut]
        [Route("EditUser/{id:int}")]
        public ActionResult EditCourse(int id, Course course)
        {
            bool editUserStatus = _courseService.EditCourse(id, course);
            return Ok(editUserStatus);
        }
    }
    }   

