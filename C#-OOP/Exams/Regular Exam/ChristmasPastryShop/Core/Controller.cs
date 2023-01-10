using ChristmasPastryShop.Core.Contracts;

namespace ChristmasPastryShop.Core
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using Models.Booths;
    using Models.Booths.Contracts;
    using Models.Cocktails;
    using Models.Cocktails.Contracts;
    using Models.Delicacies;
    using Repositories;
    using Utilities.Messages;

    public class Controller : IController
    {
        private readonly BoothRepository booths;
        private readonly ICollection<string> delicacyTypes, cocktailTypes;

        public Controller()
        {
            booths = new BoothRepository();
            delicacyTypes = new HashSet<string> { "Gingerbread", "Stolen" };
            cocktailTypes = new HashSet<string> { "Hibernation", "MulledWine" };
        }

        public string AddBooth(int capacity)
        {
            int boothId = booths.Models.Count + 1;
            booths.AddModel(new Booth(boothId, capacity));

            return string.Format(OutputMessages.NewBoothAdded, boothId, capacity);
        }

        public string AddDelicacy(int boothId, string delicacyTypeName, string delicacyName)
        {
            if (!delicacyTypes.Contains(delicacyTypeName))
                return string.Format(OutputMessages.InvalidDelicacyType, delicacyTypeName);

            IBooth booth = booths.Models.Single(b => b.BoothId == boothId);

            if (booth.DelicacyMenu.Models.Any(d => d.Name == delicacyName))
                return string.Format(OutputMessages.DelicacyAlreadyAdded, delicacyName);

            booth.DelicacyMenu.AddModel(delicacyTypeName switch
            {
                "Gingerbread" => new Gingerbread(delicacyName),
                "Stolen" => new Stolen(delicacyName)
            });

            return string.Format(OutputMessages.NewDelicacyAdded, delicacyTypeName, delicacyName);
        }

        public string AddCocktail(int boothId, string cocktailTypeName, string cocktailName, string size)
        {
            if (!cocktailTypes.Contains(cocktailTypeName))
                return string.Format(OutputMessages.InvalidCocktailType, cocktailTypeName);

            if (!new HashSet<string> { "Small", "Middle", "Large" }.Contains(size))
                return string.Format(OutputMessages.InvalidCocktailSize, size);

            IBooth booth = booths.Models.Single(b => b.BoothId == boothId);

            if (booth.CocktailMenu.Models.Any(c => c.Name == cocktailName && c.Size == size))
                return string.Format(OutputMessages.CocktailAlreadyAdded, size, cocktailName);
            
            booth.CocktailMenu.AddModel(cocktailTypeName switch
            {
                "MulledWine" => new MulledWine(cocktailName, size),
                "Hibernation" => new Hibernation(cocktailName, size)
            });

            return string.Format(OutputMessages.NewCocktailAdded, size, cocktailName, cocktailTypeName);
        }

        public string ReserveBooth(int countOfPeople)
        {
            IBooth booth = booths.Models
                .Where(b => !b.IsReserved && b.Capacity >= countOfPeople)
                .OrderBy(b => b.Capacity)
                .ThenByDescending(b => b.BoothId)
                .FirstOrDefault();

            if (booth == null)
                return string.Format(OutputMessages.NoAvailableBooth, countOfPeople);

            booth.ChangeStatus();
            return string.Format(OutputMessages.BoothReservedSuccessfully, booth.BoothId, countOfPeople);
        }

        public string TryOrder(int boothId, string order)
        {
            IBooth booth = booths.Models.Single(b => b.BoothId == boothId);
            string[] orderArgs = order.Split('/');

            string itemTypeName = orderArgs[0];
            string itemName = orderArgs[1];
            int pieces = int.Parse(orderArgs[2]);

            bool isDelicacy = delicacyTypes.Contains(itemTypeName);
            bool isCocktail = cocktailTypes.Contains(itemTypeName);

            if (!isDelicacy && !isCocktail)
                return string.Format(OutputMessages.NotRecognizedType, itemTypeName);

            if ((isCocktail && booth.CocktailMenu.Models.All(c => c.Name != itemName))
                || (isDelicacy && booth.DelicacyMenu.Models.All(d => d.Name != itemName)))
                return string.Format(OutputMessages.NotRecognizedItemName, itemTypeName, itemName);

            if (isCocktail)
            {
                ICocktail cocktail = booth.CocktailMenu
                    .Models
                    .SingleOrDefault(c => c.Name == itemName && c.Size == orderArgs[3]);

                if (cocktail == null)
                    return string.Format(OutputMessages.CocktailStillNotAdded, orderArgs[3], itemName);

                booth.UpdateCurrentBill(cocktail.Price * pieces);
            }
            else
            {
                booth.UpdateCurrentBill(booth.DelicacyMenu.Models.Single(d => d.Name == itemName).Price * pieces);
            }

            return string.Format(OutputMessages.SuccessfullyOrdered, boothId, pieces, itemName);
        }

        public string LeaveBooth(int boothId)
        {
            IBooth booth = booths.Models.Single(b => b.BoothId == boothId);

            double currentBill = booth.CurrentBill;
            booth.Charge();
            if (booth.IsReserved)
                booth.ChangeStatus();

            return new StringBuilder()
                .AppendLine(string.Format(OutputMessages.GetBill, currentBill.ToString("F2")))
                .AppendLine(string.Format(OutputMessages.BoothIsAvailable, boothId))
                .ToString()
                .Trim();
        }

        public string BoothReport(int boothId)
            => booths.Models.Single(b => b.BoothId == boothId).ToString();
    }
}