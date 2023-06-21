function speedLimit(speed, area) {
    let speedLimit;

    switch (area) {
        case "motorway":
            speedLimit = 130;
            break;
        case "interstate":
            speedLimit = 90;
            break;
        case "city":
            speedLimit = 50;
            break;
        case "residential":
            speedLimit = 20;
            break;
    }

    const speeding = speed - speedLimit;

    if (speeding <= 0) {
        console.log(`Driving ${speed} km/h in a ${speedLimit} zone`);
    } else if (speeding <= 20) {
        console.log(`The speed is ${speeding} km/h faster than the allowed speed of ${speedLimit} - speeding`);
    } else if (speeding <= 40) {
        console.log(`The speed is ${speeding} km/h faster than the allowed speed of ${speedLimit} - excessive speeding`);
    } else {
        console.log(`The speed is ${speeding} km/h faster than the allowed speed of ${speedLimit} - reckless driving`);
    }
}