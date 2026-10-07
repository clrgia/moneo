using System.ComponentModel.DataAnnotations;

namespace Moneo.Api.Dtos.Categories
{
    public record CreateCategoryDto(
    [Required][MaxLength(50)] string Label
    );

}
