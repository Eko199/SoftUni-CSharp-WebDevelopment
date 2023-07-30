window.addEventListener('load', solve);

function solve() {
    const tasks = {};

    const inputs = {
        title: document.getElementById("title"),
        description: document.getElementById("description"),
        label: document.getElementById("label"),
        points: document.getElementById("points"),
        assignee: document.getElementById("assignee")
    }

    const createButton = document.getElementById("create-task-btn");
    const deleteButton = document.getElementById("delete-task-btn");
    const idInput = document.getElementById("task-id");

    const labelClassesMap = {
        "Feature": "feature",
        "Low Priority Bug": "low-priority",
        "High Priority Bug": "high-priority"
    };

    const labelIconsMap = {
        "Feature": "&#8865;",
        "Low Priority Bug": "&#9737;",
        "High Priority Bug": "&#9888;"
    };

    createButton.addEventListener("click", addTask);
    deleteButton.addEventListener("click", deleteTask);

    function addTask() {
        if (Object.values(inputs).some(i => i.value === ""))
            return;

        const task = {
            id: `task-${Object.keys(tasks).length + 1}`,
            title: inputs.title.value,
            description: inputs.description.value,
            label: inputs.label.value,
            points: Number(inputs.points.value),
            assignee: inputs.assignee.value
        };

        tasks[task.id] = task;

        const tasksSection = document.getElementById("tasks-section");
        const taskArticle = createElement("article", null, task.id, ["task-card"], tasksSection);

        createElement("div", `${task.label} ${labelIconsMap[task.label]}`, null, ["task-card-label", labelClassesMap[task.label]], taskArticle, true);
        createElement("h3", task.title, null, ["task-card-title"], taskArticle);
        createElement("p", task.description, null, ["task-card-description"], taskArticle);
        createElement("div", `Estimated at ${task.points} pts`, null, ["task-card-points"], taskArticle);
        createElement("div", `Assigned to: ${task.assignee}`, null, ["task-card-assignee"], taskArticle);
        const taskButtonsDiv = createElement("div", null, null, ["task-card-actions"], taskArticle);
        createElement("button", "Delete", null, [], taskButtonsDiv)
            .addEventListener("click", loadDelete);

        Object.values(inputs).forEach(i => i.value = "");
        updatePointsSum();
    }

    function updatePointsSum() {
        const totalPoints = Object.values(tasks).reduce((acc, curr) => acc + curr.points, 0);
        document.getElementById("total-sprint-points").innerText = `Total Points ${totalPoints}pts`;
    }

    function loadDelete(e) {
        const task = tasks[e.target.parentElement.parentElement.id];

        inputs.title.value = task.title;
        inputs.description.value = task.description;
        inputs.label.value = task.label;
        inputs.points.value = task.points;
        inputs.assignee.value = task.assignee;
        idInput.value = task.id;

        createButton.disabled = true;
        deleteButton.disabled = false;
        Object.values(inputs).forEach(i => i.disabled = true);
    }

    function deleteTask() {
        const taskId = idInput.value;

        document.getElementById(taskId).remove();
        delete tasks[taskId];

        Object.values(inputs).forEach(i => {
            i.value = "";
            i.disabled = false;
        });

        idInput.value = "";

        createButton.disabled = false;
        deleteButton.disabled = true;

        updatePointsSum();
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
}