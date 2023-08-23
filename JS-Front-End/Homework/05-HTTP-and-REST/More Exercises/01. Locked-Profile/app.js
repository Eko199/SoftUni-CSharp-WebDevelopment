const API_URL = "http://localhost:3030/jsonstore/advanced/profiles";
const main = document.getElementById("main");

async function lockedProfile() {
    const profiles = Object.values(await (await fetch(API_URL)).json());
    main.innerHTML = "";
    profiles.forEach(createProfileElement);
}

function createProfileElement(profile) {
    const profileDiv = createElement("div", null, main, ["profile"]);

    createElement("img", null, profileDiv, ["userIcon"]).src = "./iconProfile2.png";

    createElement("label", "Lock", profileDiv);
    const lockRadio = createElement("input", null, profileDiv);
    lockRadio.type = "radio";
    lockRadio.name = `user${profile._id}Locked`;
    lockRadio.value = "lock";
    lockRadio.checked = true;

    createElement("label", "Unlock", profileDiv);
    const unlockRadio = createElement("input", null, profileDiv);
    unlockRadio.type = "radio";
    unlockRadio.name = `user${profile._id}Locked`;
    unlockRadio.value = "unlock";

    createElement("hr", null, profileDiv);

    createElement("label", "Username", profileDiv);
    const nameInput = createElement("input", null, profileDiv);
    nameInput.type = "text";
    nameInput.name = "user1Username";
    nameInput.value = profile.username;
    nameInput.disabled = true;
    nameInput.readonly = true;

    const hiddenDiv = createElement("div", null, profileDiv, ["hiddenInfo"], "user1HiddenFields");
    createElement("hr", null, hiddenDiv);

    createElement("label", "Email:", hiddenDiv);
    const emailInput = createElement("input", null, hiddenDiv);
    emailInput.type = "email";
    emailInput.name = "user1Email";
    emailInput.value = profile.email;
    emailInput.disabled = true;
    emailInput.readonly = true;

    createElement("label", "Age:", hiddenDiv);
    const ageInput = createElement("input", null, hiddenDiv);
    ageInput.type = "email";
    ageInput.name = "user1Age";
    ageInput.value = profile.age;
    ageInput.disabled = true;
    ageInput.readonly = true;

    createElement("button", "Show more", profileDiv)
        .addEventListener("click", switchInfo);
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

function switchInfo(ev) {
    const checkedInput = document.querySelector("input:checked");

    if (checkedInput.value === "lock") {
        return;
    }

    const showInfo = ev.target.textContent === "Show more";
    Array.from(ev.target.parentNode.querySelector(".hiddenInfo").childNodes)
        .forEach(c => c.style.display = showInfo ? "block" : "none");
    ev.target.textContent = showInfo ? "Hide it" : "Show more";
}