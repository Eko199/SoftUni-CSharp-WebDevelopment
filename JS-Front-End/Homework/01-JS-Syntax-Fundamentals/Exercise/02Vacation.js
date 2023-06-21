function vacationPrice(people, groupType, day) {
    let price;

    switch (groupType) {
        case "Students":
            if (day === "Friday")
                price = 8.45;
            else if (day === "Saturday")
                price = 9.80;
            else if (day === "Sunday")
                price = 10.46;

            if (people >= 30)
                price *= 0.85;
            break;
        case "Business":
            if (day === "Friday")
                price = 10.90;
            else if (day === "Saturday")
                price = 15.60;
            else if (day === "Sunday")
                price = 16;

            if (people >= 100)
                people -=10;
            break;
        case "Regular":
            if (day === "Friday")
                price = 15;
            else if (day === "Saturday")
                price = 20;
            else if (day === "Sunday")
                price = 22.50;

            if (people >= 10 && people <= 20)
                price *= 0.95;
            break;
    }

    price *= people;
    console.log(`Total price: ${price.toFixed(2)}`);
}