function solve([desired, ...crystals]) {
    crystals.forEach(processCrystal);

    function processCrystal(crystal) {
        console.log(`Processing chunk ${crystal} microns`);

        crystal = performAction(crystal, "Cut", x => x / 4);
        crystal = performAction(crystal, "Lap", x => x * 0.8);
        crystal = performAction(crystal, "Grind", x => x - 20);
        crystal = performAction(crystal, "Etch", x => x - 2);

        if (crystal + 1 === desired) {
            crystal++;
            console.log("X-ray x1");
        }

        console.log(`Finished crystal ${crystal} microns`);
    }

    function performAction(crystal, actionName, func) {
        let counter = 0;

        while (func(crystal) >= desired) {
            crystal = func(crystal);
            counter++;
        }

        if (counter > 0) {
            console.log(`${actionName} x${counter}`);

            crystal = Math.floor(crystal);
            console.log("Transporting and washing");
        }

        return crystal;
    }
}