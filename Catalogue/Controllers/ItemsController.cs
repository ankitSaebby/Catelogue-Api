using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Catalogue.Dto;
using Catalogue.Entities;
using Catalogue.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Catalogue.Controller
{

    // GET - /items

    [ApiController]
    [Route("[Controller]")] 
    public class ItemsController : ControllerBase
    {
        private readonly IItemsRepositories repository;
        
        public ItemsController(IItemsRepositories repository){
            this.repository=repository;
        }

        //get  /items
        [HttpGet]
        public IEnumerable<ItemsDto> GetItems(){
            var items=repository.GetItems().Select(item => item.AsDto());
            return items;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<ItemsDto> GetItem(Guid id){
            var item= repository.GetItem(id);
            if(item == null){
                 return NotFound();
            }
            return item.AsDto();
        }

        //POST /items

        [HttpPost]
        public ActionResult<ItemsDto> CreateItem(CreateItemDto item){
            Item itemO=new(){
                Id=Guid.NewGuid(),
                Name=item.Name,
                Price=item.Price,
                createdDate=DateTimeOffset.UtcNow
            };
            repository.CreateItem(itemO);
            return CreatedAtAction(nameof(GetItem),new {id= itemO.Id} , itemO.AsDto());
        }


        //Put /items/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateItem(Guid id, UpdateItemDto itemDto){
           var existing=repository.GetItem(id);
           if(existing is null)
           {
               return NotFound();
           }
            Item UpdatedItem=existing with{
                Name=itemDto.Name,
                Price=itemDto.Price
            };
            repository.upadateItem(UpdatedItem);
            return NoContent();
        }

    }
}