function solve(dailYield) {
    let spices = 0, days = 0;

    while (dailYield >= 100) {
        spices += dailYield;
        dailYield -= 10;
        spices = Math.max(0, spices - 26);
        days++;
    }

    spices = Math.max(0, spices - 26);

    console.log(days);
    console.log(spices);
}