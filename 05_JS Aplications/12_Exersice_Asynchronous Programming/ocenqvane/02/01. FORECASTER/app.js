function attachEvents() {
    const baseUrl = `https://judgetests.firebaseio.com/`;

    function fetchUrl() {
        return {
            location: () => fetch(`${baseUrl}locations.json`).then(data => data.json()),
            todayForecast: (code) => fetch(`${baseUrl}forecast/today/${code}.json`).then(data => data.json()),
            upcomingForecast: (code) => fetch(`${baseUrl}forecast/upcoming/${code}.json`).then(data => data.json())
        };
    }

    const htmlElements = {
        locationName: () => document.getElementById('location'),
        submitBtn: () => document.getElementById('submit'),
        forecastSection: () => document.getElementById('forecast'),
        currentDay: () => document.getElementById('current'),
        upcomingDays: () => document.getElementById('upcoming')
    };

    (function attachEvent() {
        htmlElements.submitBtn().addEventListener('click', submitFunction);
    })();

    const symbols = {
        sunny: '☀',
        partlysunny: '⛅',
        overcast: '☁',
        rain: '☂',
        degrees: '°'
    };

    function submitFunction() {
        const cityName = htmlElements.locationName().value;

        fetchUrl()
            .location()
            .then(data => findCity(data, cityName))
            .then(({
                name,
                code
            }) => getCityInfo(code))
            .then(([currentDay, nextDays]) => proceedInfo(currentDay, nextDays))
            .catch(() => {
                htmlElements.forecastSection().style.display = 'block';
                let div = createDomElement('div', ['error'], 'Error');
                htmlElements.forecastSection().appendChild(div);
            });
    }

    function findCity(data, cityName) {
        return data.find(str => str.name === cityName);
    }

    function getCityInfo(code) {
        return Promise.all([fetchUrl().todayForecast(code),
            fetchUrl().upcomingForecast(code)
        ]);
    }

    function proceedInfo(currentDay, nextDays) {
        htmlElements.forecastSection().style.display = 'block';

        proceedCurrentDay(currentDay);
        proceedNextDays(nextDays);
    }

    function proceedCurrentDay(currentDay) {
        let forecastDiv = createDomElement('div', ['forecasts']);
        let conditionSymbol = createDomElement('span', ['condition', 'symbol'], symbols[editSymbolName(currentDay.forecast)]);
        let conditionSpan = createDomElement('span', ['condition']);
        let citySpan = createDomElement('span', ['forecast-data'], currentDay.name);
        let temperatureSpan = createDomElement('span', ['forecast-data'],
            `${currentDay.forecast.low}${symbols.degrees}/${currentDay.forecast.high}${symbols.degrees}`
        );
        let weatherSpan = createDomElement('span', ['forecast-data'], currentDay.forecast.condition);

        conditionSpan.append(citySpan, temperatureSpan, weatherSpan);
        forecastDiv.append(conditionSymbol, conditionSpan);

        htmlElements.currentDay().appendChild(forecastDiv);
    }

    function proceedNextDays(nextDays) {
        let forecastDiv = createDomElement('div', ['forecast-info']);

        nextDays.forecast.forEach(day => {
            let upcomingSpan = createDomElement('span', ['upcoming']);
            let conditionSymbol = createDomElement('span', ['symbol'], symbols[editSymbolName(day)]);
            let temperatureSpan = createDomElement('span', ['forecast-data'],
                `${day.low}${symbols.degrees}/${day.high}${symbols.degrees}`
            );
            let weatherSpan = createDomElement('span', ['forecast-data'], day.condition);

            upcomingSpan.append(conditionSymbol, temperatureSpan, weatherSpan);
            forecastDiv.appendChild(upcomingSpan);
        });

        htmlElements.upcomingDays().appendChild(forecastDiv);
    }

    function editSymbolName(name) {
        return name.condition.toLowerCase().split('').filter(s => s !== ' ').join('');
    }

    function createDomElement(tag, classes, text) {
        const item = document.createElement(tag);
        item.classList.add(...classes);

        if (text) {
            item.textContent = text;
        }

        return item;
    }
}

attachEvents();