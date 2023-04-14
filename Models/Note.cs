using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace webapi_Francisco_1033769977.Models
{
    public class Note
    {
        [Key]
        public Guid IdNote {get; set;}


        [ForeignKey("IdStudent")]
        public Guid IdStudent {get; set;}

        [ForeignKey("IdCourse")]
        public Guid IdCourse {get; set;}

        [Required]
        public int note {get; set;}

        [MaxLength(150)]
        public string Description {get; set;}

        public Note() {
        Description = "";
    }


    }
} 