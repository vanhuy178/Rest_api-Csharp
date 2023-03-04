using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Catalog.Repositoty;
using Catalog.Entities;
using System;
namespace Catalog.Controllers
{
    [ApiController]
    [Route("items")]
    public class ItemsController : ControllerBase
    {
        private readonly InMemItemsRepository repositoty;

        public ItemsController()
        {
            repositoty = new InMemItemsRepository();
        }

        // how to defined the routes 
        // GET /items
        [HttpGet]
        public IEnumerable<Item> GetItems()
        {
            var items = repositoty.GetItems();
            return items;
        }

        // GET item/id
        [HttpGet("{id}")]
        public ActionResult<Item> GetItem(Guid id)
        {
            var item = repositoty.GetItem(id);

            if (item == null)
            {
                return NotFound();
            }
            return item;
        }
    }
}