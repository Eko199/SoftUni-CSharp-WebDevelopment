using System;
using System.Collections.Generic;

namespace GitHubSystem
{
    using System.Linq;

    public class GitHubManager : IGitHubManager
    {
        private readonly Dictionary<string, User> users = new Dictionary<string, User>();
        private readonly Dictionary<string, (Repository repo, int forks)> repositories = new Dictionary<string, (Repository repo, int forks)>();
        private readonly Dictionary<string, List<Commit>> commits = new Dictionary<string, List<Commit>>();

        public void Create(User user) => users[user.Id] = user;

        public void Create(Repository repository)
        {
            repositories[repository.Id] = (repository, 0);
            commits[repository.Id] = new List<Commit>();
        }

        public bool Contains(User user) => users.ContainsKey(user.Id);

        public bool Contains(Repository repository) => repositories.ContainsKey(repository.Id);

        public void CommitChanges(Commit commit)
        {
            if (!users.ContainsKey(commit.UserId) || !repositories.ContainsKey(commit.RepositoryId))
                throw new ArgumentException();

            commits[commit.RepositoryId].Add(commit);
        }

        public Repository ForkRepository(string repositoryId, string userId)
        {
            if (!repositories.ContainsKey(repositoryId) || !users.ContainsKey(userId))
                throw new ArgumentException();

            var newRepo = new Repository
            {
                Id = repositoryId + "(1)",
                Name = repositories[repositoryId].repo.Name,
                OwnerId = userId,
                Stars = 0
            };

            Create(newRepo);
            commits[newRepo.Id].AddRange(commits[repositoryId]);
            repositories[repositoryId] = (repositories[repositoryId].repo, repositories[repositoryId].forks + 1);

            return newRepo;
        }

        public IEnumerable<Commit> GetCommitsForRepository(string repositoryId) => commits[repositoryId];

        public IEnumerable<Repository> GetRepositoriesByOwner(string userId)
            => repositories.Values
                .Select(t => t.repo)
                .Where(r => r.OwnerId == userId);

        public IEnumerable<Repository> GetMostForkedRepositories()
            => repositories.Values
                .OrderByDescending(t => t.forks)
                .Select(t => t.repo);

        public IEnumerable<Repository> GetRepositoriesOrderedByCommitsInDescending()
            => repositories.Values
                .Select(t => t.repo)
                .OrderByDescending(r => commits[r.Id].Count);
    }
}