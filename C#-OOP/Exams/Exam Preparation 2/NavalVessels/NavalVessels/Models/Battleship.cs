namespace NavalVessels.Models
{
    using System;

    using Contracts;

    public class Battleship : Vessel, IBattleship
    {
        private const double InitialArmorThickness = 300;

        public Battleship(string name, double mainWeaponCaliber, double speed) : base(name, mainWeaponCaliber, speed, InitialArmorThickness)
        {
            SonarMode = false;
        }

        public bool SonarMode { get; private set; }

        public void ToggleSonarMode()
        {
            int change = SonarMode ? 1 : -1;

            MainWeaponCaliber -= change * 40;
            Speed += change * 5;

            SonarMode = !SonarMode;
        }

        public override string ToString() => base.ToString() + Environment.NewLine + " *Sonar mode: " + (SonarMode ? "ON" : "OFF");
    }
}