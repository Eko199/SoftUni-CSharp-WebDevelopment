function findSpecialWords(text) {
    text.split(' ')
        .filter(w => w.startsWith('#'))
        .map(w => w.substring(1, w.length))
        .filter(w => w.match(/^[A-Za-z]+$/))
        .forEach(w => console.log(w));
}