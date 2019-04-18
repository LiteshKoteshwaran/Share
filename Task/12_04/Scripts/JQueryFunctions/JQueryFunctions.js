$(document).ready(function() {
    var ddlComState = $("#ddlCommunicationState")
    var ddlComDistrict = $("#ddlCommunicationDistrict")
    var ddlComCity = $("#ddlCommunicationCity")
    
    var ddlPerState = $("#ddlPermanentState")
    var ddlPerDistrict = $("#ddlPermanentDistrict")
    var ddlPerCity = $("#ddlPermanentCity")

    ddlComState.change(function() {
        let dropdown = $(ddlComDistrict);
        var id = ddlComState.val();
        $.ajax({
            type: "GET",
            url: "ForCasCading",
            data: { StateId: id },
            success: function(data) {
                //$(dropdownid).removeAttr("disabled");
                if (data != null && data.length > 0) {
                    dropdown.empty();
                    dropdown.append($("<option/>", { value: -1, text: "Select District" }));
                    dropdown.prop("disabled", false);
                    $.each(data,
                        function(key, items) {
                            dropdown.append($("<option></option>").val(items.DistrictID).html(items.Districts));
                        });
                } else {
                    alert("Failed to Load States");
                }
            },
        });
    })

    ddlComDistrict.change(function() {
        let dropdown = $(ddlComCity);
        var id = ddlComDistrict.val();
        $.ajax({
            type: "GET",
            url: "ForCasCading",
            data: { DistrictId: id },
            success: function(data) {
                //$(dropdownid).removeAttr("disabled");
                if (data != null && data.length > 0) {
                    dropdown.empty();
                    dropdown.append($("<option/>", { value: -1, text: "Select City" }));
                    dropdown.prop("disabled", false);
                    $.each(data,
                        function(key, items) {
                            dropdown.append($("<option></option>").val(items.CityID).html(items.Cities));
                        });
                } else {
                    alert("Failed to Load States");
                }
            },
        });
    });


    ddlPerState.change(function () {
        let dropdown = $(ddlPerDistrict);
        var id = ddlPerState.val();
        $.ajax({
            type: "GET",
            url: "ForCasCading",
            data: { StateId: id },
            success: function (data) {
                //$(dropdownid).removeAttr("disabled");
                if (data != null && data.length > 0) {
                    dropdown.empty();
                    dropdown.append($("<option/>", { value: -1, text: "Select District" }));
                    dropdown.prop("disabled", false);
                    $.each(data,
                        function (key, items) {
                            dropdown.append($("<option></option>").val(items.DistrictID).html(items.Districts));
                        });
                } else {
                    alert("Failed to Load States");
                }
            },
        });
    })

    ddlPerDistrict.change(function () {
        let dropdown = $(ddlPerCity);
        var id = ddlPerDistrict.val();
        $.ajax({
            type: "GET",
            url: "ForCasCading",
            data: { DistrictId: id },
            success: function (data) {
                //$(dropdownid).removeAttr("disabled");
                if (data != null && data.length > 0) {
                    dropdown.empty();
                    dropdown.append($("<option/>", { value: -1, text: "Select City" }));
                    dropdown.prop("disabled", false);
                    $.each(data,
                        function (key, items) {
                            dropdown.append($("<option></option>").val(items.CityID).html(items.Cities));
                        });
                } else {
                    alert("Failed to Load States");
                }
            },
        });
    });
});

function HideFieldsForPermanent() {
    $("#IsPermanent").hide();
}
