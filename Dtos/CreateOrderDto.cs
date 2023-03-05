using System.ComponentModel.DataAnnotations;
namespace Catalog.Dtos
{
    public record CreateOrderDto
    {
        [Required]
        public string OrderName { get; init; }
        [Required]
        [Range(1, 1500)]
        public decimal OrdePrice { get; init; }
    }
}