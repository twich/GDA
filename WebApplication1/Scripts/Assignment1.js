

$("#updateweather").click(function () {
    alert("This assignment requires XSS permissions.");
    $.get("http://w1.weather.gov/xml/current_obs/KSLC.xml", null,
        function (weatherupdate) {
            $("#weather").text(function () {
                $(weatherupdate).find("weather").text();
            });
            $("#temperature").text(function () {
                $(weatherupdate).find("temperature_string").text();
            });
            $("#windchill").text(function () {
                $(weatherupdate).find("windchill_string").text();
            });
            $("#wind").text(function () {
                $(weatherupdate).find("wind_string").text();
            });
            $("#humidity").text(function () {
                $(weatherupdate).find("relative_humidity").text();
            });

        }, "xml");
})