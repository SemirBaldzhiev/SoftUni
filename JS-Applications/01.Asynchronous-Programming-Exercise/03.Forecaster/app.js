function attachEvents() {
    
    let buttonElement = document.getElementById('submit');

    buttonElement.addEventListener('click', forecastHandler)

    let conditions = {
        Sunny: '☀',
        'Partly sunny': '⛅',
        Overcast: '☁',
        Rain: '☂'
    }

    function forecastHandler(){
        let url = 'http://localhost:3030/jsonstore/forecaster/locations';
        let location = document.getElementById('location');
        let forecastDivElement = document.getElementById('forecast');
        let currentWeatherDiv = document.getElementById('current');
        Array.from(currentWeatherDiv.querySelectorAll('div')).forEach((el, i) => {
            i !== 0 ? el.remove() : el;
        });
        let upcomingWeatherDiv = document.getElementById('upcoming');
        Array.from(upcomingWeatherDiv.querySelectorAll('div')).forEach((el, i) => {
            i !== 0 ? el.remove() : el;
        });

      
        fetch(url)
            .then(res => res.json())
            .then(data => {

                //let forecastDivElement = document.getElementById('forecast');
                let searchedLocation = data.find(x => x.name == location.value);
                let locationCode = searchedLocation.code;
                console.log(searchedLocation);  
                console.log(locationCode);

                let curPromise = fetch(`http://localhost:3030/jsonstore/forecaster/today/${locationCode}`) 
                    .then(res => res.json())
                    .then(currentWeather => {
                        //console.log(currentWeather);
                        let forecast = currentWeather.forecast;

                        let forecastDiv = document.createElement('div');
                        forecastDiv.classList.add('forecasts');

                        let conditionSymbol = document.createElement('span');
                        conditionSymbol.classList.add('condition');
                        conditionSymbol.classList.add('symbol');
                        conditionSymbol.textContent = conditions[forecast.condition];

                        let conditionSpan = document.createElement('span');
                        conditionSpan.classList.add('condition');

                        let nameSpan = document.createElement('span');
                        nameSpan.classList.add('forecast-data');
                        nameSpan.textContent = currentWeather.name;

                        let tempSpan = document.createElement('span');
                        tempSpan.classList.add('forecast-data');
                        tempSpan.textContent = `${forecast.low}°/${forecast.high}°`;

                        let conditionSymbolSpan = document.createElement('span');
                        conditionSymbolSpan.classList.add('forecast-data');
                        conditionSymbolSpan.textContent = `${forecast.condition}`;

                        conditionSpan.appendChild(nameSpan);
                        conditionSpan.appendChild(tempSpan);
                        conditionSpan.appendChild(conditionSymbolSpan);

                        forecastDiv.appendChild(conditionSymbol);
                        forecastDiv.appendChild(conditionSpan);
                        currentWeatherDiv.appendChild(forecastDiv);

                    });

                let upcPromise = fetch(`http://localhost:3030/jsonstore/forecaster/upcoming/${locationCode}`)
                    .then(res => res.json())
                    .then(upcomingWeather => {
                       
                        //let upcomingWeatherDiv = document.getElementById('upcoming');
                       
                        
                        let upcomingForecastDiv = document.createElement('div');
                        upcomingForecastDiv.classList.add('forecast-info');

                        Object.keys(upcomingWeather.forecast).forEach(w => {
                            
                            let weatherSpan = createWeatherSpan(upcomingWeather.forecast[w])
                            upcomingForecastDiv.appendChild(weatherSpan);
                        });

                        
                        upcomingWeatherDiv.appendChild(upcomingForecastDiv);

                    });

                   Promise.all([curPromise, upcPromise])
                        .then(x => {
                            forecastDivElement.style.display = 'block';
                        });
                        
            })
            .catch(error => {
                
                let errorDiv = document.createElement('div');
                errorDiv.classList.add('label');
                errorDiv.textContent = 'Error';
                currentWeatherDiv.appendChild(errorDiv);
            });

            function createWeatherSpan(w){
                let upcomingConditionSpan =document.createElement('span');
                upcomingConditionSpan.classList.add('upcoming');

                let upcomingSymbolSpan = document.createElement('span');
                upcomingSymbolSpan.classList.add('symbol');
                upcomingSymbolSpan.textContent = conditions[w.condition];

                let upcomingTempSpan = document.createElement('span');
                upcomingTempSpan.classList.add('forecast-data');
                upcomingTempSpan.textContent = `${w.low}°/${w.high}°`;

                let upcomingConditionSymbolSpan = document.createElement('span');
                upcomingConditionSymbolSpan.classList.add('forecast-data');
                upcomingConditionSymbolSpan.textContent = `${w.condition}`;

                upcomingConditionSpan.appendChild(upcomingSymbolSpan);
                upcomingConditionSpan.appendChild(upcomingTempSpan);
                upcomingConditionSpan.appendChild(upcomingConditionSymbolSpan);

                return upcomingConditionSpan;
            }

       
    }

}

attachEvents();