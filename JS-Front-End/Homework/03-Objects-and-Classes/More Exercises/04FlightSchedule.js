function solve([flights, statusChanges, [checkedStatus]]) {
    const flightStatuses = flights.reduce((acc, curr) => {
        const [flightNumber, ...destination] = curr.split(" ");

        acc[flightNumber] = {
            "Destination": destination.join(" ")
        };

        return acc;
    }, {});

    statusChanges.forEach(change => {
        const [flightNumber, ...newSatus] = change.split(" ");

        if (flightStatuses[flightNumber]) {
            flightStatuses[flightNumber]["Status"] = newSatus.join(" ");
        }
    });

    if (checkedStatus === "Ready to fly") {
        Object.values(flightStatuses)
            .filter(f => !f.hasOwnProperty("Status"))
            .forEach(f => {
                f["Status"] = "Ready to fly";
                console.log(`{ Destination: '${f["Destination"]}', Status: '${f["Status"]}' }`);
            });
    } else {
        Object.values(flightStatuses)
            .filter(f => f["Status"] === checkedStatus)
            .forEach(f => console.log(`{ Destination: '${f["Destination"]}', Status: '${f["Status"]}' }`));
    }
}