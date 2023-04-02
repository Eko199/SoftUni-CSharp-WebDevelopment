namespace Footballers.DataProcessor;

using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;
using System.Globalization;
using System.Text;
using System.Xml.Serialization;

using Data;
using Data.Models;
using Data.Models.Enums;
using ImportDto;
using Newtonsoft.Json;

public class Deserializer
{
    private const string ErrorMessage = "Invalid data!";

    private const string SuccessfullyImportedCoach
        = "Successfully imported coach - {0} with {1} footballers.";

    private const string SuccessfullyImportedTeam
        = "Successfully imported team - {0} with {1} footballers.";

    public static string ImportCoaches(FootballersContext context, string xmlString)
    {
        var root = new XmlRootAttribute("Coaches");
        var serializer = new XmlSerializer(typeof(ImportCoachDto[]), root);

        using var reader = new StringReader(xmlString);
        var coachDtos = (ImportCoachDto[])serializer.Deserialize(reader)!;

        var coaches = new List<Coach>(coachDtos.Length);
        var sb = new StringBuilder();

        foreach (ImportCoachDto coachDto in coachDtos)
        {
            if (!IsValid(coachDto))
            {
                sb.AppendLine(ErrorMessage);
                continue;
            }

            var footballers = new HashSet<Footballer>();

            if (coachDto.Footballers != null)
            {
                foreach (ImportFootballerDto footballerDto in coachDto.Footballers)
                {
                    if (!IsValid(footballerDto))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    var footballer = new Footballer
                    {
                        Name = footballerDto.Name,
                        ContractStartDate = DateTime.ParseExact(footballerDto.ContractStartDate, "dd/MM/yyyy",
                            CultureInfo.InvariantCulture),
                        ContractEndDate = DateTime.ParseExact(footballerDto.ContractEndDate, "dd/MM/yyyy",
                            CultureInfo.InvariantCulture),
                        BestSkillType = (BestSkillType)footballerDto.BestSkillType,
                        PositionType = (PositionType)footballerDto.PositionType
                    };

                    if (footballer.ContractEndDate < footballer.ContractStartDate)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    footballers.Add(footballer);
                }
            }
            
            coaches.Add(new Coach
            {
                Name = coachDto.Name,
                Nationality = coachDto.Nationality,
                Footballers = footballers
            });

            sb.AppendLine(string.Format(SuccessfullyImportedCoach, coachDto.Name, footballers.Count));
        }

        context.Coaches.AddRange(coaches);
        context.SaveChanges();

        return sb.ToString().TrimEnd();
    }

    public static string ImportTeams(FootballersContext context, string jsonString)
    {
        ImportTeamDto[] teamDtos = JsonConvert.DeserializeObject<ImportTeamDto[]>(jsonString)!;

        var teams = new List<Team>(teamDtos.Length);
        var sb = new StringBuilder();

        foreach (ImportTeamDto teamDto in teamDtos)
        {
            if (!IsValid(teamDto) || int.Parse(teamDto.Trophies) == 0)
            {
                sb.AppendLine(ErrorMessage);
                continue;
            }

            var teamFootballers = new HashSet<TeamFootballer>();

            if (teamDto.Footballers != null)
            {
                foreach (int footballerId in teamDto.Footballers.Distinct())
                {
                    if (!context.Footballers.Any(f => f.Id == footballerId))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    teamFootballers.Add(new TeamFootballer
                    {
                        FootballerId = footballerId
                    });
                }
            }
            
            teams.Add(new Team
            {
                Name = teamDto.Name,
                Nationality = teamDto.Nationality,
                Trophies = int.Parse(teamDto.Trophies),
                TeamsFootballers = teamFootballers
            });

            sb.AppendLine(string.Format(SuccessfullyImportedTeam, teamDto.Name, teamFootballers.Count));
        }

        context.Teams.AddRange(teams);
        context.SaveChanges();

        return sb.ToString().TrimEnd();
    }

    private static bool IsValid(object dto)
    {
        var validationContext = new ValidationContext(dto);
        var validationResult = new List<ValidationResult>();

        return Validator.TryValidateObject(dto, validationContext, validationResult, true);
    }
}