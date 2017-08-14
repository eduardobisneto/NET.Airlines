var availableSources = [];
var availableDestinies = [];
var sourceID;
var destinyID;

$(document).ready(function () {
    fnInitialize();

    $("#search").click(function () {
        fnGetAllFlights();
    });

    $("#source").autocomplete({
        source: availableSources,
        response: function (event, ui) {
            if (!ui.content.length) {
                var noResult = { value: 0, label: "No cities found" };
                ui.content.push(noResult);
            }
        },
        select: function (event, ui) {
            if (ui.item.value > 0) {
                $("#source").val(ui.item.label);
                sourceID = ui.item.value;
            }
            else {
                $("#source").val("");
            }
            return false;
        },
        minLength: 1
    });

    $("#destiny").autocomplete({
        source: availableDestinies,
        response: function (event, ui) {
            if (!ui.content.length) {
                var noResult = { value: 0, label: "No cities found" };
                ui.content.push(noResult);
            }
        },
        select: function (event, ui) {
            if (ui.item.value > 0) {
                $("#destiny").val(ui.item.label);
                destinyID = ui.item.value;
            }
            else {
                $("#destiny").val("");
            }
            return false;
        },
        minLength: 1
    });

    $("#boarding").datepicker();
    $("#return").datepicker();

    $("#oneWay").click(function () {
        $("#boxReturn").hide();
        $("#withReturn").prop('checked', false);
    });

    $("#withReturn").click(function () {
        $("#boxReturn").show();
        $("#oneWay").prop('checked', false);
    });
});

function fnInitialize() {
    fnFillAdults();
    fnFillChilds();
    fnGetAllSources();
    fnGetAllDestinies();
}

function fnFillAdults() {
    var json = { "adults": [1, 2, 3, 4] };

    $.each(json.adults, (function (i, value) {
        $("#adults").append($('<option>', {
            text: value,
            value: value
        }));
    }));
};

function fnFillChilds() {
    var json = { "childs": [0, 1, 2, 3, 4] };

    $.each(json.childs, (function (i, value) {
        $("#childs").append($('<option>', {
            text: value,
            value: value
        }));
    }));
};

function fnGetAllDestinies() {
    try {
        $.ajax({
            url: 'http://localhost:35143/api/travel/getalldestinies',
            type: "GET",
            success: function (data, textStatus, xhr) {
                var result = data;
                try {

                    $.each(result, function (i, obj) {
                        availableDestinies.push({ 'value': obj.Id, 'label': obj.City.Description + ' - ' + obj.Description });
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

function fnGetAllSources() {
    try {
        $.ajax({
            url: 'http://localhost:35143/api/travel/getallsources',
            type: 'GET',
            success: function (data, textStatus, xhr) {
                var result = data;
                try {
                    $.each(result, function (i, obj) {
                        availableSources.push({ 'value': obj.Id, 'label': obj.City.Description + ' - ' + obj.Description });
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

function fnGetAllFlights() {
    try {
        $.ajax({
            url: 'http://localhost:35143/api/ticket/getalltickets',
            type: 'GET',
            success: function (data, textStatus, xhr) {
                var result = data;
                try {
                    var jumbotron = '';

                    $.each(result, function (i, ticket) {
                        var flights = ticket.Travel.Flights;
                        var flightTypeColor = 'limegreen';
                        var flightType = 'Direct';
                        var boarding = fnHour(ticket.Travel.Boarding) + ':' + fnMinute(ticket.Travel.Boarding);
                        var arrival = fnHour(ticket.Travel.Arrival) + ':' + fnMinute(ticket.Travel.Arrival);
                        var hours = fnHourDiff(ticket.Travel.Boarding, ticket.Travel.Arrival);

                        if (flights.length - 1 > 0) {
                            flightType = flights.length - 1 + ' stop(s)';
                            flightTypeColor = 'darkred';
                        }

                        jumbotron += '<div class="jumbotron">' +
                            '<div class="row">' +
                            '<div class="col-sm-7 text-center">' +
                            '<p id="ticketDescription" class="text-center" style="font-size: 24px;">' + ticket.Description + '</p>' +
                            '</div>' +
                            '</div>' +
                            '<div class="row">' +
                            '<div class="col-sm-2 text-right">' +
                            '<span id="boarding" style="font-size: 26px;">' + boarding + '</span>' +
                            '<br />' +
                            '<span id="city">' + ticket.Travel.Way.Airport.City.Description + '</span>' +
                            '</div>' +
                            '<div class="col-sm-3">' +
                            '<div class="text-center">' +
                            '<span id="hours" style="color: #888;">' + hours + '</span>' +
                            '<hr style="background-color: #999; height: 1px; border: 0; margin: 15px;" />' +
                            '<span id="flightType" class="text-center" style="color: ' + flightTypeColor + ';">' + flightType + '</span>' +
                            '</div>' +
                            '</div>' +
                            '<div class="col-sm-2">' +
                            '<span id="arrival" style="font-size: 26px;">' + arrival + '</span>' +
                            '<br />' +
                            '<span id="cityDestiny">' + ticket.Travel.Way.AirportDestiny.City.Description + '</span>' +
                            '</div>' +
                            '<div class="col-sm-2 text-right">' +
                            '<span style="font-size: 12px; color: #999;">' +
                            'Price include taxes, service bills, checkin online' +
                            '</span>' +
                            '</div>' +
                            '<div class="col-sm-2 text-center">' +
                            '<span id="price" style="font-size: 32px;">€' + ticket.Price + '</span>' +
                            '</div>' +
                            '<div class="col-sm-1">' +
                            '<a class="btn btn-lg btn-primary" role="button">Select</a>' +
                            '</div>' +
                            '</div>' +
                            '</div>'
                    });

                    $("#jumbotron").html('');
                    $("#jumbotron").append(jumbotron);
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