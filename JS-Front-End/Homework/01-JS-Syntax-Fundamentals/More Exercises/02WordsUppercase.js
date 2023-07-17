function getUppercaseWords(str) {
    console.log(str.toUpperCase()
                    .split(/\W+/g)
                    .filter(w => w.length > 0)
                    .join(", "));
}