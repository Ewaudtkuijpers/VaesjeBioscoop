using System.ComponentModel.DataAnnotations;

namespace VaesjeBioscoop.Models
{
    public class Person
    {
        public string Firstname { get; set; }

        public string LastName { get; set; }

        [Required]
        public string Email { get; set; }

        public string Message { get; set; }

    }
}
