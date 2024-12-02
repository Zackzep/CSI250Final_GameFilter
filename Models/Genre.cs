using System.ComponentModel.DataAnnotations;

namespace CSI250Final_GameFilter.Models
{
    public class Genre
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(30)]
        public string Name { get; set; }

        public ICollection<BoardGame> BoardGames { get; set; }
    }
}
