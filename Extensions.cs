using Catalog.Dtos;
using Catalog.Entities;
namespace Catalog
{
    public static class Extensions
    {
        public static ItemDto AsDto(this Item item)
        {
            return new ItemDto
            {
                Id = item.Id,
                Name = item.Name,
                Price = item.Price,
                CreatedDate = item.CreatedDate
            };
        }

        public static OrderDto OsDto(this Order order)
        {
            return new OrderDto
            {
                Id = order.Id,
                OrderName = order.OrderName,
                OrdePrice = order.OrdePrice,
                CreatedDate = order.CreatedDate
            };
        }
    }
}