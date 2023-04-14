using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace webapi_Francisco_1033769977.Models
{
    public class Course   
    {
        [Key]
        public Guid IdCourse { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(150)]
        public string Description { get; set; }

        //[ForeignKey("IdTeacher")]
        public Guid IdTeacher { get; set; }

        Course()
        {
            Name = "";
            Description = "";
        }

    }
}