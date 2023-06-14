namespace ExamenCodeAlong.Models
{
    public class KoppelpersoneelViewModel
    {
        public Project? Project { get; set; }

        public Dictionary<Personeelslid, bool> Koppelingen { get; set; } = new Dictionary<Personeelslid, bool>();
    }
}
