function solve(products) {
    const catalogue = products.reduce((acc, curr) => {
        const [product, price] = curr.split(" : ");

        if (!acc.hasOwnProperty(product[0])) {
            acc[product[0]] = {};
        }

        acc[product[0]][product] = price;
        return acc;
    }, {});

    Object.keys(catalogue)
        .sort()
        .forEach(letter => {
            console.log(letter);
            const productPrices = catalogue[letter];

            Object.keys(productPrices)
                .sort((a, b) => a.toLowerCase().localeCompare(b.toLowerCase()))
                .forEach(p => console.log(`  ${p}: ${productPrices[p]}`));
        });
}