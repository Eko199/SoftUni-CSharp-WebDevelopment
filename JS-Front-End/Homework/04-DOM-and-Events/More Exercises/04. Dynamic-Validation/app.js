function validate() {
    document.getElementById("email").addEventListener("change", ev => {
        if (ev.target.value.match(/^[a-z]+@[a-z]+\.[a-z]+$/)) {
            ev.target.classList.remove("error");
        } else {
            ev.target.classList.add("error");
        }
    });
}