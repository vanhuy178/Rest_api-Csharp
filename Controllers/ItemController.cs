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
    }
}