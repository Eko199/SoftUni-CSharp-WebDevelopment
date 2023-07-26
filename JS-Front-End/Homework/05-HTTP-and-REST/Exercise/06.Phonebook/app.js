function attachEvents() {
    document.getElementById("btnLoad").addEventListener("click", loadPhonebook);
    document.getElementById("btnCreate").addEventListener("click", createContact);
}

async function loadPhonebook() {
    const list = document.getElementById("phonebook");
    list.innerHTML = "";

    const phonebook = Object.values(await (
        await fetch("http://localhost:3030/jsonstore/phonebook")
    ).json());

    phonebook.forEach(({person, phone, _id}) => {
        const li = document.createElement("li");
        li.innerText = `${person}: ${phone}`;

        const deleteBtn = document.createElement("button");
        deleteBtn.innerText = "Delete";
        deleteBtn.setAttribute("data-contactkey", _id);
        deleteBtn.addEventListener("click", deleteContact);

        li.appendChild(deleteBtn);
        list.appendChild(li);
    });
}

async function deleteContact(e) {
    await fetch(`http://localhost:3030/jsonstore/phonebook/${e.target.dataset.contactkey}`, {
        method: "DELETE"
    });

    loadPhonebook();
}

async function createContact() {
    await fetch("http://localhost:3030/jsonstore/phonebook", {
        method: "POST",
        headers: { "Content-type": "application/json" },
        body: JSON.stringify({
            person: document.getElementById("person").value,
            phone: document.getElementById("phone").value
        })
    });

    loadPhonebook();
}

attachEvents();