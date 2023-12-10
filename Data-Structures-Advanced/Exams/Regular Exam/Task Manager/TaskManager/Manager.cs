using System;
using System.Collections.Generic;

namespace TaskManager
{
    using System.Linq;

    public class Manager : IManager
    {
        private readonly IDictionary<string, Task> tasks = new Dictionary<string, Task>();
        private readonly IDictionary<string, HashSet<string>> dependencies = new Dictionary<string, HashSet<string>>();
        private readonly IDictionary<string, HashSet<string>> dependents = new Dictionary<string, HashSet<string>>();

        public void AddDependency(string taskId, string dependentTaskId)
        {
            if (!Contains(taskId) || !Contains(dependentTaskId)
                || dependentTaskId == taskId 
                || GetDependencies(dependentTaskId).Any(dependent => dependent.Id == taskId))
            {
                throw new ArgumentException();
            }

            dependencies[taskId].Add(dependentTaskId);
            dependents[dependentTaskId].Add(taskId);
        }

        public void AddTask(Task task)
        {
            if (Contains(task.Id))
            {
                throw new ArgumentException();
            }

            tasks.Add(task.Id, task);
            dependencies.Add(task.Id, new HashSet<string>());
            dependents.Add(task.Id, new HashSet<string>());
        }

        public bool Contains(string taskId) => tasks.ContainsKey(taskId);

        public Task Get(string taskId)
        {
            if (!Contains(taskId))
            {
                throw new ArgumentException();
            }

            return tasks[taskId];
        }

        public IEnumerable<Task> GetDependencies(string taskId)
        {
            var result = new List<Task>();

            if (Contains(taskId))
            {
                foreach (string dependencyId in dependencies[taskId])
                {
                    result.Add(tasks[dependencyId]);
                    result.AddRange(GetDependencies(dependencyId));
                }
            }

            return result;
        }

        public IEnumerable<Task> GetDependents(string taskId)
        {
            var result = new List<Task>();

            if (Contains(taskId))
            {
                foreach (string dependentId in dependents[taskId])
                {
                    result.Add(tasks[dependentId]);
                    result.AddRange(GetDependents(dependentId));
                }
            }

            return result;
        }

        public void RemoveDependency(string taskId, string dependentTaskId)
        {
            if (!Contains(taskId) || !Contains(dependentTaskId)
                || !dependencies[taskId].Contains(dependentTaskId) 
                || !dependents[dependentTaskId].Contains(taskId))
            {
                throw new ArgumentException();
            }

            dependencies[taskId].Remove(dependentTaskId);
            dependents[dependentTaskId].Remove(taskId);
        }

        public void RemoveTask(string taskId)
        {
            if (!Contains(taskId))
            {
                throw new ArgumentException();
            }

            foreach (string dependentId in dependents[taskId])
            {
                dependencies[dependentId].Remove(taskId);
            }

            dependencies.Remove(taskId);
            dependents.Remove(taskId);
            tasks.Remove(taskId);
        }

        public int Size() => tasks.Count;
    }
}