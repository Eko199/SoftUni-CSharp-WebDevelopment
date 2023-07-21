function addItem() {
    const textInput = document.getElementById("newItemText");
    const valueInput = document.getElementById("newItemValue");

    const newItem = document.createElement("option");
    newItem.innerText = textInput.value;
    newItem.value = valueInput.value;

    document.getElementById("menu").appendChild(newItem);
    textInput.value = "";
    valueInput.value = "";
}