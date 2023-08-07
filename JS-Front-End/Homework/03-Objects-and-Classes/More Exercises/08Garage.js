function solve(cars) {
    const garages = cars.reduce((acc, curr) => {
        const [garage, car] = curr.split(" - ");

        if (!acc.hasOwnProperty(garage)) {
            acc[garage] = [];
        }

        acc[garage].push(car.split(", ").reduce((carObj, propVal) => {
            const [prop, val] = propVal.split(": ");
            carObj[prop] = val;
            return carObj;
        }, {}));

        return acc;
    }, {});
    
    Object.keys(garages)
        .forEach(garage => {
            console.log(`Garage № ${garage}`);
            garages[garage].forEach(car => 
                console.log(`--- ${Object.entries(car).map(e => `${e[0]} - ${e[1]}`).join(", ")}`)
            );
        });
}