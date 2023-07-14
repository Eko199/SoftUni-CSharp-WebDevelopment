function printPhoneBook(arr) {
    Object.entries(arr.reduce((acc, curr) => {
        const [name, number] = curr.split(" ");
        acc[name] = number;

        return acc;
    }, {})). forEach(([name, number]) => console.log(`${name} -> ${number}`));
}