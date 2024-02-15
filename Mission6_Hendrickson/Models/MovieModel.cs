using System.ComponentModel.DataAnnotations;
namespace Mission6_Hendrickson.Models
{
    public class MovieModel
    {
        [Key]
        [Required]
        public int MovieId { get; set; }
        [Required]

        public string MovieCategory { get; set; }
        [Required]
        public string MovieTitle { get; set;}
        [Required]
        public string Year { get; set;}
        [Required]
        public string Director { get; set;}
        [Required]
        public string Rating { get; set;}  

        public bool? MovieEdit { get; set;}
        public string? LentTo { get; set;}
        [StringLength(25, ErrorMessage = "Notes should be limited to 25 characters.")]
        public string? Notes { get; set;}

            
    }
}
