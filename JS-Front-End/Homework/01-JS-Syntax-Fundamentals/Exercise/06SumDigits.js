function sumDigits(x) {
    let sum = 0;

    while (x > 0) {
        sum += x % 10;
        x = Math.floor(x / 10);
    }

    console.log(sum);
}