function addItem() {
    const newLi = document.createElement("li");
    newLi.innerText = document.getElementById("newItemText").value;

    document.getElementById("items").appendChild(newLi);
}