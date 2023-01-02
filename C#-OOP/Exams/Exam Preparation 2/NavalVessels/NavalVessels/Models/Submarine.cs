namespace NavalVessels.Models
{
    using System;
    
    using Contracts;

    public class Submarine : Vessel, ISubmarine
    {
        private const double InitialArmorThickness = 200;

        public Submarine(string name, double mainWeaponCaliber, double speed) : base(name, mainWeaponCaliber, speed, InitialArmorThickness)
        {
            SubmergeMode = false;
        }

        public bool SubmergeMode { get; private set; }

        public void ToggleSubmergeMode()
        {
            int change = SubmergeMode ? 1 : -1;

            MainWeaponCaliber -= change * 40;
            Speed += change * 4;

            SubmergeMode = !SubmergeMode;
        }

        public override string ToString() => base.ToString() + Environment.NewLine + " *Submerge mode: " + (SubmergeMode ? "ON" : "OFF");
    }
}