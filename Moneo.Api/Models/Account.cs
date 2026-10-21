using System.Collections.ObjectModel;

namespace Moneo.Api.Models;

    public class Account
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public string Type { get; set; } = "Current";
        public decimal InitialBalance { get; set; } = 0;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public Collection<Operation> Operations { get; set; } = new Collection<Operation>();
        public required string UserId { get; set; }
}


