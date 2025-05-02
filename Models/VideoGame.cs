using System.ComponentModel.DataAnnotations;

namespace FinalProject.Models
{
    public class VideoGame
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Title can't be longer than 100 characters.")]
        [Display(Name = "Game Title")]
        public string Title { get; set; }

        [StringLength(500)]
        [Display(Name = "Game Description")]
        public string Description { get; set; }

        [Range(1000, 3000)]
        [Display(Name = "Year Published")]
        public int YearPublished { get; set; }

        [DataType(DataType.Currency)]
        [Display(Name = "Price ($USD)")]
        public decimal Price { get; set; }

        [Display(Name = "Platform")]
        public int PlatformId { get; set; }

        public Platform Platform { get; set; }
    }
}
