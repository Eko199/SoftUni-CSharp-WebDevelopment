function isPerfect(num) {
    let sum = 0;

    for (let i = 1; i <= num / 2; i++) {
        if (num % i === 0) {
            sum += i;
        }
    }

    console.log(num === sum ? "We have a perfect number!" : "It's not so perfect.");
}