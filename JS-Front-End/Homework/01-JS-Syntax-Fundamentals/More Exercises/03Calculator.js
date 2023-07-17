function calculate(x, operator, y) {
    const calculator = {
        '+': (x, y) => x + y,
        '-': (x, y) => x - y,
        '*': (x, y) => x * y,
        '/': (x, y) => x / y
    };

    console.log(calculator[operator](x, y).toFixed(2));
}