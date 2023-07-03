function oddEvenSums(x) {
    let oddSum = 0, evenSum = 0;

    while (x > 0) {
        const digit = x % 10;

        if (digit % 2 === 0)
            evenSum += digit;
        else
            oddSum += digit;

        x = Math.floor(x / 10);
    }

    console.log(`Odd sum = ${oddSum}, Even sum = ${evenSum}`);
}