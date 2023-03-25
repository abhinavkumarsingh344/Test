using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BookingApi.Model
{
    public class Course
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required(ErrorMessage = "Please Enter the name of the Product")]
        [MinLength(2)]
        public string Name { get; set; }
        [Required]
        public float Rating { get; set; }
        [Required]
        [Range(2000, 80000)]
        public double Price { get; set; }
        public string Category { get; set; }

        public string ImagePath { get; set; }
    }
}
