namespace Moneo.Api.Dtos.Operations;

public record OperationDto(
    Guid Id,
    string Label,
    decimal Amount,
    DateTime Date,
    Guid AccountId,
    Guid? CategoryId,
    string? CategoryLabel
    );