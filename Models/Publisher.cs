using System.ComponentModel.DataAnnotations;

namespace CSI250Final_GameFilter.Models
{
    public class Publisher
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [StringLength(50)]
        public string City { get; set; }

        [Required]
        [StringLength(30)]
        public string Country { get; set; }

        public ICollection<BoardGame> BoardGames { get; set; }
    }
}
