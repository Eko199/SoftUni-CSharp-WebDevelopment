const API_URL = "http://localhost:3030/jsonstore/advanced/articles";
const main = document.getElementById("main");

solution();

async function solution() {
    const articles = await (await fetch(`${API_URL}/list`)).json();
    articles.forEach(createAccordionElement);
}

function createAccordionElement(article) {
    const accordionDiv = createElement("div", null, main, ["accordion"]);

    const headDiv = createElement("div", null, accordionDiv, ["head"]);
    createElement("span", article.title, headDiv);
    createElement("button", "More", headDiv, ["button"], article._id)
        .addEventListener("click", toggleMoreInfo);

    const extraDiv = createElement("div", null, accordionDiv, ["extra"]);
    createElement("p", null, extraDiv);
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

async function toggleMoreInfo(ev) {
    const button = ev.target;
    const extraDiv = button.parentNode.parentNode.querySelector(".extra");

    if (button.textContent === "Less") {
        extraDiv.style.display = "none";
        button.textContent = "More";
        return;
    }

    const content = (await (await fetch(`${API_URL}/details/${button.id}`)).json()).content;
    extraDiv.querySelector("p").textContent = content;
    extraDiv.style.display = "block";
    button.textContent = "Less";
}