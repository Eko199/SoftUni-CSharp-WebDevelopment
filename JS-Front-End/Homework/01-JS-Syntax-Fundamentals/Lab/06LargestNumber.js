function max(x, y, z) {
    let max = x;

    if (y > max)
        max = y;

    if (z > max)
        max = z;

    console.log(`The largest number is ${max}.`)
}