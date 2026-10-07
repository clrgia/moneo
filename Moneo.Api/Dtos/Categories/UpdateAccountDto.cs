using System.ComponentModel.DataAnnotations;

namespace Moneo.Api.Dtos.Categories
{
    public record UpdateCategoryDto(
    [Required][MaxLength(50)] string Label
    );

}
