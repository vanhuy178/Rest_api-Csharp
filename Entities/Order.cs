using System;
namespace Catalog.Entities
{
    public record Order
    {
        public int Id { get; init; }
        public string OrderName { get; init; }
        public decimal OrdePrice { get; init; }
        public DateTimeOffset CreatedDate { get; init; }

    }
}