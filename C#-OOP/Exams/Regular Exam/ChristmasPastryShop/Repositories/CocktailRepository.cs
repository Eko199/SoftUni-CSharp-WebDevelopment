namespace ChristmasPastryShop.Repositories
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;

    using Contracts;
    using Models.Cocktails.Contracts;

    public class CocktailRepository : IRepository<ICocktail>
    {
        private readonly IList<ICocktail> models;

        public CocktailRepository()
        {
            models = new List<ICocktail>();
        }

        public IReadOnlyCollection<ICocktail> Models => new ReadOnlyCollection<ICocktail>(models);

        public void AddModel(ICocktail cocktail) => models.Add(cocktail);
    }
}