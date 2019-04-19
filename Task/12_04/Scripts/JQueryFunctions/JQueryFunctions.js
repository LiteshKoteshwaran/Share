$(document).ready(function() {
    var ddlComState = $("#ddlCommunicationState")
    var ddlComDistrict = $("#ddlCommunicationDistrict")
    var ddlComCity = $("#ddlCommunicationCity")
    
    var ddlPerState = $("#ddlPermanentState")
    var ddlPerDistrict = $("#ddlPermanentDistrict")
    var ddlPerCity = $("#ddlPermanentCity")

    var txtPerAdd1 = $("#PermanentAddress_Address1");
    var txtPerAdd2 = $("#PermanentAddress_Address2");
    var txtPerAdd3 = $("#PermanentAddress_Address3");
    var txtPerPinCode = $("#PermanentAddress_Pincode");

    var txtComAdd1 = $("#CommunicationAddress_Address1");
    var txtComAdd2 = $("#CommunicationAddress_Address2");
    var txtComAdd3 = $("#CommunicationAddress_Address3");
    var txtComPinCode = $("#CommunicationAddress_Pincode");

    ddlComState.change(function() {
        let dropdown = $(ddlComDistrict);
        var id = ddlComState.val();
        $.ajax({
            type: "GET",
            url: "ForCasCading",
            data: { ComStateId: id },
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
            data: { ComDistrictId: id },
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
            data: { PerStateId: id },
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
            data: { PerDistrictId: id },
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
    $("#per").on("click", function () {
        if (this.checked) {
            debugger
            $(txtPerAdd1).attr("readonly", "true").val($(txtComAdd1).val());
            $(txtPerAdd2).attr("readonly", "true").val($(txtComAdd2).val());
            $(txtPerAdd3).attr("readonly", "true").val($(txtComAdd3).val());

            $(ddlPerState).prop("disabled", true).val($("#ddlCommunicationState option:selected").val());
            $(ddlPerDistrict).append($(ddlComState).val());

            $(ddlPerCity).append($(ddlComState).val());

        }
        else {
            $(txtPerAdd1).removeAttr("readonly").val('');
            $(txtPerAdd2).removeAttr("readonly").val('');
            $(txtPerAdd3).removeAttr("readonly").val('');

            var state = $(ddlPerState);

            $(ddlPerState).removeAttr("readonly").val('');
        }
    });
});

function HideFieldsForPermanent() {
    $("#IsPermanent").hide();
}

