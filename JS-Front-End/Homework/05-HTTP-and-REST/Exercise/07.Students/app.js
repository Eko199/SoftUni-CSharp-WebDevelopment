async function attachEvents() {
  await loadStudents();
  document.getElementById("submit").addEventListener("click", addStudent);
}

async function addStudent() {
  await fetch("http://localhost:3030/jsonstore/collections/students", {
    method: "POST",
    headers: { "Content-type": "application/json" },
    body: JSON.stringify({
      firstName: document.querySelector("input[name='firstName']").value,
      lastName: document.querySelector("input[name='lastName']").value,
      facultyNumber: document.querySelector("input[name='facultyNumber']").value,
      grade: document.querySelector("input[name='grade']").value
    })
  });

  loadStudents();
}

async function loadStudents() {
  const tbody = document.querySelector("tbody");
  tbody.innerHTML = "";

  const students = Object.values(await (
    await fetch("http://localhost:3030/jsonstore/collections/students")
  ).json());

  students.forEach(s => tbody.appendChild(createStudentElement(s)));
}

function createStudentElement(student) {
  const tr = document.createElement("tr");

  const firstNameTd = document.createElement("td");
  firstNameTd.innerText = student.firstName;
  tr.appendChild(firstNameTd);

  const lastNameTd = document.createElement("td");
  lastNameTd.innerText = student.lastName;
  tr.appendChild(lastNameTd);

  const facultyNumberTd = document.createElement("td");
  facultyNumberTd.innerText = student.facultyNumber;
  tr.appendChild(facultyNumberTd);

  const gradeTd = document.createElement("td");
  gradeTd.innerText = student.grade;
  tr.appendChild(gradeTd);

  return tr;
}

attachEvents();