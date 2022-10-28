using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Renovators
{
    public class Catalog
    {
        private List<Renovator> renovators;

        public Catalog(string name, int neededRenovators, string project)
        {
            renovators = new List<Renovator>();
            Name = name;
            NeededRenovators = neededRenovators;
            Project = project;
        }

        public string Name { get; }
        public int NeededRenovators { get; }
        public string Project { get; }
        public int Count => renovators.Count;

        public string AddRenovator(Renovator renovator)
        {
            if (string.IsNullOrEmpty(renovator.Name) || string.IsNullOrEmpty(renovator.Type))
                return "Invalid renovator's information.";

            if (Count >= NeededRenovators)
                return "Renovators are no more needed.";

            if (renovator.Rate > 350)
                return "Invalid renovator's rate.";

            renovators.Add(renovator);
            return $"Successfully added {renovator.Name} to the catalog.";
        }

        public bool RemoveRenovator(string name)
            => renovators.RemoveAll(r => r.Name == name) > 0;

        public int RemoveRenovatorBySpecialty(string type)
            => renovators.RemoveAll(r => r.Type == type);

        public Renovator HireRenovator(string name)
        {
            Renovator renovator = renovators.SingleOrDefault(r => r.Name == name);

            if (renovator != null)
                renovator.Hired = true;

            return renovator;
        }

        public List<Renovator> PayRenovators(int days)
            => renovators.Where(r => r.Days >= days).ToList();

        public string Report()
            => $"Renovators available for Project {Project}:{Environment.NewLine}" +
               string.Join(Environment.NewLine, renovators.Where(r => !r.Hired && !r.Paid));
    }
}
