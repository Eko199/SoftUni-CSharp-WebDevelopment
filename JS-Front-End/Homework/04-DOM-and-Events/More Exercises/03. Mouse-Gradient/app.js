function attachGradientEvents() {
    document.getElementById("gradient").addEventListener("mousemove", ev => {
        document.getElementById("result").textContent = 
            `${Math.floor(ev.offsetX / ev.target.clientWidth * 100)}%`;
    });
}