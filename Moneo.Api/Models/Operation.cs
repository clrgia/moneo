namespace Moneo.Api.Models;

    public class Operation
    {
        public Guid Id { get; set; }
        public required string Label { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public Guid AccountId { get; set; }
        public Account Account { get; set; } = null!;
        public Guid? CategoryId { get; set; }
        public Category Category { get; set; }
}
