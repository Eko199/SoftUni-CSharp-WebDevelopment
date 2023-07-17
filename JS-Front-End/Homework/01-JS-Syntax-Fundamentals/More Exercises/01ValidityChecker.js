function checkValidity(x1, y1, x2, y2) {
    const getDistance = (x1, y1, x2, y2) => Math.sqrt((x2 - x1) ** 2 + (y2 - y1) ** 2);

    console.log(`{${x1}, ${y1}} to {0, 0} is ${getDistance(x1, y1, 0, 0) % 1 === 0 ? "valid" : "invalid"}`);
    console.log(`{${x2}, ${y2}} to {0, 0} is ${getDistance(x2, y2, 0, 0) % 1 === 0 ? "valid" : "invalid"}`);
    console.log(`{${x1}, ${y1}} to {${x2}, ${y2}} is ${getDistance(x1, y1, x2, y2) % 1 === 0 ? "valid" : "invalid"}`);
}