namespace ChristmasPastryShop.Repositories
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;

    using Contracts;
    using Models.Delicacies.Contracts;

    public class DelicacyRepository : IRepository<IDelicacy>
    {
        private readonly IList<IDelicacy> models;

        public DelicacyRepository()
        {
            models = new List<IDelicacy>();
        }

        public IReadOnlyCollection<IDelicacy> Models => new ReadOnlyCollection<IDelicacy>(models);

        public void AddModel(IDelicacy delicacy) => models.Add(delicacy);
    }
}