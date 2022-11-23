namespace MilitaryElite.Models.Interfaces
{
    using System.Collections.Generic;

    public interface ILieutenantGeneral
    {
        IReadOnlyCollection<IPrivate> Privates { get; }

        void AddPrivate(IPrivate iPrivate);
    }
}
