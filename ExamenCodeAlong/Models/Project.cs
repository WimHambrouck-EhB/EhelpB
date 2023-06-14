using ExamenCodeAlong.Attributes;
using System.ComponentModel.DataAnnotations;

namespace ExamenCodeAlong.Models
{
    public class Project
    {
        [Key]
        [ProjectNaamValidation]
        public string ProjectNaam { get; set; } = string.Empty;

        public Status Status { get; set; }

        public decimal HuidigBudget { get; set; }

        public ICollection<PersoneelslidProject> PersoneelslidProjecten { get; set; } = new List<PersoneelslidProject>();


    }
}
