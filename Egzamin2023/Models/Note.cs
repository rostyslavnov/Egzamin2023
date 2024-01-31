using System.ComponentModel.DataAnnotations;

namespace Egzamin2023.Models;

public class Note
{
    [Display(Name = "Tytuł")]
    [StringLength(maximumLength: 20, MinimumLength = 3)]
    public string Title { get; set; }
    [StringLength(maximumLength: 2000, MinimumLength = 10)]
    [Display(Name = "Treść")]
    public string Content { get; set; }
    [DataType(DataType.DateTime)]
    [Display(Name = "Data ważności")]
    public DateTime Deadline { get; set; }
}