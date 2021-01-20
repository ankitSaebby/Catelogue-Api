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
    }
}