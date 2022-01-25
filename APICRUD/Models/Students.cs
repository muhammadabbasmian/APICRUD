using System.ComponentModel.DataAnnotations;

namespace APICRUD.Models
{
    public class Student
    {
        public int Id { get; set; }
        [Required]
        public string StudentName { get; set; }

        public string Email { get; set; }

        public string Dob { get; set; }

        public string Notes { get; set; }

    }
}
