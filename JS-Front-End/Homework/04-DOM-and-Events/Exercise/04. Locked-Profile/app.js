function lockedProfile() {
    Array.from(document.getElementsByClassName("profile"))
        .forEach(p => p.querySelector("button").addEventListener("click", profileToggle));

    function profileToggle(e) {
        const button = e.target;
        const hiddenDiv = button.parentElement.querySelector("div");

        if (button.parentElement.querySelector("input[value='lock']").checked) {
            return;
        }

        if (hiddenDiv.style.display === "none" || hiddenDiv.style.display === "") {
            hiddenDiv.style.display = "block";
            button.innerText = "Hide it";
        } else {
            hiddenDiv.style.display = "none";
            button.innerText = "Show more";
        }
    }
}