function calculate(numOne, numTwo, operator) {
    const operations = {
        add: (x, y) => x + y,
        subtract: (x, y) => x - y,
        multiply: (x, y) => x * y,
        divide: (x, y) => x / y
    };

    console.log(operations[operator](numOne, numTwo));
}