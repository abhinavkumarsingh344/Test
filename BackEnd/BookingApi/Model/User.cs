using System.ComponentModel.DataAnnotations;

namespace BookingApi.Model
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        [DataType(DataType.Password)]
        // [RegularExpression("",ErrorMessage ="password not correct")]
        public string Password { get; set; }
        public string Location { get; set; }
        public string ImagePath { get; set; }
        public string Role { get; set; } = "Admin";
    }
}
