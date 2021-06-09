function attachEventsListeners() {

    let inputDaysElement = document.querySelector('#days');
    let convertDaysButtonElement = document.querySelector('#daysBtn');

    let inputHoursElement = document.querySelector('#hours');
    let convertHoursButtonElement = document.querySelector('#hoursBtn');

    let inputMinutesElement = document.querySelector('#minutes');
    let convertMinutesButtonElement = document.querySelector('#minutesBtn');

    let inputSecondsElement = document.querySelector('#seconds');
    let convertSecondsButtonElement = document.querySelector('#secondsBtn');

    convertDaysButtonElement.addEventListener('click', convertDays);
    convertHoursButtonElement.addEventListener('click', convertHours);
    convertMinutesButtonElement.addEventListener('click', convertMinutes);
    convertSecondsButtonElement.addEventListener('click', convertSeconds);

    function convertDays(){
        let days = Number(inputDaysElement.value);

        let hours = days * 24;
        let minutes = hours * 60;
        let seconds = minutes * 60;

        inputHoursElement.value = hours;
        inputMinutesElement.value = minutes;
        inputSecondsElement.value = seconds;
    }

    function convertHours(){
        let hours = Number(inputHoursElement.value);

        let days = hours / 24;
        let minutes = hours * 60;
        let seconds = minutes * 60;

        inputDaysElement.value = days;
        inputMinutesElement.value = minutes;
        inputSecondsElement.value = seconds;
    }

    function convertMinutes(){
        let minutes = Number(inputMinutesElement.value);

        let hours = minutes / 60;
        let seconds = minutes * 60;
        let days = hours / 24;

        inputDaysElement.value = days;
        inputHoursElement.value = hours;
        inputSecondsElement.value = seconds;
    }

    function convertSeconds(){
        let seconds = Number(inputSecondsElement.value);

        let minutes = seconds / 60;
        let hours = minutes / 60;
        let days = hours / 24;

        inputDaysElement.value = days;
        inputHoursElement.value = hours;
        inputMinutesElement.value = minutes;
    }
}