function revealWords(words, text) {
    words = words.split(", ");

    for (const word of words) {
        const censor = '*'.repeat(word.length); 
        let textWords = text.split(' ');

        for (let i = 0; i < textWords.length; i++) {
            if (textWords[i] === censor) {
                textWords[i] = word;
            }
        }

        text = textWords.join(' ');
    }

    console.log(text);
}