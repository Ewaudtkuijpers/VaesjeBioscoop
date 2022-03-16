using System.ComponentModel.DataAnnotations;

namespace VaesjeBioscoop.Models
{
    public class Person
    {
        [Required]
        public string Firstname { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Phone { get; set; }

        [Required]
        public string Message { get; set; }

    }
}
