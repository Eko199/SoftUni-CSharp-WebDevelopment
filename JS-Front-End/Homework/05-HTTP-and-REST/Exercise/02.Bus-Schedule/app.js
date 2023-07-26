function solve() {
    const departBtn = document.getElementById("depart");
    const arriveBtn = document.getElementById("arrive");
    const info = document.querySelector("#info .info");

    let stopId = "depot";

    function depart() {
        fetch(`http://localhost:3030/jsonstore/bus/schedule/${stopId}`)
            .then(res => res.json())
            .then(stop => {
                departBtn.disabled = true;
                arriveBtn.disabled = false;

                info.innerText = `Next stop ${stop.name}`;
            })
            .catch(error);
    }

    async function arrive() {
        try {
            const stop = await (
                await fetch(`http://localhost:3030/jsonstore/bus/schedule/${stopId}`)
            ).json();

            departBtn.disabled = false;
            arriveBtn.disabled = true;

            info.innerText = `Arriving at ${stop.name}`;
            stopId = stop.next;
        } catch(_) {
            error();
        }
    }

    function error() {
        departBtn.disabled = true;
        arriveBtn.disabled = true;
        
        info.innerText = "Error";
    }

    return {
        depart,
        arrive
    };
}

let result = solve();