function deleteByEmail() {
    const element = Array.from(document.querySelectorAll("td:nth-child(even)"))
        .find(e => e.innerText === document.querySelector("input").value);
    const result = document.getElementById("result");

    if (element) {
        element.parentElement.remove();
        result.innerText = "Deleted."
    } else {
        result.innerText = "Not found.";
    }
}