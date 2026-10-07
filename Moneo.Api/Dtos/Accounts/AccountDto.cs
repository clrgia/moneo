namespace Moneo.Api.Dtos.Accounts
{
    public record AccountDto(
    Guid Id,
    string Name,
    string Type,
    decimal InitialBalance,
    DateTime CreatedAt,
    decimal CurrentBalance
    );

}
