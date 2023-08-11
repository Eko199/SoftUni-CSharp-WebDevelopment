function attachEventsListeners() {
    const timeInputs = {
        days: document.getElementById("days"),
        hours: document.getElementById("hours"),
        minutes: document.getElementById("minutes"),
        seconds: document.getElementById("seconds"),
    };

    const converToSeconds = {
        days: d => d * 24 * 60 * 60,
        hours: h => h * 60 * 60,
        minutes: m => m * 60,
        seconds: s => s
    };

    Array.from(document.querySelectorAll("input[type='button']"))
        .forEach(btn => btn.addEventListener("click", convert));

    function convert(ev) {
        const currentType = ev.target.id.replace("Btn", "");
        const currentValue = Number(timeInputs[currentType].value);
        const secondsValue = converToSeconds[currentType](currentValue);

        timeInputs.days.value = secondsValue / 60 / 60 / 24;
        timeInputs.hours.value = secondsValue / 60 / 60;
        timeInputs.minutes.value = secondsValue / 60;
        timeInputs.seconds.value = secondsValue;
    }
}