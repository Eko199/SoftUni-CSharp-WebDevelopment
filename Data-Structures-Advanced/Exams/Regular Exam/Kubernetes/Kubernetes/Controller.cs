using System;
using System.Collections.Generic;

namespace Kubernetes
{
    using System.Linq;

    public class Controller : IController
    {
        private readonly IDictionary<string, Pod> pods = new Dictionary<string, Pod>();

        public bool Contains(string podId) => pods.ContainsKey(podId);

        public void Deploy(Pod pod) => pods[pod.Id] = pod;

        public Pod GetPod(string podId)
        {
            if (!Contains(podId))
            {
                throw new ArgumentException();
            }

            return pods[podId];
        }

        public IEnumerable<Pod> GetPodsBetweenPort(int lowerBound, int upperBound)
            => pods.Values.Where(p => p.Port >= lowerBound && p.Port <= upperBound);

        public IEnumerable<Pod> GetPodsInNamespace(string @namespace) 
            => pods.Values.Where(p => p.Namespace == @namespace);

        public IEnumerable<Pod> GetPodsOrderedByPortThenByName()
            => pods.Values.OrderByDescending(p => p.Port)
                .ThenBy(p => p.Namespace);

        public int Size() => pods.Count;

        public void Uninstall(string podId)
        {
            if (!pods.Remove(podId))
            {
                throw new ArgumentException();
            }
        }

        public void Upgrade(Pod pod) => pods[pod.Id] = pod;
    }
}