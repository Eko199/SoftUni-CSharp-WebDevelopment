namespace _13_NoSQL_Exercise;

using MongoDB.Bson.Serialization.Attributes;

public class Article
{
    [BsonElement("author")]
    public string Author { get; set; } = null!;

    [BsonElement("date")] 
    public string Date { get; set; } = null!;

    [BsonElement("name")]
    public string Name { get; set; } = null!;

    [BsonElement("rating")]
    public int Rating { get; set; }
}