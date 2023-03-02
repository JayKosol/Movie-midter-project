using System.ComponentModel.DataAnnotations.Schema;

namespace Movie.Models
{
    public class Movief
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Duration { get; set; }
        public string SubTitle { get; set; }
        public DateTime ReleseDate { get; set; }
        public string Language { get; set; }
        //relation ship
        [ForeignKey("MovieType")]
        public int Genre_RefID { get; set; }
        public MovieType MovieType { get; set; }
    }
}
