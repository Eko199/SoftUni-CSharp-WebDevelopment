function colorize() {
    Array.from(document.querySelectorAll("tr:nth-child(even)"))
        .forEach(e => e.style = "background-color: teal");
}