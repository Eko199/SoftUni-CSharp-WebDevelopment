function solve([n, ...commands]) {
    const riders = commands.splice(0, Number(n)).reduce((acc, curr) => {
        const [rider, fuel, position] = curr.split("|");

        acc[rider] = { 
            fuel: Number(fuel), 
            position: Number(position) 
        };

        return acc;
    }, {});

    const commandExecutor = {
        "StopForFuel": stopForFuel,
        "Overtaking": overtake,
        "EngineFail": engineFail
    };

    for (const cmd of commands) {
        if (cmd === "Finish") {
            break;
        }

        const [action, rider, ...rest] = cmd.split(" - ");
        commandExecutor[action](rider, ...rest);
    }

    Object.entries(riders)
        .forEach(([rider, { position }]) => console.log(`${rider}\n  Final position: ${position}`));

    function stopForFuel(rider, minFuel, changedPos) {
        if (riders[rider].fuel >= Number(minFuel)) {
            console.log(`${rider} does not need to stop for fuel!`);
            return;
        }

        riders[rider].position = Number(changedPos);
        console.log(`${rider} stopped to refuel but lost his position, now he is ${changedPos}.`);
    }

    function overtake(rider1, rider2) {
        if (riders[rider1].position >= riders[rider2].position) {
            return;
        }

        const temp = riders[rider1].position;
        riders[rider1].position = riders[rider2].position;
        riders[rider2].position = temp;

        console.log(`${rider1} overtook ${rider2}!`);
    }

    function engineFail(rider, lapsLeft) {
        delete riders[rider];
        console.log(`${rider} is out of the race because of a technical issue, ${lapsLeft} laps before the finish.`);
    }
}