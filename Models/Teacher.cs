using System.ComponentModel.DataAnnotations;
namespace webapi_Francisco_1033769977.Models
{
    public class Teacher : Person
{
    [Key]
    public Guid IdTeacher { get; set; }

    [Required]
    [MaxLength(50)]
    public string Specialty { get; set; }

    public virtual ICollection<Course> Courses { get; set; }

    public Teacher()
    {
        Specialty = "";
        Courses = new HashSet<Course>();
    }
}
}
