using System.Collections.ObjectModel;

namespace Moneo.Api.Models;

    public class Category
    {
        public Guid Id { get; set; }
        public required string Label { get; set; }
        public Collection<Operation> Operations { get; set; } = new Collection<Operation>();
        public required string UserId { get; set; }
}

