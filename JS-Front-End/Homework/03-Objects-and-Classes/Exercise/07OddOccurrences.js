function getOddOccurrences(str) {
    let result = "";

    strSplit = str.toLowerCase().split(" ");

    words = new Set(strSplit);

    words.forEach(w => {
        let count = 0;

        strSplit.forEach(s => {
            if (s === w) {
                count++;
            }
        })
        
        if (count % 2 === 1) {
            result += `${w} `;
        }
    });

    console.log(result);
}