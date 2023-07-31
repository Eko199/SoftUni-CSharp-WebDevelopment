const API_URL = "http://localhost:3030/jsonstore/tasks/";

const inputs = {
    title: document.getElementById("course-name"),
    type: document.getElementById("course-type"),
    description: document.getElementById("description"),
    teacher: document.getElementById("teacher-name")
};

const addButton = document.getElementById("add-course");
const editButton = document.getElementById("edit-course");

attachEvents();

function attachEvents() {
    document.getElementById("load-course").addEventListener("click", loadCourses);
    addButton.addEventListener("click", addCourse);
    editButton.addEventListener("click", editCourse);
}

async function loadCourses() {
    const list = document.getElementById("list");
    list.innerHTML = "";

    const courses = Object.values(await (await fetch(API_URL)).json());
    courses.forEach(course => {
        const container = createElement("div", null, list, ["container"]);
        container.setAttribute("data-courseid", course._id);
        
        createElement("h2", course.title, container);
        createElement("h3", course.teacher, container);
        createElement("h3", course.type, container);
        createElement("h4", course.description, container);

        createElement("button", "Edit Course", container, ["edit-btn"])
            .addEventListener("click", loadEditCourse);
        createElement("button", "Finish Course", container, ["finish-btn"])
            .addEventListener("click", finishCourse);
    });
}

async function addCourse(e) {
    e.preventDefault();

    await fetch(API_URL, {
        method: "POST",
        headers: { "Content-type": "application/json" },
        body: JSON.stringify({
            title: inputs.title.value,
            type: inputs.type.value,
            description: inputs.description.value,
            teacher: inputs.teacher.value
        })
    });

    Object.values(inputs).forEach(i => i.value = "");
    await loadCourses();
}

async function loadEditCourse(e) {
    const courseContainer = e.target.parentNode;

    inputs.title.value = courseContainer.querySelector("h2").innerText;
    inputs.teacher.value = courseContainer.querySelector("h3:first-of-type").innerText;
    inputs.type.value = courseContainer.querySelector("h3:last-of-type").innerText;
    inputs.description.value = courseContainer.querySelector("h4").innerText;

    addButton.disabled = true;
    editButton.disabled = false;
    
    editButton.setAttribute("data-courseid", courseContainer.dataset.courseid);
    courseContainer.remove();
}

async function editCourse(e) {
    e.preventDefault();
    console.log(e.target.dataset.courseid)
    
    await fetch(`${API_URL}${e.target.dataset.courseid}`, {
        method: "PUT",
        headers: { "Content-type": "application/json" },
        body: JSON.stringify({
            title: inputs.title.value,
            type: inputs.type.value,
            description: inputs.description.value,
            teacher: inputs.teacher.value,
            _id: e.target.dataset.courseid
        })
    });

    Object.values(inputs).forEach(i => i.value = "");
    addButton.disabled = false;
    editButton.disabled = true;

    await loadCourses();
}

async function finishCourse(e) {
    await fetch(`${API_URL}${e.target.parentNode.dataset.courseid}`, {
        method: "DELETE" 
    });

    await loadCourses();
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