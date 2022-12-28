namespace Formula1.Core
{
    using System;
    using System.Linq;
    using System.Text;

    using Contracts;
    using Models;
    using Models.Contracts;
    using Repositories;
    using Repositories.Contracts;
    using Utilities;

    public class Controller : IController
    {
        private readonly IRepository<IPilot> pilotRepository;
        private readonly IRepository<IRace> raceRepository;
        private readonly IRepository<IFormulaOneCar> carRepository;

        public Controller()
        {
            pilotRepository = new PilotRepository();
            raceRepository = new RaceRepository();
            carRepository = new FormulaOneCarRepository();
        }

        public string CreatePilot(string fullName)
        {
            if (pilotRepository.FindByName(fullName) != null)
                throw new InvalidOperationException(string.Format(ExceptionMessages.PilotExistErrorMessage, fullName));

            pilotRepository.Add(new Pilot(fullName));
            return string.Format(OutputMessages.SuccessfullyCreatePilot, fullName);
        }

        public string CreateCar(string type, string model, int horsepower, double engineDisplacement)
        {
            if (carRepository.FindByName(model) != null)
                throw new InvalidOperationException(string.Format(ExceptionMessages.CarExistErrorMessage, model));

            carRepository.Add(type switch
            {
                "Ferrari" => new Ferrari(model, horsepower, engineDisplacement),
                "Williams" => new Williams(model, horsepower, engineDisplacement),
                _ => throw new InvalidOperationException(string.Format(ExceptionMessages.InvalidTypeCar, type))
            });

            return string.Format(OutputMessages.SuccessfullyCreateCar, type, model);
        }

        public string CreateRace(string raceName, int numberOfLaps)
        {
            if (raceRepository.FindByName(raceName) != null)
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceExistErrorMessage, raceName));

            raceRepository.Add(new Race(raceName, numberOfLaps));
            return string.Format(OutputMessages.SuccessfullyCreateRace, raceName);
        }

        public string AddCarToPilot(string pilotName, string carModel)
        {
            IPilot pilot = pilotRepository.FindByName(pilotName);

            if (pilot == null || pilot.Car != null)
                throw new InvalidOperationException(
                    string.Format(ExceptionMessages.PilotDoesNotExistOrHasCarErrorMessage, pilotName));

            IFormulaOneCar car = carRepository.FindByName(carModel);

            if (car == null)
                throw new NullReferenceException(
                    string.Format(ExceptionMessages.CarDoesNotExistErrorMessage, carModel));

            pilot.AddCar(car);
            carRepository.Remove(car);

            return string.Format(OutputMessages.SuccessfullyPilotToCar, pilotName, car.GetType().Name, carModel);
        }

        public string AddPilotToRace(string raceName, string pilotFullName)
        {
            IRace race = raceRepository.FindByName(raceName);

            if (race == null)
                throw new NullReferenceException(
                    string.Format(ExceptionMessages.RaceDoesNotExistErrorMessage, raceName));

            IPilot pilot = pilotRepository.FindByName(pilotFullName);

            if (pilot == null || !pilot.CanRace || raceRepository.Models.Any(r => r.Pilots.Contains(pilot)))
                throw new InvalidOperationException(
                    string.Format(ExceptionMessages.PilotDoesNotExistErrorMessage, pilotFullName));

            race.AddPilot(pilot);
            return string.Format(OutputMessages.SuccessfullyAddPilotToRace, pilotFullName, raceName);
        }

        public string StartRace(string raceName)
        {
            IRace race = raceRepository.FindByName(raceName);

            if (race == null)
                throw new NullReferenceException(
                    string.Format(ExceptionMessages.RaceDoesNotExistErrorMessage, raceName));

            if (race.Pilots.Count < 3)
                throw new InvalidOperationException(string.Format(ExceptionMessages.InvalidRaceParticipants, raceName));

            if (race.TookPlace)
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceTookPlaceErrorMessage, raceName));

            IPilot[] top3 = race.Pilots.OrderByDescending(p => p.Car.RaceScoreCalculator(race.NumberOfLaps)).Take(3).ToArray();
            race.TookPlace = true;
            top3[0].WinRace();

            var sb = new StringBuilder();
            sb.AppendLine(string.Format(OutputMessages.PilotFirstPlace, top3[0].FullName, raceName));
            sb.AppendLine(string.Format(OutputMessages.PilotSecondPlace, top3[1].FullName, raceName));
            sb.AppendLine(string.Format(OutputMessages.PilotThirdPlace, top3[2].FullName, raceName));

            return sb.ToString().Trim();
        }

        public string RaceReport()
            => string.Join(Environment.NewLine, raceRepository.Models.Where(r => r.TookPlace).Select(r => r.RaceInfo()));

        public string PilotReport() 
            => string.Join(Environment.NewLine, pilotRepository.Models.OrderByDescending(p => p.NumberOfWins).Select(p => p.ToString()));
    }
}