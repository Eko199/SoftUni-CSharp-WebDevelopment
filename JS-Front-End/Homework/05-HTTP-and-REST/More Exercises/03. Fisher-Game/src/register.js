import setUpTab from "./setUpTab.js";

setUpTab();

const inputs = {
    email: document.querySelector("input[name='email']"),
    password: document.querySelector("input[name='password']"),
    rePassword: document.querySelector("input[name='rePass']")
};
const notification = document.querySelector(".notification");

document.querySelector("button").addEventListener("click", register);

async function register(ev) {
    ev.preventDefault();

    try {
        if (Object.values(inputs).some(i => i.value === "")) {
            throw new Error("Please enter all fields!");
        }

        if (inputs.password.value !== inputs.rePassword.value) {
            throw new Error("Passwords don't match!");
        }

        const user = {
            email: inputs.email.value,
            password: inputs.password.value
        };

        const response = await fetch("http://localhost:3030/users/register", {
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