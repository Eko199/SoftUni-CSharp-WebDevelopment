function countWord(text, word) {
    let count = 0;

    while (text.includes(word)) {
        text = text.replace(word, '');
        count++;
    }

    console.log(count);
}