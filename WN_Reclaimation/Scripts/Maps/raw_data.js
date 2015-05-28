var rawDataList;
var rawMarkers = [];
var checked = false;
var isFirst = true;
function getRawData() {
    if (checked) {
        // Raw Data box is checked, uncheck it and hide markers
        if (rawMarkers != null) {
            for (var i = 0; i < rawMarkers.length; i++) {
                rawMarkers[i].setMap(null);
            }
        }
        checked = false;
    } else {
        checked = true;
        $.getJSON("/FieldData/All", onRawDataSuccess);
        //$.ajax({
        //    url: '/FieldData/All',
        //    success: onRawDataSuccess

        //});
        //console.log("Send");
    }



}

function onRawDataSuccess(response) {
    console.log(response);
    // Clear 
    rawMarkers = [];
    rawDataList = response;

    for (var i = 0; i < response.length ; i++) {
        var markerOptions = {
            position: new google.maps.LatLng(response[i].Latitude, response[i].Longitude),
            icon: '/Content/Images/marker_purple.png'
        };

        var marker = new google.maps.Marker(markerOptions);

        // Set onclick listener
        showDetails(marker,response[i]);


        rawMarkers.push(marker);

        marker.setMap(map);
    }

    if(isFirst){
        //AutoCenter(map, rawMarkers);
        isFirst = false;
    }
}

function showDetails(marker, data) {
    google.maps.event.addListener(marker, 'click', function (e) {
        displayInWindow2(data);
    });
    
}

function displayInWindow2(response) {
    if (response != null) {
        // Set current detailed data
        currentDetailData = response;
        // Empty list first
        $("#coordList").empty();
        $("#imageList").empty();
        $("#downloadDiv").empty();
        $("#detailsDiv").empty();
        $("#detailsDiv").append('<input type="hidden" name="ID" id="ID" /><input type="submit" value="Show on new tab" class="btn btn-primary"/>');
        // Set ID in form
        $('#ID').val(response.ID);

        if (isSA) {
            $('#SAControl').show();
            $('#edit_data').attr('href', "fielddata/edit/" + response.ID);
            $('#delete_data').attr('href', "fielddata/delete/" + response.ID);

        }

        // Got data, Display it
        var images = new Object();
        var i = 1;
        for (var key in response) {
            var rst = i % 2;

            if (response.hasOwnProperty(key)) {
                //alert(key + " -> " + response[key]);
                var value = response[key];
                if (value != null) {
                    if (key.toLowerCase() === "inspection date") {
                        try{
                            var td = new Date();

                            var millsec = value.substring(value.indexOf("(") + 1, value.indexOf(")"));
                            td.setTime(millsec);

                            value = td.getFullYear() + "-" + (td.getMonth()+1) + "-" + (td.getDate()+1);
                        }catch(error){}
                    }

                    if (key.toLowerCase().indexOf("photo") == -1) {
                        if(key.indexOf("UserName") == -1){
                            if (rst == 1) {
                                $("#coordList").append("<tr class='mTableStyle'><td>" + key + " </td><td>" + value + "</td></tr>");
                            } else {
                                $("#coordList").append("<tr><td>" + key + " </td><td>" + value + "</td></tr>");
                            }
                            i++;
                        }
                    } else {
                        images[key] = value;
                    }

                }
            }

        }

        // Display images
        displayImages2(images);

    } else {
        alert("No Data");
    }
}

function displayImages2(theImages) {
    for (var key in theImages) {
        if (theImages.hasOwnProperty(key)) {
            if (theImages[key].length > 0) {
                $("#imageList").append('<span>' + key + '</span><img src="' + theImages[key] + '" class="img-responsive"><br />');
            }
        }

    }
}