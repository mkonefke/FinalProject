using System.ComponentModel.DataAnnotations;

namespace FinalProject.Models
{
    public class Platform
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Platform Name")]
        public string Name { get; set; }

        public ICollection<VideoGame> VideoGames { get; set; }
    }
}
