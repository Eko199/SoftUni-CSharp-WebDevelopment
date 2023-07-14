function printAddresses(arr) {
    Object.entries(arr.reduce((acc, curr) => {
        const [name, address] = curr.split(":");
        acc[name] = address;

        return acc;
    }, {}))
        .sort((a, b) => a[0].localeCompare(b[0]))
        .forEach(([name, address]) => console.log(`${name} -> ${address}`));
}