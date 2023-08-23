import setUpTab from "./setUpTab.js";

setUpTab();

const user = JSON.parse(localStorage.getItem("user"));

const catchesDiv = document.getElementById("catches");
const addBtn = document.querySelector("button.add");
addBtn.disabled = user ? false : true;

const inputs = {
    angler: document.querySelector("#addForm .angler"),
    weight: document.querySelector("#addForm .weight"),
    species: document.querySelector("#addForm .species"),
    location: document.querySelector("#addForm .location"),
    bait: document.querySelector("#addForm .bait"),
    captureTime: document.querySelector("#addForm .captureTime")
};

document.querySelector(".load").addEventListener("click", loadData);
addBtn.addEventListener("click", addCatch);

async function loadData() {
    const catches = await(
        await fetch("http://localhost:3030/data/catches")
    ).json();

    catchesDiv.innerHTML = "";
    catches.forEach(createCatchElement);
}

function createCatchElement(catchObj) {
    const catchDiv = createElement("div", null, catchesDiv, ["catch"]);
    catchDiv.setAttribute("data-ownerid", catchObj._ownerId);

    createElement("label", "Angler", catchDiv);
    const anglerInput = createElement("input", null, catchDiv, ["angler"]);
    anglerInput.type = "text";
    anglerInput.value = catchObj.angler;

    createElement("label", "Weight", catchDiv);
    const weigthInput = createElement("input", null, catchDiv, ["weight"]);
    weigthInput.type = "text";
    weigthInput.value = catchObj.weight;

    createElement("label", "Species", catchDiv);
    const speciesInput = createElement("input", null, catchDiv, ["species"]);
    speciesInput.type = "text";
    speciesInput.value = catchObj.species;

    createElement("label", "Location", catchDiv);
    const locationInput = createElement("input", null, catchDiv, ["location"]);
    locationInput.type = "text";
    locationInput.value = catchObj.location;

    createElement("label", "Bait", catchDiv);
    const baitInput = createElement("input", null, catchDiv, ["bait"]);
    baitInput.type = "text";
    baitInput.value = catchObj.bait;

    createElement("label", "Capture Time", catchDiv);
    const captureInput = createElement("input", null, catchDiv, ["captureTime"]);
    captureInput.type = "number";
    captureInput.value = catchObj.captureTime;

    const updateBtn = createElement("button", "Update", catchDiv, ["update"]);
    updateBtn.setAttribute("data-id", catchObj._id);
    updateBtn.disabled = !user || catchObj._ownerId !== user._id;
    updateBtn.addEventListener("click", updateCatch);

    const deleteBtn = createElement("button", "Delete", catchDiv, ["delete"]);
    deleteBtn.setAttribute("data-id", catchObj._id);
    deleteBtn.disabled = !user || catchObj._ownerId !== user._id;
    deleteBtn.addEventListener("click", deleteCatch);

    return catchDiv;
}

function createElement(type, content, parent, classes, id, useInnerHtml = false) {
    const element = document.createElement(type);

    if (content) {
        element[useInnerHtml ? "innerHTML" : "textContent"] = content;
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

async function updateCatch(ev) {
    const button = ev.target;
    const catchDiv = button.parentNode;

    if (catchDiv.dataset.ownerid !== JSON.parse(localStorage.getItem("user"))._id) {
        return;
    }

    await fetch(`http://localhost:3030/data/catches/${button.dataset.id}`, {
        method: "PUT",
        headers: { 
            "x-authorization": localStorage.getItem("accessToken"),
            "Content-type": "application/json"
        },
        body: JSON.stringify({
            angler: catchDiv.querySelector(".angler").value,
            weight: catchDiv.querySelector(".weight").value,
            species: catchDiv.querySelector(".species").value,
            location: catchDiv.querySelector(".location").value,
            bait: catchDiv.querySelector(".bait").value,
            captureTime: catchDiv.querySelector(".captureTime").value
        })
    });
}

async function deleteCatch(ev) {
    const button = ev.target;

    if (button.parentNode.dataset.ownerid !== JSON.parse(localStorage.getItem("user"))._id) {
        return;
    }

    await fetch(`http://localhost:3030/data/catches/${button.dataset.id}`, {
        method: "DELETE",
        headers: { "x-authorization": localStorage.getItem("accessToken") }
    });
}

async function addCatch(ev) {
    ev.preventDefault();

    if (!user || Object.values(inputs).some(i => i.value === "")) {
        return;
    }

    await fetch("http://localhost:3030/data/catches", {
        method: "POST",
        headers: { 
            "x-authorization": localStorage.getItem("accessToken"),
            "Content-type": "application/json"
        },
        body: JSON.stringify({
            angler: inputs.angler.value,
            weight: inputs.weight.value,
            species: inputs.species.value,
            location: inputs.location.value,
            bait: inputs.bait.value,
            captureTime: inputs.captureTime.value
        })
    });

    Object.values(inputs).forEach(i => i.value = "");
}