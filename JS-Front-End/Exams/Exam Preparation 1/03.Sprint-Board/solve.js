const API_URL = "http://localhost:3030/jsonstore/tasks/";

const statusSectionsUlMap = {
    "ToDo": document.querySelector("#todo-section .task-list"),
    "In Progress": document.querySelector("#in-progress-section .task-list"),
    "Code Review": document.querySelector("#code-review-section .task-list"),
    "Done": document.querySelector("#done-section .task-list")
};

const statusToTaskButtonMap = {
    "ToDo": "Move to In Progress",
    "In Progress": "Move to Code Review",
    "Code Review": "Move to Done",
    "Done": "Close"
};

function attachEvents() {
    document.getElementById("load-board-btn").addEventListener("click", loadBoard);
    document.getElementById("create-task-btn").addEventListener("click", addTask);
}

async function loadBoard() {
    const tasks = await (await fetch(API_URL)).json();

    Object.values(statusSectionsUlMap)
        .forEach(ul => ul.innerHTML = "");

    Object.values(tasks).forEach(task => {
        const li = createElement("li", null, null, ["task"], statusSectionsUlMap[task.status]);
        createElement("h3", task.title, null, [], li);
        createElement("p", task.description, null, [], li);

        const button = createElement("button", statusToTaskButtonMap[task.status], null, [], li);
        button.setAttribute("data-taskid", task._id);
        button.addEventListener("click", moveTask);
    });
}

async function addTask() {
    const titleInput = document.getElementById("title");
    const descriptionInput = document.getElementById("description");

    await fetch(API_URL, {
        method: "POST",
        headers: { "Content-type": "application/json" },
        body: JSON.stringify({
            title: titleInput.value,
            description: descriptionInput.value,
            status: "ToDo"
        })
    });

    titleInput.value = "";
    descriptionInput.value = "";

    await loadBoard();
}

async function moveTask(e) {
    const taskId = e.target.dataset.taskid;

    if (e.target.innerText === "Close") {
        await closeTask(taskId);
        return;
    }

    await fetch(`${API_URL}${taskId}`, {
        method: "PATCH",
        headers: { "Content-type": "application/json" },
        body: JSON.stringify({
            status: e.target.innerText.replace("Move to ", "")
        })
    });

    await loadBoard();
}

async function closeTask(taskId) {
    await fetch(`${API_URL}${taskId}`, { method: "DELETE" });
    await loadBoard();
}

function createElement(type, text, id, classes, parent, useInnerHTML = false) {
    if (!type) return;

    const element = document.createElement(type);

    if (text) {
        useInnerHTML 
            ? element.innerHTML = text
            : element.innerText = text;
    }

    if (id) {
        element.id = id;
    }

    if (classes && classes.length > 0) {
        element.classList.add(...classes);
    }

    if (parent) {
        parent.appendChild(element);
    }

    return element;
}

attachEvents();