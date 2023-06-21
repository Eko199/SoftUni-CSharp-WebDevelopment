function sortNumbers(nums) {
    let numsCopy = nums.slice(), result = [];

    numsCopy.sort((a, b) => a - b);

    while (numsCopy.length > 0) {
        result.push(numsCopy.shift());
        result.push(numsCopy.pop());
    }

    return result;
}