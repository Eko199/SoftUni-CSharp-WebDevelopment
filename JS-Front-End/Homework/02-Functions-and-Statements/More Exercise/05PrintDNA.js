function printDNA(length) {
    const dna = Array.from("ATCGTTAGGG")

    for (let i = 0; i < length; i++) {
        const gene1 = dna.shift();
        const gene2 = dna.shift();

        if (i % 4 === 0) {
            console.log(`**${gene1}${gene2}**`);
        } else if (i % 4 === 1 || i % 4 === 3) {
            console.log(`*${gene1}--${gene2}*`);
        } else {
            console.log(`${gene1}----${gene2}`);
        }

        dna.push(gene1);
        dna.push(gene2);
    }
}