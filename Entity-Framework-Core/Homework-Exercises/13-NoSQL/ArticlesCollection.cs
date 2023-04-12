namespace _13_NoSQL_Exercise;

using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

public class ArticlesCollection
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; } = null!;

    [BsonElement("articles")]
    public List<Article> Articles { get; set; } = null!;
}