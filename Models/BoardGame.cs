using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CSI250Final_GameFilter.Models
{
    public class BoardGame
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Title { get; set; }

        [Required]
        [Range(1, 30)]
        public int PlayerCount { get; set; }

        [Required]
        [Range(1900, 2023)]
        public int ReleaseYear { get; set; }

        [Required]
        [Range(1, 10)]
        public int Complexity { get; set; }

        [Required]
        [Precision(7, 2)]
        public decimal Cost { get; set; }

        

        [ForeignKey("Publisher")]
        public int PublisherId { get; set; }
        [ForeignKey("Genre")]
        public int GenreId { get; set; }

        public Publisher Publisher { get; set; }
        public Genre Genre { get; set; }
    }
}
