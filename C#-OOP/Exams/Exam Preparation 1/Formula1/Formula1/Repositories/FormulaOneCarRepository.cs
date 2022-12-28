namespace Formula1.Repositories
{
    using System.Collections.Generic;
    using System.Linq;

    using Contracts;
    using Models.Contracts;

    public class FormulaOneCarRepository : IRepository<IFormulaOneCar>
    {
        private readonly List<IFormulaOneCar> models;

        public FormulaOneCarRepository()
        {
            models = new List<IFormulaOneCar>();
        }

        public IReadOnlyCollection<IFormulaOneCar> Models => models.AsReadOnly();

        public void Add(IFormulaOneCar car) => models.Add(car);

        public bool Remove(IFormulaOneCar car) => models.Remove(car);

        public IFormulaOneCar FindByName(string model) => models.FirstOrDefault(c => c.Model == model);
    }
}