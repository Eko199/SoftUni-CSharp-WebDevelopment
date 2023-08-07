function solve(stringArr) {
    const jaggedArr = stringArr.map(JSON.parse);
    
    while (jaggedArr.some(arr => countSameArrays(arr) > 1)) {
        for (let i = jaggedArr.length - 1; i >= 0; i--) {
            if (countSameArrays(jaggedArr[i]) > 1) {
                jaggedArr.splice(i, 1);
                break;
            }
        }
    }

    jaggedArr
        .sort((a, b) => a.length - b.length)
        .forEach(arr => console.log(`[${arr.sort((a, b) => b - a).join(", ")}]`));

    function countSameArrays(arr) {
        return jaggedArr.reduce((count, subArr) => {
            const arrCopy = arr.slice();

            subArr.forEach(x => {
                const xIndex = arrCopy.indexOf(x);

                if (xIndex !== -1) {
                    arrCopy.splice(arrCopy.indexOf(x), 1);
                }
            });

            return arrCopy.length === 0 ? count + 1 : count;
        }, 0);
    }
}