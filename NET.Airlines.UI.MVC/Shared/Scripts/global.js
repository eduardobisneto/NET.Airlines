var availableContinents = [];
var availableCountries = [];
var availableCities = [];

$(document).ready(function () {
    fnInitializeGlobal();

    $(document.body).on('click', '#location', function () {
        var id = $(this).attr('rel');
        var type = $(this).attr('data-type');

        switch (type) {
            case 'continents':
                fnFillLocation(availableContinents, 'countries', id);
                break;
            case 'countries':
                fnFillLocation(availableCountries, 'cities', id);
                break;
            case 'cities':
                break;
        }
    });
});

function fnHourDiff(start, end) {
    var ms = moment(end, "YYYY-MM-DDTHH:mm:ss").diff(moment(start, "YYYY-MM-DDTHH:mm:ss"));
    var d = moment.duration(ms);
    return Math.floor(d.asHours()) + "h" + moment.utc(ms).format(" mm") + "m";
}

function fnHour(d)
{
    var hours = new Date(d).getHours();
    return (hours.toString().length == 1 ? '0' + hours : hours);
}

function fnMinute(datetime) {
    var minutes = new Date(datetime).getMinutes();
    return (minutes.toString().length == 1 ? '0' + minutes : minutes);
}

function fnInitializeGlobal() {
    fnGetAllContinents();
}

function fnFillLocation(list, type, id) {
    $("#locations ul.dropdown-menu").empty();
    $.each(list, function (i, obj) {
        $("#locations ul.dropdown-menu").append('<li><a id="location" rel="' + obj.Id + '">' + obj.Description + '</a></li>');
    });
}

function fnGetAllContinents() {
    try {
        $.ajax({
            url: 'http://localhost:35143/api/location/getallcontinents',
            type: "GET",
            success: function (data, textStatus, xhr) {

                var result = data;
                try {
                    $.each(result, function (i, obj) {
                        availableContinents.push(obj);
                    });

                    fnFillLocation(availableContinents, 'countries');
                }
                catch (e) {
                }
            },
            error: function (xhr, status, error) {
            },
            beforeSend: function () {
            },
            complete: function () {
            }
        });
    }
    catch (err) {
    }
}

function fnGetAllCountries(continentId) {
    if (undefined == continentId)
        continentId = 0

    try {
        $.ajax({
            url: 'http://localhost:35143/api/location/getallcountries',
            type: "GET",
            data: '{ ContinentId: ' + continentId + ' }',
            success: function (data, textStatus, xhr) {
                var result = data;
                try {

                    $.each(result, function (i, obj) {
                        availableCountries.push(obj);
                    });
                }
                catch (e) {
                }
            },
            error: function (xhr, status, error) {
            },
            beforeSend: function () {
            },
            complete: function () {
            }
        });
    }
    catch (err) {
    }
}

function fnGetAllCities(countryId) {
    if (undefined == countryId)
        countryId = 0

    try {
        $.ajax({
            url: 'http://localhost:35143/api/location/getallcities',
            type: "GET",
            data: '{ CountryId: ' + countryId + ' }',
            success: function (data, textStatus, xhr) {
                var result = data;
                try {

                    $.each(result, function (i, obj) {
                        availableCities.push(obj);
                    });
                }
                catch (e) {
                }
            },
            error: function (xhr, status, error) {
            },
            beforeSend: function () {
            },
            complete: function () {
            }
        });
    }
    catch (err) {
    }
}