function modifyNumber(num) {
    function getDigitAverage(x) {
        const digits = x.toString().split("");
        return digits.reduce((acc, curr) => acc + Number(curr), 0) / digits.length;
    }

    while (getDigitAverage(num) <= 5) {
        num = Number(num.toString() + "9");
    }

    console.log(num);
}