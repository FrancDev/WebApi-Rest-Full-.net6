using System.ComponentModel.DataAnnotations;
namespace webapi_Francisco_1033769977.Models
{

    public class Person
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }

        [Required]
        [MaxLength(30)]
        public string Address { get; set; }

        public int Celphone { get; set; }

        [Required]
        [MaxLength(50)]
        public string EmailAddress { get; set; }

        [MaxLength(150)]
        public string Description { get; set; }

        public Person()
        {
            /*Name = "";
            LastName = "";
            Address = "";
            EmailAddress = "";
            Description = "";*/
        }
    }
}
