function getEmployees(arr) {
    arr.map(str => ({
        name: str,
        personalNumber: str.length
    })).forEach(e => console.log(`Name: ${e.name} -- Personal Number: ${e.personalNumber}`));
}