function solve(commands) {
    const armies = commands.reduce((acc, curr) => {
        if (curr.includes("+")) {
            const [armyName, addCount] = curr.split(" + ");

            const army = Object.values(acc)
                .flat()
                .find(a => a.name === armyName);

            if (!army) {
                return acc;
            }

            army.count += Number(addCount);
        } else if (curr.includes(":")) {
            const [leader, army] = curr.split(": ");

            if (!acc.hasOwnProperty(leader)) {
                return acc;
            }

            const [name, count] = army.split(", ");
            acc[leader].push({ name, count: Number(count) });
        } else {
            const spaceSplit = curr.split(" ");
            const action = spaceSplit.pop();

            if (action === "arrives") {
                acc[spaceSplit.join(" ")] = [];
            } else if (action === "defeated") {
                delete acc[spaceSplit.join(" ")];
            }
        }

        return acc;
    }, {});

    Object.entries(armies)
        .sort((a, b) => 
            b[1].reduce((acc, curr) => acc + curr.count, 0) - a[1].reduce((acc, curr) => acc + curr.count, 0))
        .forEach(([leader, armies]) => {
            console.log(`${leader}: ${armies.reduce((acc, curr) => acc + curr.count, 0)}`);
            armies
                .sort((a, b) => b.count - a.count)
                .forEach(a => console.log(`>>> ${a.name} - ${a.count}`));
        });
}