function factorialDivision(x, y) {
    const factorial = num => num === 1 ? num : num * factorial(num - 1);

    console.log((factorial(x) / factorial(y)).toFixed(2));
}