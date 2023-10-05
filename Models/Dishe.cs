using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRUDelicious.Models
{
    public class Dishe
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DishId { get; set; }

        [Required(ErrorMessage = "Name is required!")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Chef is required!")]
        public string Chef { get; set; }

        [Required(ErrorMessage = "Tastiness is required!")]
        [Range(1, 5, ErrorMessage = "Tastiness has gone out of the allowed range.")]
        public int Tastiness { get; set; }

        [Required(ErrorMessage = "Calories is required!")]
        [Range(1, int.MaxValue, ErrorMessage = "Calories are out of the allowed range")]
        public int Calories { get; set; }

        [Required(ErrorMessage = "Description is required!")]
        [DataType(DataType.Text)]
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
