namespace NavalVessels.Core
{
    using System.Collections.Generic;
    using System.Linq;

    using Contracts;
    using Models;
    using Models.Contracts;
    using Repositories;
    using Repositories.Contracts;
    using Utilities.Messages;

    public class Controller : IController
    {
        private readonly IRepository<IVessel> vessels;
        private readonly ICollection<ICaptain> captains;

        public Controller()
        {
            vessels = new VesselRepository();
            captains = new HashSet<ICaptain>();
        }

        public string HireCaptain(string fullName)
        {
            if (captains.Any(c => c.FullName == fullName))
                return string.Format(OutputMessages.CaptainIsAlreadyHired, fullName);

            captains.Add(new Captain(fullName));
            return string.Format(OutputMessages.SuccessfullyAddedCaptain, fullName);
        }

        public string ProduceVessel(string name, string vesselType, double mainWeaponCaliber, double speed)
        {
            IVessel existingVessel = vessels.FindByName(name);

            if (existingVessel != null)
                return string.Format(OutputMessages.VesselIsAlreadyManufactured, existingVessel.GetType().Name, name);

            switch (vesselType)
            {
                case "Battleship":
                    vessels.Add(new Battleship(name, mainWeaponCaliber, speed));
                    break;
                case "Submarine":
                    vessels.Add(new Submarine(name, mainWeaponCaliber, speed));
                    break;
                default:
                    return OutputMessages.InvalidVesselType;
            }

            return string.Format(OutputMessages.SuccessfullyCreateVessel, vesselType, name, mainWeaponCaliber,
                speed);
        }

        public string AssignCaptain(string selectedCaptainName, string selectedVesselName)
        {
            ICaptain captain = captains.SingleOrDefault(c => c.FullName == selectedCaptainName);

            if (captain == null)
                return string.Format(OutputMessages.CaptainNotFound, selectedCaptainName);

            IVessel vessel = vessels.FindByName(selectedVesselName);

            if (vessel == null)
                return string.Format(OutputMessages.VesselNotFound, selectedVesselName);

            if (vessel.Captain != null)
                return string.Format(OutputMessages.VesselOccupied, selectedVesselName);

            captain.AddVessel(vessel);
            vessel.Captain = captain;

            return string.Format(OutputMessages.SuccessfullyAssignCaptain, selectedCaptainName, selectedVesselName);
        }

        public string CaptainReport(string captainFullName) => captains.Single(c => c.FullName == captainFullName).Report();

        public string VesselReport(string vesselName) => vessels.FindByName(vesselName)?.ToString();

        public string ToggleSpecialMode(string vesselName)
        {
            IVessel vessel = vessels.FindByName(vesselName);

            switch (vessel)
            {
                case null:
                    return string.Format(OutputMessages.VesselNotFound, vesselName);
                case Battleship battleship:
                    battleship.ToggleSonarMode();
                    return string.Format(OutputMessages.ToggleBattleshipSonarMode, vesselName);
                case Submarine submarine:
                    submarine.ToggleSubmergeMode();
                    return string.Format(OutputMessages.ToggleSubmarineSubmergeMode, vesselName);
            }

            return string.Format(OutputMessages.VesselNotFound, vesselName);
        }

        public string ServiceVessel(string vesselName)
        {
            IVessel vessel = vessels.FindByName(vesselName);

            if (vessel == null)
                return string.Format(OutputMessages.VesselNotFound, vesselName);

            vessel.RepairVessel();
            return string.Format(OutputMessages.SuccessfullyRepairVessel, vesselName);
        }

        public string AttackVessels(string attackingVesselName, string defendingVesselName)
        {
            IVessel attackingVessel = vessels.FindByName(attackingVesselName);

            if (attackingVessel == null)
                return string.Format(OutputMessages.VesselNotFound, attackingVesselName);

            IVessel defendingVessel = vessels.FindByName(defendingVesselName);

            if (defendingVessel == null)
                return string.Format(OutputMessages.VesselNotFound, defendingVesselName);

            if (attackingVessel.ArmorThickness == 0)
                return string.Format(OutputMessages.AttackVesselArmorThicknessZero, attackingVesselName);

            if (defendingVessel.ArmorThickness == 0)
                return string.Format(OutputMessages.AttackVesselArmorThicknessZero, defendingVesselName);

            attackingVessel.Attack(defendingVessel);
            return string.Format(OutputMessages.SuccessfullyAttackVessel, defendingVesselName, attackingVesselName,
                defendingVessel.ArmorThickness);
        }
    }
}