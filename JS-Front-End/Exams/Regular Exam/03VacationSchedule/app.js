const API_URL = "http://localhost:3030/jsonstore/tasks";

const inputs = {
    name: document.getElementById("name"),
    days: document.getElementById("num-days"),
    date: document.getElementById("from-date")
}

const addBtn = document.getElementById("add-vacation");
const editBtn = document.getElementById("edit-vacation");

document.getElementById("load-vacations").addEventListener("click", loadData);
addBtn.addEventListener("click", addVacation);
editBtn.addEventListener("click", editVacation);

async function loadData() {
    const vactions = Object.values(await (await fetch(API_URL)).json());

    const list = document.getElementById("list");
    list.innerHTML = "";

    vactions.forEach(v => list.appendChild(createVacationElement(v)));
    editBtn.disabled = true;
}

function createVacationElement(vacation) {
    const vacationDiv = createElement("div", null, null, ["container"]);
    vacationDiv.setAttribute("data-vacationid", vacation._id);

    createElement("h2", vacation.name, vacationDiv);
    createElement("h3", vacation.date, vacationDiv);
    createElement("h3", vacation.days, vacationDiv);

    createElement("button", "Change", vacationDiv, ["change-btn"])
        .addEventListener("click", changeVacation);
    createElement("button", "Done", vacationDiv, ["done-btn"])
        .addEventListener("click", removeVacation);

    return vacationDiv;
}

async function addVacation(ev) {
    ev.preventDefault();

    await fetch(API_URL, {
        method: "POST",
        headers: { "Content-type": "application/json" },
        body: JSON.stringify({
            name: inputs.name.value,
            days: inputs.days.value,
            date: inputs.date.value
        })
    });

    Object.values(inputs).forEach(i => i.value = "");
    await loadData();
}

async function changeVacation(ev) {
    const vacationDiv = ev.target.parentNode;

    inputs.name.value = vacationDiv.querySelector("h2").textContent;
    inputs.date.value = vacationDiv.querySelector("h3:first-of-type").textContent;
    inputs.days.value = vacationDiv.querySelector("h3:last-of-type").textContent;

    editBtn.setAttribute("data-vacationid", vacationDiv.dataset.vacationid);
    vacationDiv.remove();

    editBtn.disabled = false;
    addBtn.disabled = true;
}

async function editVacation(ev) {
    ev.preventDefault();

    const vacationId = ev.target.dataset.vacationid;

    await fetch(`${API_URL}/${vacationId}`, {
        method: "PUT",
        headers: { "Content-type": "application/json" },
        body: JSON.stringify({
            name: inputs.name.value,
            days: inputs.days.value,
            date: inputs.date.value,
            _id: vacationId
        })
    });

    editBtn.disabled = true;
    addBtn.disabled = false;

    await loadData();
}

async function removeVacation(ev) {
    await fetch(`${API_URL}/${ev.target.parentNode.dataset.vacationid}`, { method: "DELETE" });
    await loadData();
}

function createElement(type, content, parent, classes, id, useInnerHtml = false) {
    const element = document.createElement(type);

    if (content) {
        useInnerHtml
            ? element.innerHTML = content
            : element.innerText = content;
    }

    if (parent) {
        parent.appendChild(element);
    }

    if (classes && classes.length > 0) {
        element.classList.add(...classes);
    }

    if (id) {
        element.id = id;
    }

    return element;
}