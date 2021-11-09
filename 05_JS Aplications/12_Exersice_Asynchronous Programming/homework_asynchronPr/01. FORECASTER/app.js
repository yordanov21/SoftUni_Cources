function attachEvents() {
    let url = 'https://judgetests.firebaseio.com/locations.json'
    let location = document.getElementById('location');
    let submitBtn = document.getElementById('submit');
    let currentCondition = document.getElementById('current');
    let upcomingCondition = document.getElementById('upcoming');
    let forecast = document.getElementById('forecast');

    submitBtn.addEventListener('click', async() => {
        if (currentCondition.children.length > 1) {
            currentCondition.removeChild(currentCondition.children[1]);
            upcomingCondition.removeChild(upcomingCondition.children[1]);
        }

        let resources = await fetch(url);
        let data = await resources.json();
        let currentConditionUrl;
        let upcomingConditionUrl;

        for (const currData of data) {
            if (currData.name === location.value) {
                currentConditionUrl = `https://judgetests.firebaseio.com/forecast/today/${currData.code}.json`;
                upcomingConditionUrl = `https://judgetests.firebaseio.com/forecast/upcoming/${currData.code}.json`;
                break;
            }
        }

        try {
            resources = await fetch(currentConditionUrl)
        } catch (err) {
            console.log('Error');
            return;
        }

        data = await resources.json();
        forecast.style.display = 'block';
        currentWeather(data);

        try {
            resources = await fetch(upcomingConditionUrl)
        } catch (err) {
            console.log('Error');
            return;
        }

        data = await resources.json();
        upcomingWeather(data)
    });

    function currentWeather(data) {
        let forecasts = document.createElement('div');
        forecasts.className = 'forecasts';

        let weather = getWeather(data.forecast);
        forecasts.appendChild(weather.symbol);

        let condition = document.createElement('span');
        condition.className = 'condition';

        let city = document.createElement('span');
        city.className = 'forecast-data';
        city.textContent = data.name;

        condition.appendChild(city);
        condition.appendChild(weather.degrees);
        condition.appendChild(weather.weather);
        forecasts.appendChild(condition);
        currentCondition.appendChild(forecasts);
    }

    function upcomingWeather(data) {
        let forecastInfo = document.createElement('div');
        forecastInfo.className = 'forecast-info';

        for (const currData of data.forecast) {
            let upcoming = document.createElement('span');
            upcoming.className = 'upcoming';

            let weather = getWeather(currData, upcoming);
            upcoming.appendChild(weather.symbol);
            upcoming.appendChild(weather.degrees);
            upcoming.appendChild(weather.weather);

            forecastInfo.appendChild(upcoming);
        }

        upcomingCondition.appendChild(forecastInfo);
    }

    function getWeather(data) {
        let symbol = document.createElement('span');
        symbol.className = 'symbol';
        symbol.textContent = getSymbol(data.condition);

        let degrees = document.createElement('span');
        degrees.className = 'forecast-data';
        degrees.textContent = `${data.low}°/${data.high}°`;

        let weather = document.createElement('span');
        weather.className = 'forecast-data';
        weather.textContent = data.condition;

        return { symbol, degrees, weather };
    }

    function getSymbol(condition) {
        let conditions = {
            Sunny: '☀',
            'Partly sunny': '⛅',
            Overcast: '☁',
            Rain: '☂'
        }

        return conditions[condition];
    }
}

attachEvents();



// (() => {

//     const BASE_URL = 'https://judgetests.firebaseio.com/locations.json.'
//     const TODAY_URL = 'https://judgetests.firebaseio.com/forecast/{status}/{code}.json';
//     const elements = {
//         locationInput: document.querySelector("#location"),
//         button: document.querySelector('#submit'),
//         notificationHeading: document.querySelector('h1.notification'),
//         currentDiv: document.querySelector('#current'),
//         upcomingDiv: document.querySelector('#upcoming'),
//         forecastWrapper: document.querySelector('#forecast')
//     };

//     const weatherSymbols = {
//         's': '☀',
//         'p': '⛅',
//         'o': '☁',
//         'r': '☂',
//         'd': '°'
//     }

//     const errorHandler = (e) => {
//         console.dir(e);
//         elements.notificationHeading.textContent = e.message;
//     }

//     const jsonMiddleware = (r) => r.json();

//     elements.button.addEventListener('click', getLocationValue)

//     function getLocationValue() {
//         const location = elements.locationInput.value;

//         fetch(BASE_URL)
//             .then(jsonMiddleware)
//             .then((data) => {
//                 const { name, code } = data.find((o) => o.name === location);
//                 const Current_TODAY_URL = TODAY_URL.replace('{status}/{code}', `today/${code}`)
//                 const Current_UPCOMING_URL = TODAY_URL.replace('{status}/{code}', `upcoming/${code}`)

//                 Promise.all([
//                         fetch(Current_TODAY_URL).then(jsonMiddleware),
//                         fetch(Current_UPCOMING_URL).then(jsonMiddleware)
//                     ])
//                     .then(showWeatherLocation)
//                     .catch(errorHandler)

//             })
//             .catch(errorHandler)

//     }

//     function showWeatherLocation([todayData, upcomingData]) {
//         const { condition, high, low } = todayData.forecast

//         let forecastsDiv = createHTMLElement('div', ['forecasts']);
//         let symbolSpan = createHTMLElement('span', ['condition', 'symbol'], weatherSymbols[condition[0].tolowerCase()]);
//         let conditionSpan = createHTMLElement('span', ['condition']);

//         let forecastFirstDataSpan = createHTMLElement('span', ['forecast-data'], todayData.name);

//         let degreesInfo = `${low}${weatherSymbols.d}/${high}${weatherSymbols.d}`;

//         let forecastSecondDataSpan = createHTMLElement('span', ['forecast-data'], degreesInfo);
//         let forecastThirdDataSpan = createHTMLElement('span', ['forecast-data'], condition);

//         conditionSpan.appendChild(forecastFirstDataSpan);
//         conditionSpan.appendChild(forecastSecondDataSpan);
//         conditionSpan.appendChild(forecastThirdDataSpan);

//         forecastsDiv.appendChild(symbolSpan);
//         forecastsDiv.appendChild(conditionSpan);

//         elements.currentDiv.appendChild(forecastsDiv);
//         elements.forecastWrapper.style.display = 'block';
//     }
// })();

// function createHTMLElement(tagName, classNames, textContent) {
//     let element = document.createElement(tagName);

//     if (classNames) {
//         element.classList.add(...classNames);
//     }
//     if (textContent) {
//         element.textContent = textContent;
//     }

//     return element;
// }