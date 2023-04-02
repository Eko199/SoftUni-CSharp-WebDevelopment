namespace Footballers.DataProcessor;

using System.Globalization;
using System.Text;
using System.Xml.Serialization;

using Newtonsoft.Json;

using Data;
using ExportDto;

public class Serializer
{
    public static string ExportCoachesWithTheirFootballers(FootballersContext context)
    {
        var root = new XmlRootAttribute("Coaches");
        var serializer = new XmlSerializer(typeof(ExportCoachDto[]), root);

        var namespaces = new XmlSerializerNamespaces();
        namespaces.Add(string.Empty, string.Empty);

        var sb = new StringBuilder();
        var writer = new StringWriter(sb);

        serializer.Serialize(writer, context.Coaches
            .Where(c => c.Footballers.Any())
            .OrderByDescending(c => c.Footballers.Count)
            .ThenBy(c => c.Name)
            .ToArray()
            .Select(c => new ExportCoachDto
            {
                FootballersCount = c.Footballers.Count,
                CoachName = c.Name,
                Footballers = c.Footballers
                    .OrderBy(f => f.Name)
                    .ToArray()
                    .Select(f => new ExportFootballerDto
                    {
                        Name = f.Name,
                        Position = f.PositionType.ToString()
                    })
                    .ToArray()
            })
            .ToArray(), namespaces);

        return sb.ToString();
    }

    public static string ExportTeamsWithMostFootballers(FootballersContext context, DateTime date)
        => JsonConvert.SerializeObject(context.Teams
            .Where(t => t.TeamsFootballers.Any(tf => tf.Footballer.ContractStartDate >= date))
            .OrderByDescending(t => t.TeamsFootballers.Count(tf => tf.Footballer.ContractStartDate >= date))
            .ThenBy(t => t.Name)
            .Take(5)
            .ToArray()
            .Select(t => new
            {
                t.Name,
                Footballers = t.TeamsFootballers
                    .Where(tf => tf.Footballer.ContractStartDate >= date)
                    .OrderByDescending(tf => tf.Footballer.ContractEndDate)
                    .ThenBy(tf => tf.Footballer.Name)
                    .ToArray()
                    .Select(tf => new
                    {
                        FootballerName = tf.Footballer.Name,
                        ContractStartDate = tf.Footballer.ContractStartDate.ToString("d", CultureInfo.InvariantCulture),
                        ContractEndDate = tf.Footballer.ContractEndDate.ToString("d", CultureInfo.InvariantCulture),
                        BestSkillType = tf.Footballer.BestSkillType.ToString(),
                        PositionType = tf.Footballer.PositionType.ToString()
                    })
                    .ToArray()
            })
            .ToArray(), Formatting.Indented);
}