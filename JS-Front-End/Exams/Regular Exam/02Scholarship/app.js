window.addEventListener("load", solve);

function solve() {
  const inputs = {
    name: document.getElementById("student"),
    university: document.getElementById("university"),
    score: document.getElementById("score")
  };

  const nextBtn = document.getElementById("next-btn");

  nextBtn.addEventListener("click", addToPreview);

  function addToPreview() {
    if (Object.values(inputs).some(i => i.value === "")) {
      return;
    }

    const previewUl = document.getElementById("preview-list");
    const applicationLi = createElement("li", null, previewUl, ["application"]);
    const article = createElement("article", null, applicationLi);

    createElement("h4", inputs.name.value, article);
    createElement("p", `University: ${inputs.university.value}`, article);
    createElement("p", `Score: ${inputs.score.value}`, article);

    createElement("button", "edit", applicationLi, ["action-btn", "edit"])
      .addEventListener("click", editInfo);
    createElement("button", "apply", applicationLi, ["action-btn", "apply"])
      .addEventListener("click", apply);

    nextBtn.disabled = true;
    Object.values(inputs).forEach(i => i.value = "");
  }

  function editInfo(ev) {
    const applicationLi = ev.target.parentNode;

    inputs.name.value = applicationLi.querySelector("h4").textContent;
    inputs.university.value = applicationLi.querySelector("p:first-of-type").textContent
      .replace("University: ", "");
    inputs.score.value = applicationLi.querySelector("p:last-of-type").textContent
      .replace("Score: ", "");

    applicationLi.remove();
    nextBtn.disabled = false;
  }

  function apply(ev) {
    const applicationLi = ev.target.parentNode;

    applicationLi.remove();
    Array.from(applicationLi.querySelectorAll("button"))
      .forEach(btn => btn.remove());

    document.getElementById("candidates-list").appendChild(applicationLi);
    nextBtn.disabled = false;
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
}