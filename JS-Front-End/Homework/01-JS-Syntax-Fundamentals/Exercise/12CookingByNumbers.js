function cook(x, ...operations) {
    x = Number(x);

    for (const operation of operations) {
        switch (operation) {
            case "chop":
                x /= 2;
                break;
            case "dice":
                x = Math.sqrt(x);
                break;
            case "spice":
                x++;
                break;
            case "bake":
                x *= 3;
                break;
            case "fillet":
                x *= 0.8;
                break;
        }

        console.log(x);
    }
}