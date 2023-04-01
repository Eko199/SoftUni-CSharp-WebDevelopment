namespace Boardgames.DataProcessor;

using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Xml.Serialization;

using Newtonsoft.Json;

using Data;
using Data.Models;
using Data.Models.Enums;
using ImportDto;

public class Deserializer
{
    private const string ErrorMessage = "Invalid data!";

    private const string SuccessfullyImportedCreator
        = "Successfully imported creator – {0} {1} with {2} boardgames.";

    private const string SuccessfullyImportedSeller
        = "Successfully imported seller - {0} with {1} boardgames.";

    public static string ImportCreators(BoardgamesContext context, string xmlString)
    {
        var root = new XmlRootAttribute("Creators");
        var serializer = new XmlSerializer(typeof(ImportCreatorDto[]), root);

        using var reader = new StringReader(xmlString);
        var creatorDtos = (ImportCreatorDto[]) serializer.Deserialize(reader)!;

        var creators = new List<Creator>(creatorDtos.Length);
        var sb = new StringBuilder();

        foreach (ImportCreatorDto creatorDto in creatorDtos)
        {
            if (!IsValid(creatorDto))
            {
                sb.AppendLine(ErrorMessage);
                continue;
            }

            var creator = new Creator
            {
                FirstName = creatorDto.FirstName,
                LastName = creatorDto.LastName,
            };

            if (creatorDto.Boardgames != null)
            {
                var boardgames = new HashSet<Boardgame>(creatorDto.Boardgames.Length);

                foreach (ImportBoardgameDto boardgameDto in creatorDto.Boardgames)
                {
                    if (!IsValid(boardgameDto))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    boardgames.Add(new Boardgame 
                    {
                        Name = boardgameDto.Name,
                        Rating = boardgameDto.Rating,
                        YearPublished = boardgameDto.YearPublished,
                        CategoryType = (CategoryType) boardgameDto.CategoryType,
                        Mechanics = boardgameDto.Mechanics
                    });
                }

                creator.Boardgames = boardgames;
            }

            creators.Add(creator);
            sb.AppendLine(string.Format(SuccessfullyImportedCreator, creator.FirstName, creator.LastName, creator.Boardgames.Count));
        }

        context.Creators.AddRange(creators);
        context.SaveChanges();

        return sb.ToString().TrimEnd();
    }

    public static string ImportSellers(BoardgamesContext context, string jsonString)
    {
        ImportSellerDto[] sellerDtos = JsonConvert.DeserializeObject<ImportSellerDto[]>(jsonString)!;

        var sellers = new List<Seller>(sellerDtos.Length);
        var sb = new StringBuilder();

        foreach (ImportSellerDto sellerDto in sellerDtos)
        {
            if (!IsValid(sellerDto))
            {
                sb.AppendLine(ErrorMessage);
                continue;
            }

            var sellerBoardgames = new HashSet<BoardgameSeller>();

            if (sellerDto.Boardgames != null)
            {
                foreach (int boardgameId in sellerDto.Boardgames.Distinct())
                {
                    if (!context.Boardgames.Any(b => b.Id == boardgameId))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    sellerBoardgames.Add(new BoardgameSeller
                    {
                        BoardgameId = boardgameId
                    });
                }
            }

            sellers.Add(new Seller
            {
                Name = sellerDto.Name,
                Address = sellerDto.Address,
                Country = sellerDto.Country,
                Website = sellerDto.Website,
                BoardgamesSellers = sellerBoardgames
            });

            sb.AppendLine(string.Format(SuccessfullyImportedSeller, sellerDto.Name, sellerBoardgames.Count));
        }

        context.Sellers.AddRange(sellers);
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