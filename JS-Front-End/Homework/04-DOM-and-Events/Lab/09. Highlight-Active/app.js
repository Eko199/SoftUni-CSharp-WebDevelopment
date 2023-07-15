function focused() {
    Array.from(document.getElementsByTagName("input"))
        .forEach(el => {
            el.addEventListener("focus", e => e.target.parentElement.className = "focused");
            el.addEventListener("blur", e => e.target.parentElement.className = "");
        });
}