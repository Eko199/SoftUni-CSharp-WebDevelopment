using System;
using System.Collections.Generic;

namespace NationalElectionSystem
{
    using System.Linq;

    public class ElectionManager : IElectionManager
    {
        private readonly Dictionary<string, (Voter voter, bool hasVoted)> voters = new Dictionary<string, (Voter voter, bool hasVoted)>();
        private readonly Dictionary<string, (Candidate candidate, int votes)> candidates = new Dictionary<string, (Candidate candidate, int votes)>();

        public void AddCandidate(Candidate candidate) => candidates[candidate.Id] = (candidate, 0);

        public void AddVoter(Voter voter) => voters[voter.Id] = (voter, false);

        public bool Contains(Candidate candidate) => candidates.ContainsKey(candidate.Id);

        public bool Contains(Voter voter) => voters.ContainsKey(voter.Id);

        public IEnumerable<Candidate> GetCandidates() => candidates.Values.Select(t => t.candidate);

        public IEnumerable<Voter> GetVoters() => voters.Values.Select(t => t.voter);

        public void Vote(string voterId, string candidateId)
        {
            if (!voters.ContainsKey(voterId) || !candidates.ContainsKey(candidateId) 
                || voters[voterId].voter.Age < 18 || voters[voterId].hasVoted)
            {
                throw new ArgumentException();
            }

            voters[voterId] = (voters[voterId].voter, true);
            candidates[candidateId] = (candidates[candidateId].candidate, candidates[candidateId].votes + 1);
        }

        public int GetVotesForCandidate(string candidateId)
        {
            if (!candidates.ContainsKey(candidateId))
                throw new ArgumentException();

            return candidates[candidateId].votes;
        }

        public IEnumerable<Candidate> GetWinner()
        {
            int maxVotes = candidates.Values.Select(t => t.votes).Max();

            return maxVotes == 0 
                ? null 
                : candidates.Values
                    .Where(t => t.votes == maxVotes)
                    .Select(t => t.candidate);
        }

        public IEnumerable<Candidate> GetCandidatesByParty(string party)
            => GetCandidates().Where(c => c.Party == party);
    }
}