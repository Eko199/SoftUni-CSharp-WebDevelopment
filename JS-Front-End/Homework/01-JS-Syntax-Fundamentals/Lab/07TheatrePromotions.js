function ticketPrice(day, age) {
    let price;

    switch (day) {
        case "Weekday":
            if (0 <= age && age <= 18) {
                price = 12;
            } else if (age > 18 && age <= 64) {
                price = 18;
            } else if (age > 64 && age <= 122) {
                price = 12;
            }

            break;
        case "Weekend":
            if (0 <= age && age <= 18) {
                price = 15;
            } else if (age > 18 && age <= 64) {
                price = 20;
            } else if (age > 64 && age <= 122) {
                price = 15;
            }
            
            break;
        case "Holiday":
            if (0 <= age && age <= 18) {
                price = 5;
            } else if (age > 18 && age <= 64) {
                price = 12;
            } else if (age > 64 && age <= 122) {
                price = 10;
            } else {
                console.log("Error!");
            }
            
            break;
    }

    if (price === undefined)
        console.log("Error!");
    else
        console.log(`${price}$`);
}