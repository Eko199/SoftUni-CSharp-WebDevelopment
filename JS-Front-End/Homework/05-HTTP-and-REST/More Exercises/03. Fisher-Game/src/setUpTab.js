export default function setUpTab() {
    const user = JSON.parse(localStorage.getItem("user"));

    if (user) {
        document.getElementById("guest").style.display = "none";
        document.querySelector(".email span").textContent = user.email;
        document.getElementById("logout").addEventListener("click", logout);
    } else {
        document.getElementById("user").style.display = "none";
    }
}

async function logout() {
    await fetch("http://localhost:3030/users/logout", {
        headers: { "x-authorization": localStorage.getItem("accessToken") }
    });

    localStorage.removeItem("user");
    localStorage.removeItem("accessToken");
    window.location.href = "index.html";
}