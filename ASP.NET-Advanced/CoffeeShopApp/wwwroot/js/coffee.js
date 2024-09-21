const connection = new signalR.HubConnectionBuilder().withUrl("/coffeeHub").build();

connection.on("ReceiveOrderUpdate",
    update => document.getElementById("status").innerText = update);

connection.on("NewOrder",
    order => document.getElementById("status").innerText = `Someone ordered a ${order.product}`);

connection.on("Finished", connection.stop);

connection.start()
    .catch(err => console.error(err.toString()));

document.getElementById("submit").addEventListener("click", e => {
    e.preventDefault();
    const product = document.getElementById("product").value;
    const size = document.getElementById("size").value;

    fetch("/Coffee/OrderCoffee", {
        method: "POST",
        body: JSON.stringify({ product, size }),
        headers: {
            'content-type': 'application/json'
        }
    })
        .then(response => response.text())
        .then(id => connection.invoke("GetUpdateForOrder", Number(id)));
});