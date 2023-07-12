function parking(commands) {
    const cars = new Set();

    commands.forEach(cmd => {
        const [dir, car] = cmd.split(", ");

        if (dir === "IN") {
            cars.add(car);
        } else if (dir === "OUT") {
            cars.delete(car);
        }
    });

    if (cars.length === 0) {
        console.log("Parking Lot is Empty");
    } else {
        Array.from(cars).sort().forEach(c => console.log(c));
    }
}