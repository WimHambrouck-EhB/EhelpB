using System.ComponentModel.DataAnnotations;

namespace ExamenCodeAlong.Models
{
    public class Vestiging
    {
        public int Id { get; set; }

        [Required]
        public string Naam { get; set; } = string.Empty;
    }
}
