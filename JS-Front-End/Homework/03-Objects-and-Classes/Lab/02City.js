function printCity(city) {
    for (const prop in city) {
        console.log(`${prop} -> ${city[prop]}`);
    }
}