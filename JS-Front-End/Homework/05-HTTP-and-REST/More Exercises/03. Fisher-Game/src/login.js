import setUpTab from "./setUpTab.js";

setUpTab();

const inputs = {
    email: document.querySelector("input[name='email']"),
    password: document.querySelector("input[name='password']")
};
const notification = document.querySelector(".notification");

document.querySelector("button").addEventListener("click", login);

async function login(ev) {
    ev.preventDefault();

    try {
        if (Object.values(inputs).some(i => i.value === "")) {
            throw new Error("Please enter both fields!");
        }

        const user = {
            email: inputs.email.value,
            password: inputs.password.value
        };

        const response = await fetch("http://localhost:3030/users/login", {
            method: "POST",
            headers: { "Content-type": "application/json" },
            body: JSON.stringify(user)
        });

        const resData = await response.json();

        if (!response.ok) {
            throw new Error(resData.message);
        }

        user._id = resData._id;
        localStorage.setItem("user", JSON.stringify(user));
        localStorage.setItem("accessToken", resData.accessToken);
        window.location.href = "index.html";
    } catch(e) {
        notification.textContent = e.message;
    }
}