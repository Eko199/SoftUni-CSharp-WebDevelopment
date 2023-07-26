function attachEvents() {
    document.getElementById("submit").addEventListener("click", submit);
}

async function submit() {
    const location = document.getElementById("location").value;
    const forecastSection = document.getElementById("forecast");

    try {
        const locations = await (
            await fetch("http://localhost:3030/jsonstore/forecaster/locations")
        ).json();

        const locationCode = locations.find(l => l.name === location).code;

        await setCurrentForecast(locationCode);
        await setUpcomingForecast(locationCode);
    } catch (_) {
        forecastSection.innerText = "Error";
    }

    forecastSection.style.display = "block";
}

async function setCurrentForecast(locationCode) {
    const container = document.getElementById("current");

    const { name, forecast } = await (
        await fetch(`http://localhost:3030/jsonstore/forecaster/today/${locationCode}`)
    ).json();

    const forecasts = document.createElement("div");
    forecasts.classList.add("forecasts");

    const symbol = document.createElement("span");
    symbol.classList.add("condition", "symbol");
    symbol.innerText = symbols[forecast.condition];
    forecasts.appendChild(symbol);

    const condition = document.createElement("span");
    condition.classList.add("condition");

    condition.appendChild(createForecastData(name));
    condition.appendChild(createForecastData(`${forecast.low}°/${forecast.high}°`));
    condition.appendChild(createForecastData(forecast.condition));
    
    forecasts.appendChild(condition);
    container.appendChild(forecasts);
}

async function setUpcomingForecast(locationCode) {
    const container = document.getElementById("upcoming");

    const { forecast } = await (
        await fetch(`http://localhost:3030/jsonstore/forecaster/upcoming/${locationCode}`)
    ).json();

    const forecastInfo = document.createElement("div");
    forecastInfo.classList.add("forecast-info");

    forecast.forEach(f => {
        const upcoming = document.createElement("span");
        upcoming.classList.add("upcoming");

        const symbol = document.createElement("span");
        symbol.classList.add("symbol");
        symbol.innerText = symbols[f.condition];
        upcoming.appendChild(symbol);

        upcoming.appendChild(createForecastData(`${f.low}°/${f.high}°`));
        upcoming.appendChild(createForecastData(f.condition));
        
        forecastInfo.appendChild(upcoming);
    });

    container.appendChild(forecastInfo);
}

function createForecastData(text) {
    const data = document.createElement("span");
    data.classList.add("forecast-data");
    data.innerText = text;

    return data;
}

const symbols = {
    "Sunny": "☀",
    "Partly sunny": "⛅",
    "Overcast": "☁",
    "Rain": "☂"
};

attachEvents();