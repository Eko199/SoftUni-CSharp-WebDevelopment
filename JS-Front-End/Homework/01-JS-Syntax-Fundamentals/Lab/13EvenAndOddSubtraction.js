function evenMinusOdd(arr) {
    let evenSum = 0, oddSum = 0;

    for (x of arr) {
        if (x % 2 == 0)
            evenSum += x;
        else
            oddSum += x;
    }

    console.log(evenSum - oddSum);
}