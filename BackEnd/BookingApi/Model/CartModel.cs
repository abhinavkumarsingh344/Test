using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BookingApi.Model
{
    public class CartModel
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CartId { get; set; }
        //associated with User
        public int Id { get; set; }
        public int CourseId { get; set; }
        public int Quantity { get; set; }
        public DateTime DateCreated { get; set; }
        [ForeignKey("Id")]
        public virtual User user { get; set; }
        [ForeignKey("CourseId")]
        public virtual Course course { get; set; }



    }
}
