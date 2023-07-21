function washCar(commands) {
    const actions = {
        soap: x => x + 10,
        water: x => x * 1.2,
        "vacuum cleaner": x => x * 1.25,
        mud: x => x * 0.9
    };

    let cleanPercent = 0;

    commands.forEach(cmd => cleanPercent = actions[cmd](cleanPercent));

    console.log(`The car is ${cleanPercent.toFixed(2)}% clean.`)
}