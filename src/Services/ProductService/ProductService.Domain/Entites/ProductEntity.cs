using MongoDB.Bson.Serialization.Attributes;
using ProductService.Domain.Attributes;
using ProductService.Domain.SeedWorks;

namespace ProductService.Domain.Entites
{
    [BsonCollection("ProductCollection")]
    public class ProductEntity : BaseEntity , IAggregateRoot
    {
        [BsonElement("Name")]
        public string Name { get; set; }

        public string Category { get; set; }

        public string Summary { get; set; }

        public string Description { get; set; }

        public string ImageFile { get; set; }

        public decimal Price { get; set; }

        public ProductEntity(string name, string category, string summary, string description, string imageFile, decimal price)
        {
            Name = name;
            Category = category;
            Summary = summary;
            Description = description;
            ImageFile = imageFile;
            Price = price;
        }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public ProductEntity()
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        {
        }

        public ProductEntity CopyWith
            (
                 string? name = null,
                 string? category = null,
                 string? summary = null,
                 string? description = null,
                 string? imageFile = null,
                 decimal? price = null
            )
        {
            ProductEntity productEntity = new(
                       name: name ?? Name,
                       category: category ?? Category,
                       summary: summary ?? Summary,
                       description: description ?? Description,
                       imageFile: imageFile ?? ImageFile,
                       price: price ?? Price
                );
            productEntity.ID = ID;
            productEntity.CreatedDate = CreatedDate;
            
            return productEntity;
        }
    }
}
