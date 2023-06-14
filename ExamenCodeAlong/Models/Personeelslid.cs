using System.ComponentModel.DataAnnotations;

namespace ExamenCodeAlong.Models
{
    public class Personeelslid
    {
        public int Id { get; set; }
        [Required] 
        public string Username { get; set; } = string.Empty;
        [Required] 
        public string Voornaam { get; set; } = string.Empty;
        [Required] 
        public string Achternaam { get; set; } = string.Empty;
        [Required]
        [DataType(DataType.Password)]
        public string Wachtwoord { get; set; } = string.Empty;
        
        [Required]
        [DataType(DataType.Password)]
        [Compare(nameof(Wachtwoord))]
        public string WachtwoordControle { get; set; } = string.Empty;

        public int VestigingId { get; set; }
        public Vestiging? Vestiging { get; set; }

        public ICollection<PersoneelslidProject> PersoneelslidProjecten { get; set; } = new List<PersoneelslidProject>();

    }
}
