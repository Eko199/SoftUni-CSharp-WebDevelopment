function countWords([wordsToCount, ...words]) {
    const wordsTracker = {};

    wordsToCount.split(" ").forEach(w => wordsTracker[w] = 0);

    words.forEach(w => {
        if (wordsTracker.hasOwnProperty(w)) {
            wordsTracker[w]++;
        }
    });

    Object.entries(wordsTracker)
        .sort((a, b) => b[1] - a[1])
        .forEach(([word, count]) => console.log(`${word} - ${count}`));
}