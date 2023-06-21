function checkDigits(x) {
    const digit = x % 10;
    let sum = 0, sameNumber = true;

    while (x > 0) {
        sum += x % 10;

        if (digit != x % 10) {
            sameNumber = false;
        }
        
        x = Math.floor(x / 10);
    }

    console.log(sameNumber);
    console.log(sum);
}