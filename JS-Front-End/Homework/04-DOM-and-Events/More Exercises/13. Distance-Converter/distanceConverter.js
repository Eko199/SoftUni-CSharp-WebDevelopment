function attachEventsListeners() {
    const metersConvertionMap = {
        km: 1000,
        m: 1,
        cm: 0.01,
        mm: 0.001,
        mi: 1609.34,
        yrd: 0.9144,
        ft: 0.3048,
        in: 0.0254
    };

    const inputUnits = document.getElementById("inputUnits");
    const outputUnits = document.getElementById("outputUnits");

    const input = document.getElementById("inputDistance");
    const output = document.getElementById("outputDistance");

    document.getElementById("convert").addEventListener("click", convert);

    function convert() {
        output.value = Number(input.value) * metersConvertionMap[inputUnits.value] / metersConvertionMap[outputUnits.value];
    }
}