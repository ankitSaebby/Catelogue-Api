using System;

namespace Catalogue.Dto
{
    public class ItemsDto
    {
        public Guid Id { get; init; }
        public string Name { get; init; }
        public decimal Price { get; init; } 
        public DateTimeOffset createdDate { get; init; }
    }
}