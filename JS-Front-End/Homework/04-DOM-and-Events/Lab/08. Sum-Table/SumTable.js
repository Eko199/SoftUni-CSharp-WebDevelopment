function sumTable() {
    const sum = Array.from(document.querySelectorAll("tr:not(:last-child) td:nth-child(even)"))
                    .reduce((acc, curr) => acc + Number(curr.innerText), 0);
    document.getElementById("sum").innerText = sum;
}