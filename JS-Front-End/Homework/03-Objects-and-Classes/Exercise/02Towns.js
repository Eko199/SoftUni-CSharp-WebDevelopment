function getTowns(arr) {
    arr.map(str => {
        const [town, latitude, longitude] = str.split(" | ");

        return {
            town,
            latitude: Number(latitude).toFixed(2),
            longitude: Number(longitude).toFixed(2)
        }
    }).forEach(t => console.log(t));
}