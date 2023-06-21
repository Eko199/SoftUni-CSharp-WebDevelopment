function calculatePrice(fruit, grams, price) {
    const kilos = grams / 1000;

    console.log(`I need $${(price * kilos).toFixed(2)} to buy ${kilos.toFixed(2)} kilograms ${fruit}.`)
}