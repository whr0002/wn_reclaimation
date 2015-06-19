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

function onRawDataSuccess(response, type) {
    console.log(type);
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
        showDetails(marker,response[i], type);


        rawMarkers.push(marker);

        marker.setMap(map);
    }

    if(isFirst){
        //AutoCenter(map, rawMarkers);
        isFirst = false;
    }
}

function showDetails(marker, data, type) {
    google.maps.event.addListener(marker, 'click', function (e) {
        displayInWindow2(data, type);
    });
    
}
var currentFormID = -1;
var hash = {};
function displayInWindow2(response, type) {
    currentFormID = -1;
    if (response != null) {
        console.log(response);
        // Set current detailed data      
        var reportID = response["Site Visit Report ID"];
        currentDetailData = response;
        getImages(reportID, type.formType);
        
        // Empty list first
        $("#coordList").empty();
        $("#imageList").empty();
        $("#downloadDiv").empty();
        $("#detailsDiv").empty();
        //$("#detailsDiv").append('<form action="'+type.action+'" method="get" target="_blank"><input type="hidden" name="ID" id="ID"/><input type="submit" value="Show on new tab" class="btn btn-primary"/></form>');
        $("#detailsDiv").append('<a href="'+ type.action + '?ID=' + reportID + '" target= "_blank" class="btn btn-primary">Show on new tab</a>');
        // Set ID in form
        //$('#ID').val(reportID);


        if (isSA != null && isSA === "Yes") {
            $("#downloadDiv").append('<a href="/sitevisitreports/edit/' + reportID + '" class="btn btn-primary">Edit</a>');
            
        }
        

        // Got data, Display it
        hash = {};
        extractJSON2(1, response);

        // Display images
        //displayImages2(images);

    } else {
        alert("No Data");
    }
}

// Recursively parse JSON objects

function extractJSON2(i, response) {
    for (var key in response) {

        if (hash[key] == 1) {
            continue;
        } else {
            hash[key] = 1;
        }


        var rst = i % 2;
        if (response.hasOwnProperty(key)) {

            var value = response[key];
            if (typeof value == 'object') {
                // disable this part temporaryly
                i = extractJSON(i, value);

            } else {

                if (value != null && value != "" && typeof value != 'object') {
                    var keyLower = key.toLowerCase();

                    if (keyLower.indexOf("date") > -1) {
                        value = convertMilliToDate(value);
                    }


                    console.log("Position: " + i + " | Key: " + key);
                    if (rst == 1) {
                        $("#coordList").append("<tr class='mTableStyle'><td>" + key + " </td><td>" + value + "</td></tr>");
                    } else {
                        $("#coordList").append("<tr><td>" + key + " </td><td>" + value + "</td></tr>");
                    }
                    i++;

                }
            }
        }
    }

    return i;
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

function clearRawMarker() {
    if (rawMarkers != null) {
        for(var i=0;i<rawMarkers.length;i++){
            rawMarkers[i].setMap(null);
        }

        rawMarkers = [];

    }
}

function convertMilliToDate(value) {
    var td = new Date();

    var millsec = value.substring(value.indexOf("(") + 1, value.indexOf(")"));
    td.setTime(millsec);

    value = td.getFullYear() + "-" + (td.getMonth() + 1) + "-" + (td.getDate() + 1);

    return value;
}

function getImages(formID, formType) {
    if (formID != -1 && formType != null) {
        $.getJSON("/rawdata/images",

            {
                formID : formID,
                formType : formType
            },

            function (response) {
                
                if (response != null) {

                    for (var i = 0; i < response.length; i++) {

                        var imgUrl = response[i].Path;
                        if (imgUrl != null && imgUrl.length > 0) {
                            $("#imageList")
                                .append('<img src="'
                                + imgUrl + '" class="img-responsive"><br />'
                                + '<span>' + ((response[i].Description != null) ? response[i].Description : "") + '</span>');
                        }

                    }   

                }


            });
    }
}