using System.Text;

using MongoDB.Driver;
using MongoDB.Driver.Linq;

using _13_NoSQL_Exercise;

var client = new MongoClient("mongodb://localhost:27017");
IMongoDatabase database = client.GetDatabase("Articles");
var collection = database.GetCollection<ArticlesCollection>("Articles");

Console.WriteLine(await DeleteAndGetNames(collection));

//02. Read
static string GetNames(IMongoCollection<ArticlesCollection> collection) 
    => string.Join(Environment.NewLine, collection
        .AsQueryable()
        .SelectMany(a => a.Articles, 
            (articlesCollection, article) => article.Name)
        .ToArray());

//03. Create new article
static async Task<string> AddArticle(IMongoCollection<ArticlesCollection> collection)
{
    var update = Builders<ArticlesCollection>.Update
        .Push(a => a.Articles, new Article 
        {
            Author = "Steve Jobs",
            Date = "05-05-2005",
            Name = "The story of Apple",
            Rating = 60
        });

    await collection.FindOneAndUpdateAsync(a => true, update);

    Article article = await collection.AsQueryable()
        .SelectMany(a => a.Articles,
            (articlesCollection, article) => article)
        .FirstAsync(a => a.Author == "Steve Jobs");

    var sb = new StringBuilder();

    sb.AppendLine($"Author: {article.Author}");
    sb.AppendLine($"Date: {article.Date}");
    sb.AppendLine($"Name: {article.Name}");
    sb.AppendLine($"Rating: {article.Rating}");

    return sb.ToString().TrimEnd();
}

//04. Update
static async Task UpdateArticles(IMongoCollection<ArticlesCollection> collection)
{
    var update = Builders<ArticlesCollection>.Update
        .Inc("articles.$[].rating", 10);

    await collection.FindOneAndUpdateAsync(a => true, update);
}

//05 Delete
static async Task<string> DeleteAndGetNames(IMongoCollection<ArticlesCollection> collection)
{
    var update = Builders<ArticlesCollection>.Update
        .PullFilter(a => a.Articles, a => a.Rating <= 50);

    await collection.FindOneAndUpdateAsync(a => true, update);

    return GetNames(collection);
}