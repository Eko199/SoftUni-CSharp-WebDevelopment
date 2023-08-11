function solve() {
    const selectMenuTo = document.getElementById("selectMenuTo");
    
    const binaryOpt = document.createElement("option");
    binaryOpt.value = "binary";
    binaryOpt.textContent = "Binary";
    selectMenuTo.appendChild(binaryOpt);
    
    const hexadecimalOpt = document.createElement("option");
    hexadecimalOpt.value = "hexadecimal";
    hexadecimalOpt.textContent = "Hexadecimal";
    selectMenuTo.appendChild(hexadecimalOpt);

    document.querySelector("button").addEventListener("click", convert);

    function convert() {
        const number = Number(document.getElementById("input").value);
        const result = document.getElementById("result");

        if (selectMenuTo.value === "binary") {
            result.value = convertToBinary(number);
        } else if (selectMenuTo.value === "hexadecimal") {
            result.value = convertToHexadecimal(number);
        }
    }

    function convertToBinary(num) {
        let result = "";

        while (num !== 0) {
            result += num % 2;
            num = Math.floor(num / 2);
        }

        return result.split("").reverse().join("");
    }

    function convertToHexadecimal(num) {
        const digitMapper = {
            "10": "A",
            "11": "B",
            "12": "C",
            "13": "D",
            "14": "E",
            "15": "F"
        };

        let result = "";

        while (num !== 0) {
            const digit = num % 16;

            result += digit < 10 ? digit : digitMapper[digit.toString()];
            num = Math.floor(num / 16);
        }

        return result.split("").reverse().join("");
    }
}