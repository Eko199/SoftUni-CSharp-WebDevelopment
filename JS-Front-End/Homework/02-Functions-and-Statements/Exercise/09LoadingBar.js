function printLoadingBar(percent) {
    if (percent === 100) {
        console.log("100% Complete!");
        console.log("[%%%%%%%%%%]");
    } else {
        const percentCount = percent / 10;

        console.log(`${percent}% [${'%'.repeat(percentCount)}${'.'.repeat(10 - percentCount)}]`);
        console.log("Still loading...");
    }
}