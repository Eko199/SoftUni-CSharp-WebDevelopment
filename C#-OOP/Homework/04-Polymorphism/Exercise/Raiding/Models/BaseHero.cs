namespace Raiding.Models
{
    public abstract class BaseHero
    {
        protected BaseHero(string name)
        {
            Name = name;
        }

        public string Name { get; }
        public abstract int Power { get; }

        public virtual string CastAbility() => $"{GetType().Name} - {Name}";
    }
}
