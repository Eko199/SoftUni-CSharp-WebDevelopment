namespace Boardgames.DataProcessor;

using System.Text;
using System.Xml.Serialization;

using Newtonsoft.Json;

using Data;
using ExportDto;

public class Serializer
{
    public static string ExportCreatorsWithTheirBoardgames(BoardgamesContext context)
    {
        var root = new XmlRootAttribute("Creators");
        var serializer = new XmlSerializer(typeof(ExportCreatorDto[]), root);

        var namespaces = new XmlSerializerNamespaces();
        namespaces.Add(string.Empty, string.Empty);

        var sb = new StringBuilder();
        using var writer = new StringWriter(sb);

        serializer.Serialize(writer, context.Creators
            .Where(c => c.Boardgames.Any())
            .ToArray()
            .Select(c => new ExportCreatorDto
            {
                BoardgamesCount = c.Boardgames.Count,
                Name = $"{c.FirstName} {c.LastName}",
                Boardgames = c.Boardgames
                    .Select(b => new ExportBoardgameDto
                    {
                        Name = b.Name,
                        YearPublished = b.YearPublished
                    })
                    .OrderBy(b => b.Name)
                    .ToArray()
            })
            .OrderByDescending(c => c.BoardgamesCount)
            .ThenBy(c => c.Name)
            .ToArray(), namespaces);

        return sb.ToString();
    }

    public static string ExportSellersWithMostBoardgames(BoardgamesContext context, int year, double rating) 
        => JsonConvert.SerializeObject(context.Sellers
            .Where(s => s.BoardgamesSellers
                .Any(bs => bs.Boardgame.YearPublished >= year && bs.Boardgame.Rating <= rating))
            .OrderByDescending(s => s.BoardgamesSellers
                .Count(bs => bs.Boardgame.YearPublished >= year && bs.Boardgame.Rating <= rating))
            .ThenBy(s => s.Name)
            .Take(5)
            .ToArray()
            .Select(s => new
            {
                s.Name,
                s.Website,
                Boardgames = s.BoardgamesSellers
                    .Where(bs => bs.Boardgame.YearPublished >= year && bs.Boardgame.Rating <= rating)
                    .OrderByDescending(bs => bs.Boardgame.Rating)
                    .ThenBy(bs => bs.Boardgame.Name)
                    .Select(bs => new
                    {
                        bs.Boardgame.Name,
                        bs.Boardgame.Rating,
                        bs.Boardgame.Mechanics,
                        Category = bs.Boardgame.CategoryType.ToString()
                    })
                    .ToArray()
            })
            .ToArray(), Formatting.Indented);
}