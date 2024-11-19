window.initMap = function (address) {
    var geocoder = new google.maps.Geocoder();
    var map = new google.maps.Map(document.getElementById("map"), {
        zoom: 15,
        center: { lat: -34.397, lng: 150.644 }
    });

    geocoder.geocode({ address: address }, function (results, status) {
        if (status === "OK") {
            map.setCenter(results[0].geometry.location);
            new google.maps.Marker({
                map: map,
                position: results[0].geometry.location
            });
        } else {
            console.error("Error al geocodificar: " + status);
        }
    });
};