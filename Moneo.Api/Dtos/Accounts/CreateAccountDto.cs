using System.ComponentModel.DataAnnotations;

namespace Moneo.Api.Dtos.Accounts
{
    public record CreateAccountDto(
    [Required][MaxLength(100)] string Name,
    [Required][MaxLength(50)] string Type,
    [Required] decimal InitialBalance
    );

}
