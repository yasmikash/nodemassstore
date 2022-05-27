using System.Data;
using System.Runtime.CompilerServices;
using System.Linq;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NodemassStore.Entities;
using NodemassStore.Repositories;
using NodemassStore.Dtos;

namespace NodemassStore.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class ItemsController : ControllerBase
    {
        private readonly IItemRepository _itemRepository;
        public ItemsController(IItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }

        [HttpGet]
        public IEnumerable<ItemDto> GetItems()
        {
            return _itemRepository.GetItems().Select(item => item.AsDto());
        }

        [HttpGet("{id}")]
        public ActionResult<ItemDto> GetItem(Guid id)
        {
            var item = _itemRepository.GetItem(id);
            if (item == null)
            {
                return NotFound();
            }
            return item.AsDto();
        }

        [HttpPost]
        public ActionResult<ItemDto> CreateItem(CreateItemDto itemDto)
        {
            var newItem = new Item
            {
                Id = Guid.NewGuid(),
                Name = itemDto.Name,
                Price = itemDto.Price,
                CreatedDate = DateTimeOffset.UtcNow
            };
            return _itemRepository.CreateItem(newItem).AsDto();
        }

        [HttpPut("{id}")]
        public ActionResult<ItemDto> UpdateItem(Guid id, UpdateItemDto itemDto)
        {
            var items = (List<Item>)_itemRepository.GetItems();
            var itemToUpdate = items.Find(item => item.Id == id);
            var newItem = new Item
            {
                Id = id,
                Name = itemDto.Name,
                Price = itemDto.Price,
                CreatedDate = itemToUpdate.CreatedDate
            };
            return _itemRepository.UpdateItem(newItem).AsDto();
        }

        [HttpDelete("{id}")]
        public ActionResult<bool> DeleteItem(Guid id)
        {
            return _itemRepository.DeleteItem(id);
        }

    }
}