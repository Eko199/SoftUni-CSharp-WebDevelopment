function attachEvents() {
  document.getElementById("loadBooks").addEventListener("click", loadBooks);
  document.querySelector("#form button").addEventListener("click", addBook);
}

async function loadBooks() {
  const tbody = document.querySelector("tbody");
  tbody.innerHTML = "";

  const books = Object.entries(await (
    await fetch("http://localhost:3030/jsonstore/collections/books")
  ).json());

  books.forEach(([key, book]) => tbody.appendChild(createBookElement(key, book)));
}

function createBookElement(key, book) {
  const tr = document.createElement("tr");

  const titleTd = document.createElement("td");
  titleTd.innerText = book.title;
  tr.appendChild(titleTd);

  const authorTd = document.createElement("td");
  authorTd.innerText = book.author;
  tr.appendChild(authorTd);

  const buttonsTd = document.createElement("td");
  
  const editButton = document.createElement("button");
  editButton.innerText = "Edit";
  editButton.addEventListener("click", () => editMode(key, book));
  buttonsTd.appendChild(editButton);
  
  const deleteButton = document.createElement("button");
  deleteButton.innerText = "Delete";
  deleteButton.setAttribute("data-bookid", key);
  deleteButton.addEventListener("click", deleteBook);
  buttonsTd.appendChild(deleteButton);

  tr.appendChild(buttonsTd);

  return tr;
}

function editMode(key, book) {
  document.querySelector("#form h3").innerText = "EDIT FORM";
  document.querySelector("input[name='title']").value = book.title;
  document.querySelector("input[name='author']").value = book.author;

  const button = document.querySelector("#form button");
  button.innerText = "Save";
  button.removeEventListener("click", addBook);
  button.addEventListener("click", () => editBook(key));
}

async function editBook(key) {
  const title = document.querySelector("input[name='title']").value;
  const author = document.querySelector("input[name='author']").value;

  if (!title || !author) 
    return;
  
  await fetch(`http://localhost:3030/jsonstore/collections/books/${key}`, {
    method: "PUT",
    headers: { "Content-type": "application/json" },
    body: JSON.stringify({ author, title })
  });

  document.querySelector("#form h3").innerText = "FORM";

  const button = document.querySelector("#form button");
  button.innerText = "Submit";
  button.removeEventListener("click", () => editBook(key));
  button.addEventListener("click", addBook);

  await loadBooks();
}

async function deleteBook(e) {
  await fetch(`http://localhost:3030/jsonstore/collections/books/${e.target.dataset.bookid}`, {
    method: "DELETE"
  });

  await loadBooks();
}

async function addBook() {
  const title = document.querySelector("input[name='title']").value;
  const author = document.querySelector("input[name='author']").value;

  if (!title || !author) 
    return;

  await fetch("http://localhost:3030/jsonstore/collections/books", {
    method: "POST",
    headers: { "Content-type": "application/json" },
    body: JSON.stringify({ author, title })
  });

  await loadBooks();
}

attachEvents();