function addItem() {
    const newLi = document.createElement("li");
    newLi.innerText = document.getElementById("newItemText").value;

    const deleteLink = document.createElement("a");
    deleteLink.innerText = "[Delete]";
    deleteLink.href = "#";
    deleteLink.addEventListener("click", e => e.target.parentElement.remove());

    newLi.appendChild(deleteLink);

    document.getElementById("items").appendChild(newLi);
}