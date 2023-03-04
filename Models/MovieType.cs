using System.ComponentModel.DataAnnotations;

namespace Movie.Models
{
    public class MovieType
    {
        [Key]
        public int Id { get; set; }
        public string GenreName { get; set; } = default!;
        public string? Description { get; set; }
        public List<Movief> Moviefs { get; set; } =new List<Movief>();
    }
}
