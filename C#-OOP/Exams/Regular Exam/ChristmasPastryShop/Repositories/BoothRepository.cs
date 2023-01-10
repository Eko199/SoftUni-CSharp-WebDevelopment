namespace ChristmasPastryShop.Repositories
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;

    using Contracts;
    using Models.Booths.Contracts;

    public class BoothRepository : IRepository<IBooth>
    {
        private readonly IList<IBooth> models;

        public BoothRepository()
        {
            models = new List<IBooth>();
        }

        public IReadOnlyCollection<IBooth> Models => new ReadOnlyCollection<IBooth>(models);

        public void AddModel(IBooth booth) => models.Add(booth);
    }
}