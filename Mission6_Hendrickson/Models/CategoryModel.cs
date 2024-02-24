using System.ComponentModel.DataAnnotations;
namespace Mission6_Hendrickson.Models
{
    public class CategoryModel
    {
        [Key]
        [Required]
        public int CategoryId { get; set; }
        [Required]
        public string CategoryName { get; set; }

    }
}
