using System.Collections.Generic;
using Catalogue.Entities;
using Catalogue.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Catalogue.Controller
{
    [ApiController]
    [Route("items")]
    public class ItemsController{
        private readonly InMemItemsRepositories repository;
        
        public ItemsController(){
            repository=new InMemItemsRepositories();
        }

        //get  /items
        [HttpGet]
        public IEnumerable<Item> GetItems(){
            var items=repository.GetItems();
            return items;
        }

        [HttpGet]
        public ActionResult<Item> GetItem(Guid id){
            
        } 

    }
}