function signCheck(numOne, numTwo, numThree) {
    let negativeCount = 0;

    if (numOne < 0) negativeCount++;
    if (numTwo < 0) negativeCount++;
    if (numThree < 0) negativeCount++;

    console.log(negativeCount % 2 === 1 ? "Negative" : "Positive");
}