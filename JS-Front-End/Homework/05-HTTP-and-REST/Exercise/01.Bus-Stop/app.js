function getInfo() {
    const stopId = document.getElementById("stopId").value;
    const busList = document.getElementById("buses");
    busList.innerHTML = "";

    fetch(`http://localhost:3030/jsonstore/bus/businfo/${stopId}`)
        .then(res => res.json())
        .then(stop => {
            document.getElementById("stopName").innerText = stop.name;

            Object.entries(stop.buses).forEach(([busId, time]) => {
                const li = document.createElement("li");
                li.innerText = `Bus ${busId} arrives in ${time} minutes`;
                busList.appendChild(li);
            });
        })
        .catch(() => {
            document.getElementById("stopName").innerText = "Error";
        });
}