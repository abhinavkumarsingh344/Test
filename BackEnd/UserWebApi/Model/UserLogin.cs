using System.ComponentModel.DataAnnotations;

namespace CourseApplicationWithWebApi.Model
{
    public class UserLogin
    {
        public string Name { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }

    }
}
