namespace ExamenCodeAlong.Models
{
    public class PersoneelslidProject
    {
        public int Id { get; set; }
        public int PersoneelslidId { get; set; }
        public Personeelslid Personeelslid { get; set; } = null!;

        public string ProjectId { get; set; } = string.Empty;
        public Project Project { get; set; } = null!;
    }
}