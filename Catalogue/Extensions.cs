using Catalogue.Dto;
using Catalogue.Entities;

namespace Catalogue
{
    public static class Extensions{
        public static ItemsDto AsDto(this Item item){
            return new ItemsDto{
                Id= item.Id,
                Name= item.Name,
                Price= item.Price,
                createdDate= item.createdDate
            };
        }
    }
}