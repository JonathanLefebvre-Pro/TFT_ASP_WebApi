using System.ComponentModel.DataAnnotations;

namespace WebApi.Dtos;

public class CreateTaskDto
{
    [Required]
    [StringLength(255, MinimumLength = 5)]
    public string Title { get; set; } = default!;
}
