using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Catalog.Repository;
using Catalog.Entities;
using System;
using System.Linq;
using Catalog.Repositories;
using Catalog.Dtos;
using Catalog;
namespace Catalog.Controllers
{
    [ApiController]
    [Route("items")]
    public class ItemsController : ControllerBase
    {

        private readonly IItemsRepository repositoty;

        public ItemsController(IItemsRepository repositoty)
        {
            this.repositoty = repositoty;
        }

        // how to defined the routes 
        // GET /items
        [HttpGet]
        public IEnumerable<ItemDto> GetItems()
        {
            var items = repositoty.GetItems().Select(item => item.AsDto());
            return items;
        }

        // GET item/id
        [HttpGet("{id}")]
        public ActionResult<ItemDto> GetItem(Guid id)
        {
            var item = repositoty.GetItem(id);

            if (item == null)
            {
                return NotFound();
            }
            return item.AsDto();
        }

        // POST /items
        [HttpPost]
        public ActionResult<ItemDto> CreateItem(CreateItemDto itemDto)
        {
            Item item = new()
            {
                Id = Guid.NewGuid(),
                Name = itemDto.Name,
                Price = itemDto.Price,
                CreatedDate = DateTimeOffset.UtcNow
            };
            repositoty.CreateItem(item);
            return CreatedAtAction(nameof(GetItem), new { id = item.Id }, item.AsDto());
        }

        // PUT /items/id 
        [HttpPut("{id}")]
        public ActionResult UpdateItem(Guid id, UpdateItemDto itemDto)
        {
            var existingItem = repositoty.GetItem(id);

            if (existingItem is null)
            {
                return NotFound();
            }

            Item updateItem = existingItem with
            { // with expression
                Name = itemDto.Name,
                Price = itemDto.Price
            };
            repositoty.UpdatedItem(updateItem);
            return NoContent();
        }

        // DELETE /items/id
        [HttpDelete("{id}")]
        public ActionResult DeleteItem(Guid id)
        {
            var existingItem = repositoty.GetItem(id);

            if (existingItem is null)
            {
                return NotFound();
            }

            repositoty.DeleteItem(id);
            return NoContent();
        }
    }
}