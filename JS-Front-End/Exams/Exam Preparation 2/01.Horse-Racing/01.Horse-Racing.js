function solve([horses, ...commands]) {
    horses = horses.split("|");

    const commandExecutor = {
        "Retake": retakeHorses,
        "Trouble": troubleHorse,
        "Rage": rageHorse,
        "Miracle": miracle
    };

    for (cmd of commands) {
        const [action, ...params] = cmd.split(" ");

        if (action === "Finish") {
            break;
        }

        commandExecutor[action](...params);
    };

    console.log(horses.join("->"));
    console.log(`The winner is: ${horses[horses.length - 1]}`);

    function retakeHorses(overtaking, overtaken) {
        const overtakingIndex = horses.indexOf(overtaking);
        const overtakenIndex = horses.indexOf(overtaken);

        if (overtakingIndex >= overtakenIndex) {
            return;
        }

        horses[overtakenIndex] = overtaking;
        horses[overtakingIndex] = overtaken;

        console.log(`${overtaking} retakes ${overtaken}.`);
    }

    function troubleHorse(horse) {
        const horseIndex = horses.indexOf(horse);

        if (horseIndex <= 0) {
            return;
        }

        horses[horseIndex] = horses[horseIndex - 1];
        horses[horseIndex - 1] = horse;

        console.log(`Trouble for ${horse} - drops one position.`);
    }

    function rageHorse(horse) {
        const currentIndex = horses.indexOf(horse);
        const newIndex = Math.min(currentIndex + 2, horses.length - 1);

        if (currentIndex !== newIndex) {
            horses.splice(currentIndex, 1);
            horses.splice(newIndex, 0, horse);
        }

        console.log(`${horse} rages 2 positions ahead.`);
    }

    function miracle() {
        horses.push(horses[0]);
        console.log(`What a miracle - ${horses.shift()} becomes first.`);
    }
}