using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace SourcingService.Domain.SeedWorks;

public abstract class BaseEntity
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string ID { get; set; } = ObjectId.GenerateNewId().ToString();
}
