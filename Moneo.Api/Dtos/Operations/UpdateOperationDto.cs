using System.ComponentModel.DataAnnotations;

namespace Moneo.Api.Dtos.Operations
{
    public record UpdateOperationDto
    (
        [Required][MaxLength(255)] string Label,
        [Required] decimal? Amount,
        [Required] DateTime? Date,
        Guid? CategoryId
    );
}
