namespace NavalVessels.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using Contracts;
    using Utilities.Messages;

    public abstract class Vessel : IVessel
    {
        private readonly double defaultArmorThickness;
        private string name;
        private ICaptain captain;

        protected Vessel(string name, double mainWeaponCaliber, double speed, double armorThickness)
        {
            Name = name;
            MainWeaponCaliber = mainWeaponCaliber;
            Speed = speed;
            defaultArmorThickness = ArmorThickness = armorThickness;
            Targets = new List<string>();
        }

        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentNullException(ExceptionMessages.InvalidVesselName);
                
                name = value;
            }
        }

        public ICaptain Captain
        {
            get => captain;
            set => captain = value ?? throw new NullReferenceException(ExceptionMessages.InvalidCaptainToVessel);
        }

        public double ArmorThickness { get; set; }
        public double MainWeaponCaliber { get; protected set; }
        public double Speed { get; protected set; }
        public ICollection<string> Targets { get; }

        public void Attack(IVessel target)
        {
            if (target == null)
                throw new NullReferenceException(ExceptionMessages.InvalidTarget);

            target.ArmorThickness = Math.Max(0, target.ArmorThickness - MainWeaponCaliber);
            Targets.Add(target.Name);

            Captain.IncreaseCombatExperience();
            target.Captain.IncreaseCombatExperience();
        }

        public void RepairVessel()
        {
            if (ArmorThickness < defaultArmorThickness) 
                ArmorThickness = defaultArmorThickness;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"- {Name}")
                .AppendLine($" *Type: {GetType().Name}")
                .AppendLine($" *Armor thickness: {ArmorThickness}")
                .AppendLine($" *Main weapon caliber: {MainWeaponCaliber}")
                .AppendLine($" *Speed: {Speed} knots")
                .AppendLine($" *Targets: {(Targets.Any() ? string.Join(", ", Targets) : "None")}");

            return sb.ToString().Trim();
        }
    }
}