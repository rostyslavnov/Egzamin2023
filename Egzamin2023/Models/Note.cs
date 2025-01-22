// Novytskyi Rostyslav 15204
using System.ComponentModel.DataAnnotations;

namespace Egzamin2023.Models
{
    public class Note
    {
        [Required]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Title must be between 3 and 20 characters.")]
        public string Title { get; set; }

        [Required]
        [StringLength(2000, MinimumLength = 10, ErrorMessage = "Content must be between 10 and 2000 characters.")]
        public string Content { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        [Display(Name = "Deadline")]
        public DateTime Deadline { get; set; }
    }
}