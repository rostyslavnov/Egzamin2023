using System.ComponentModel.DataAnnotations;

namespace Egzamin2023.Models;

public class Note
{
    [Display(Name = "Tytuł")]
    [StringLength(maximumLength: 50, MinimumLength = 3)]
    public string Title { get; set; }
    
    [StringLength(maximumLength:2000), Display(Name = "Treść")]
    public string Content { get; set; }
    [Display(Name = "Data ważności")]
    public DateTime Deadline { get; set; }
}