using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APICRUD.Models
{
    public class Touches
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [MaxLength]
        public byte[] pic { get; set; }

        public string description { get; set; }

        public int ListTypeId { get; set; }

    }
}
