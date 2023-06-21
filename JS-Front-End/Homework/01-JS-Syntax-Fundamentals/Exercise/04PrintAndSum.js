function printAndSum(start, end) {
    let nums = [], sum = 0;

    for (let i = start; i <= end; i++) {
        nums.push(i);
        sum += i;
    }

    console.log(nums.join(' '));
    console.log(`Sum: ${sum}`);
}