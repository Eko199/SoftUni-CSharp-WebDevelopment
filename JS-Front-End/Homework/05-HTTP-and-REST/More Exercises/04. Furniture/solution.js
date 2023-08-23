const BASE_URL = "http://localhost:3030";

const navUser = document.getElementById("user");
const navGuest = document.getElementById("guest");
setUpLoggedNav();

const furnitureTbody = document.querySelector(".table tbody");

if (furnitureTbody) {
  loadData();
}

const registerInputs = {
  email: document.querySelector("form[action='/register'] input[name='email']"),
  password: document.querySelector("form[action='/register'] input[name='password']"),
  rePass: document.querySelector("form[action='/register'] input[name='rePass']")
};

const loginInputs = {
  email: document.querySelector("form[action='/login'] input[name='email']"),
  password: document.querySelector("form[action='/login'] input[name='password']")
};

const createInputs = {
  name: document.querySelector("input[name='name']"),
  price: document.querySelector("input[name='price']"),
  factor: document.querySelector("input[name='factor']"),
  img: document.querySelector("input[name='img']")
};

const logoutBtn = document.getElementById("logoutBtn");
logoutBtn.addEventListener("click", logout);

const registerBtn = document.querySelector("form[action='/register'] button");
const loginBtn = document.querySelector("form[action='/login'] button");

if (loginBtn) {
  registerBtn.addEventListener("click", register);
  loginBtn.addEventListener("click", login);
}

const createBtn = document.querySelector("#create-form button");
const buyBtn = document.querySelector(".col-md-12 > button");
const showBtn = document.getElementById("show-orders-btn");

if (createBtn) {
  createBtn.addEventListener("click", createFurniture);
  buyBtn.addEventListener("click", buyFurniture);
  showBtn.addEventListener("click", showOrders);
}

function solve() {
  window.location.href = "home.html";
}

async function loadData() {
  const furniture = await (
    await fetch(`${BASE_URL}/data/furniture`)
  ).json();

  furnitureTbody.innerHTML = "";
  furniture.forEach(createFurnitureElement);
}

function createFurnitureElement(furniture) {
  const tr = createElement("tr", null, furnitureTbody);

  const imgTd = createElement("td", null, tr);
  createElement("img", null, imgTd).src = furniture.img;

  const nameTd = createElement("td", null, tr);
  createElement("p", furniture.name, nameTd);

  const priceTd = createElement("td", null, tr);
  createElement("p", furniture.price, priceTd);

  const decFactorTd = createElement("td", null, tr);
  createElement("p", furniture.factor, decFactorTd);

  const checkboxTd = createElement("td", null, tr);
  const checkbox = createElement("input", null, checkboxTd);
  checkbox.type = "checkbox";
  checkbox.disabled = localStorage.getItem("user") ? false : true;

  return tr;
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

async function logout() {
  await fetch(`${BASE_URL}/users/logout`, {
    headers: { "x-authorization": localStorage.getItem("accessToken") }
  });

  localStorage.removeItem("user");
  localStorage.removeItem("accessToken");
  window.location.href = "home.html";
}

async function register(ev) {
  ev.preventDefault();

  if (Object.values(registerInputs).some(i => i.value === "")) {
    return;
  }

  if (registerInputs.password.value !== registerInputs.rePass.value) {
    return;
  }

  const user = {
    email: registerInputs.email.value,
    password: registerInputs.password.value
  };

  const response = await fetch(`${BASE_URL}/users/register`, {
    method: "POST",
    headers: { "Content-type": "application/json" },
    body: JSON.stringify(user)
  });

  const resData = await response.json();

  if (!response.ok) {
    return;
  }

  user._id = resData._id;
  localStorage.setItem("user", JSON.stringify(user));
  localStorage.setItem("accessToken", resData.accessToken);
  window.location.href = "homeLogged.html";
}

async function login(ev) {
  ev.preventDefault();

  if (Object.values(loginInputs).some(i => i.value === "")) {
    return;
  }

  const user = {
    email: loginInputs.email.value,
    password: loginInputs.password.value
  };

  const response = await fetch(`${BASE_URL}/users/login`, {
    method: "POST",
    headers: { "Content-type": "application/json" },
    body: JSON.stringify(user)
  });

  const resData = await response.json();

  if (!response.ok) {
    return;
  }

  user._id = resData._id;
  localStorage.setItem("user", JSON.stringify(user));
  localStorage.setItem("accessToken", resData.accessToken);
  window.location.href = "homeLogged.html";
}

function setUpLoggedNav() {
  const user = JSON.parse(localStorage.getItem("user"));

  navUser.style.display = user ? "inline-block" : "none";
  navGuest.style.display = user ? "none" : "inline-block";
}

async function createFurniture(ev) {
  ev.preventDefault();

  if (Object.values(createInputs).some(i => i.value === "")) {
    return;
  }

  await fetch(`${BASE_URL}/data/furniture`, {
    method: "POST",
    headers: { 
      "Content-type": "application/json",
      "x-authorization": localStorage.getItem("accessToken")
    },
    body: JSON.stringify({
      name: createInputs.name.value,
      price: createInputs.price.value,
      factor: createInputs.factor.value,
      img: createInputs.img.value
    })
  });

  await loadData();
}

async function buyFurniture() {
  const boughtFurniture = Array.from(document.querySelectorAll("tbody tr"))
    .filter(tr => tr.querySelector("input").checked)
    .map(tr => ({
      name: tr.querySelector("td:nth-of-type(2) p").textContent,
      price: Number(tr.querySelector("td:nth-of-type(3) p").textContent),
      factor: tr.querySelector("td:nth-of-type(4) p").textContent,
      img: tr.querySelector("td:first-of-type img").src
    }));

  await fetch(`${BASE_URL}/data/orders`, {
    method: "POST",
    headers: { 
      "Content-type": "application/json",
      "x-authorization": localStorage.getItem("accessToken")
    },
    body: JSON.stringify(boughtFurniture)
  });
}

async function showOrders() {
  const orders = [];

  try {
    orders = await (
      await fetch(`${BASE_URL}/data/orders?where=_ownerId%3D${JSON.parse(localStorage.getItem("user"))._id}`)
    ).json();
  } catch(e) {
    console.log(e.message);
  }

  const [furnitureNames, totalPrice] = Array.from(document.querySelectorAll(".orders span"));

  if (orders.length === 0) {
    furnitureNames.textContent = "Nothing bought yet!";
    totalPrice.textContent = "0 $";
  } else {
    furnitureNames.textContent = orders.map(o => o.name).join(", ");
    totalPrice.textContent = `${orders.reduce((acc, curr) => acc + Number(curr.price), 0)} $`;
  }
}