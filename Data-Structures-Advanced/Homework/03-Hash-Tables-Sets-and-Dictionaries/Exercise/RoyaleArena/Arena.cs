namespace RoyaleArena
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public class Arena : IArena
    {
        private readonly IDictionary<int, BattleCard> cards = new Dictionary<int, BattleCard>();

        public int Count => cards.Count;

        public void Add(BattleCard card) => cards.Add(card.Id, card);

        public void ChangeCardType(int id, CardType type) => GetById(id).Type = type;

        public bool Contains(BattleCard card) => cards.ContainsKey(card.Id);

        public IEnumerable<BattleCard> FindFirstLeastSwag(int n)
        {
            if (Count < n)
            {
                throw new InvalidOperationException();
            }

            return cards.Values
                .OrderBy(c => c.Swag)
                .ThenBy(c => c.Id)
                .Take(n);
        }

        public IEnumerable<BattleCard> GetAllInSwagRange(double lo, double hi)
            => cards.Values
                .Where(c => c.Swag >= lo && c.Swag <= hi)
                .OrderBy(c => c.Swag);

        public IEnumerable<BattleCard> GetByCardType(CardType type)
        {
            var result = cards.Values.Where(c => c.Type == type);

            if (!result.Any())
            {
                throw new InvalidOperationException();
            }

            return result
                .OrderByDescending(c => c.Damage)
                .ThenBy(c => c.Id);
        }

        public IEnumerable<BattleCard> GetByCardTypeAndMaximumDamage(CardType type, double damage)
        {
            var result = GetByCardType(type).Where(c => c.Damage <= damage);

            if (!result.Any())
            {
                throw new InvalidOperationException();
            }

            return result;
        }

        public BattleCard GetById(int id)
        {
            if (!cards.ContainsKey(id))
            {
                throw new InvalidOperationException();
            }

            return cards[id];
        }

        public IEnumerable<BattleCard> GetByNameAndSwagRange(string name, double lo, double hi)
        {
            var result = GetByNameOrderedBySwagDescending(name)
                .Where(c => c.Swag >= lo && c.Swag < hi);

            if (!result.Any())
            {
                throw new InvalidOperationException();
            }

            return result;
        }

        public IEnumerable<BattleCard> GetByNameOrderedBySwagDescending(string name)
        {
            var result = cards.Values.Where(c => c.Name == name);

            if (!result.Any())
            {
                throw new InvalidOperationException();
            }

            return result.OrderByDescending(c => c.Swag)
                .ThenBy(c => c.Id);
        }

        public IEnumerable<BattleCard> GetByTypeAndDamageRangeOrderedByDamageThenById(CardType type, int lo, int hi)
            => GetByCardType(type).Where(c => c.Damage >= lo && c.Damage <= hi);

        public IEnumerator<BattleCard> GetEnumerator() => cards.Values.GetEnumerator();

        public void RemoveById(int id)
        {
            if (!cards.Remove(id))
            {
                throw new InvalidOperationException();
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}