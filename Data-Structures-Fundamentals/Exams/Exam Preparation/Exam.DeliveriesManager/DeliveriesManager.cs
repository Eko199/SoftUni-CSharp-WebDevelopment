using System.Collections.Generic;

namespace Exam.DeliveriesManager
{
    using _02.BinarySearchTree;
    using System;
    using System.Linq;

    public class DeliveriesManager : IDeliveriesManager
    {
        private readonly Dictionary<string, List<string>> delivererPackages = new Dictionary<string, List<string>>();
        private readonly BinarySearchTree<Package> packages = new BinarySearchTree<Package>(new PackageWeightReceiverComparer());
        private readonly Dictionary<string, Deliverer> deliverers = new Dictionary<string, Deliverer>();

        public void AddDeliverer(Deliverer deliverer)
        {
            deliverers[deliverer.Id] = deliverer;
            delivererPackages.Add(deliverer.Id, new List<string>());
        }

        public void AddPackage(Package package) => packages.Insert(package);

        public void AssignPackage(Deliverer deliverer, Package package)
        {
            if (!Contains(deliverer) || !Contains(package))
                throw new ArgumentException();

            delivererPackages[deliverer.Id].Add(package.Id);
        }

        public bool Contains(Deliverer deliverer) => deliverers.ContainsKey(deliverer.Id);

        public bool Contains(Package package) => packages.Contains(package);

        public IEnumerable<Deliverer> GetDeliverers() => deliverers.Values;

        public IEnumerable<Deliverer> GetDeliverersOrderedByCountOfPackagesThenByName() 
            => deliverers.Values
                .OrderByDescending(d => delivererPackages[d.Id].Count)
                .ThenBy(d => d.Name);

        public IEnumerable<Package> GetPackages()
        {
            var result = new List<Package>();
            packages.EachInOrder(result.Add);
            return result;
        }

        public IEnumerable<Package> GetPackagesOrderedByWeightThenByReceiver() => GetPackages();

        public IEnumerable<Package> GetUnassignedPackages()
            => GetPackages().Where(p => !delivererPackages.Values.SelectMany(l => l).Contains(p.Id));
    }
}
