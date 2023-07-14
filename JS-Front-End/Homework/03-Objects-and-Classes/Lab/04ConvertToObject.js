function printObject(json) {
    Object.entries(JSON.parse(json))
        .forEach(([prop, value]) => console.log(`${prop}: ${value}`));
}