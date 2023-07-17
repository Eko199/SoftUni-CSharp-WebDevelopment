function solve(goldShifts) {
    const bitcoinPrice = 11949.16;
    let leva = 0, dayOfFirstBitcoin;

    for (let i = 1; i <= goldShifts.length; i++) {
        leva += goldShifts[i - 1] * (i % 3 === 0 ? 0.7 : 1) * 67.51;
        
        if (leva >= bitcoinPrice && !dayOfFirstBitcoin) {
            dayOfFirstBitcoin = i;
        }
    }

    const boughtBitcoins = Math.floor(leva / bitcoinPrice);

    console.log(`Bought bitcoins: ${boughtBitcoins}`);

    if (dayOfFirstBitcoin) {
        console.log(`Day of the first purchased bitcoin: ${dayOfFirstBitcoin}`);
    }
    
    console.log(`Left money: ${(leva - bitcoinPrice * boughtBitcoins).toFixed(2)} lv.`);
}