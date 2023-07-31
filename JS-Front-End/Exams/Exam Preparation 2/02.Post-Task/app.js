window.addEventListener("load", solve);

function solve() {
    const inputs = {
        title: document.getElementById("task-title"),
        category: document.getElementById("task-category"),
        content: document.getElementById("task-content")
    };

    document.getElementById("publish-btn").addEventListener("click", addTask);

    function addTask() {
        if (Object.values(inputs).some(i => i.value === "")) {
            return;
        }

        const reviewList = document.getElementById("review-list");
        const taskLi = createElement("li", null, reviewList, ["rpost"]);
        const article = createElement("article", null, taskLi);

        createElement("h4", inputs.title.value, article);
        createElement("p", `Category: ${inputs.category.value}`, article);
        createElement("p", `Content: ${inputs.content.value}`, article);

        createElement("button", "Edit", taskLi, ["action-btn", "edit"])
            .addEventListener("click", editTask);
        createElement("button", "Post", taskLi, ["action-btn", "post"])
            .addEventListener("click", postTask);

        Object.values(inputs).forEach(i => i.value = "");
    }

    function editTask(e) {
        const taskLi = e.target.parentNode;

        inputs.title.value = taskLi.querySelector("h4").innerText;
        inputs.category.value = taskLi.querySelector("p:first-of-type").innerText
            .replace("Category: ", "");
        inputs.content.value = taskLi.querySelector("p:last-child").innerText
            .replace("Content: ", "");

        taskLi.remove();
    }

    function postTask(e) {
        const taskLi = e.target.parentNode;
        
        e.target.remove();
        taskLi.querySelector("button").remove();
        
        const postList = document.getElementById("published-list");
        taskLi.remove();
        postList.appendChild(taskLi);
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