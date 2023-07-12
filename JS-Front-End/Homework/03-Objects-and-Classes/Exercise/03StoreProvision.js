function getProvisions(arr1, arr2) {
    const provisions = {};
    
    function fillProvisions(arr) {
        for (let i = 0; i < arr.length; i += 2) {
            if (!provisions.hasOwnProperty(arr[i])) {
                provisions[arr[i]] = 0;
            }

            provisions[arr[i]] += Number(arr[i + 1]);
        }
    }

    fillProvisions(arr1);
    fillProvisions(arr2);

    Object.entries(provisions)
        .forEach(([provision, quantity]) => console.log(`${provision} -> ${quantity}`));
}