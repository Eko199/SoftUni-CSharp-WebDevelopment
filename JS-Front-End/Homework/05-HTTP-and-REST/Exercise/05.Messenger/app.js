function attachEvents() {
    document.getElementById("submit").addEventListener("click", sendMessage);
    document.getElementById("refresh").addEventListener("click", refreshMessages);
}

async function sendMessage() {
    await fetch("http://localhost:3030/jsonstore/messenger", {
        method: "POST",
        headers: { "Content-type": "application/json" },
        body: JSON.stringify({
            author: document.querySelector("input[name='author']").value,
            content: document.querySelector("input[name='content']").value
        })
    });
}

async function refreshMessages() {
    const messages = Object.values(await (
        await fetch("http://localhost:3030/jsonstore/messenger")
    ).json());
    
    document.getElementById("messages").textContent = messages
        .map(m => `${m.author}: ${m.content}`)
        .join("\n");
}

attachEvents();