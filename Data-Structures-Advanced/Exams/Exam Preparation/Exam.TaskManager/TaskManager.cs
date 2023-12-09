using System;
using System.Collections.Generic;

namespace Exam.TaskManager
{
    using System.Linq;

    public class TaskManager : ITaskManager
    {
        private readonly IDictionary<string, Task> tasks = new Dictionary<string, Task>();
        private readonly LinkedList<Task> pendingTasks = new LinkedList<Task>();
        private readonly ISet<Task> executedTasks = new HashSet<Task>();

        public void AddTask(Task task)
        {
            tasks[task.Id] = task;
            pendingTasks.AddLast(task);
        }

        public bool Contains(Task task) => tasks.ContainsKey(task.Id);

        public void DeleteTask(string taskId)
        {
            Task task = GetTask(taskId);

            if (!executedTasks.Remove(task))
            {
                pendingTasks.Remove(task);
            }

            tasks.Remove(taskId);
        }

        public Task ExecuteTask()
        {
            if (!pendingTasks.Any())
            {
                throw new ArgumentException();
            }

            Task task = pendingTasks.First!.Value;
            pendingTasks.Remove(task);
            executedTasks.Add(task);

            return task;
        }

        public IEnumerable<Task> GetAllTasksOrderedByEETThenByName()
            => tasks.Values
                .OrderByDescending(t => t.EstimatedExecutionTime)
                .ThenBy(t => t.Name.Length);

        public IEnumerable<Task> GetDomainTasks(string domain)
        {
            var domainTasks = pendingTasks.Where(t => t.Domain == domain);

            if (!domainTasks.Any())
            {
                throw new ArgumentException();
            }

            return domainTasks;
        }

        public Task GetTask(string taskId)
        {
            if (!tasks.ContainsKey(taskId))
            {
                throw new ArgumentException();
            }

            return tasks[taskId];
        }

        public IEnumerable<Task> GetTasksInEETRange(int lowerBound, int upperBound) 
            => pendingTasks
                .Where(t => t.EstimatedExecutionTime >= lowerBound && t.EstimatedExecutionTime <= upperBound);

        public void RescheduleTask(string taskId)
        {
            Task task = GetTask(taskId);

            if (!executedTasks.Contains(task))
            {
                throw new ArgumentException();
            }

            pendingTasks.AddLast(task);
            executedTasks.Remove(task);
        }

        public int Size() => pendingTasks.Count;
    }
}
