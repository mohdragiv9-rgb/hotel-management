function SaveGuest() {

    var guest = {
        GuestId: $("#GuestId").val(),
        GuestName: $("#GuestName").val(),
        MobileNo: $("#MobileNo").val(),
        Email: $("#Email").val(),
        IdProofType: $("#IdProofType").val(),
        IdProofNumber: $("#IdProofNumber").val(),
        AadhaarNo: $("#AadhaarNo").val(),
        Gender: $("#Gender").val(),
        Address: $("#Address").val(),
        City: $("#City").val(),
        State: $("#State").val(),
        Country: $("#Country").val(),
        Pincode: $("#Pincode").val()
    };

    $.ajax({
        url: "/Guest/Save",
        type: "POST",
        data: guest,

        success: function (response) {

            if (response.success) {

                if ($("#GuestId").val() == "" || $("#GuestId").val() == "0") {
                    alert("Guest Saved Successfully");
                }
                else {
                    alert("Guest Updated Successfully");
                }

                location.reload();
            }
            else {
                alert(response.message);
            }

        },

        error: function (xhr) {

            alert(xhr.responseText);

        }

    });

}


//======================== EDIT ========================//

function Edit(id) {

    $.ajax({

        url: "/Guest/GetById",
        type: "GET",
        data: { id: id },

        success: function (data) {

            $("#GuestId").val(data.guestId);
            $("#GuestName").val(data.guestName);
            $("#MobileNo").val(data.mobileNo);
            $("#Email").val(data.email);
            $("#IdProofType").val(data.idProofType);
            $("#IdProofNumber").val(data.idProofNumber);
            $("#AadhaarNo").val(data.aadhaarNo);
            $("#Gender").val(data.gender);
            $("#Address").val(data.address);
            $("#City").val(data.city);
            $("#State").val(data.state);
            $("#Country").val(data.country);
            $("#Pincode").val(data.pincode);

            $("#btnSave")
                .removeClass("btn-success")
                .addClass("btn-primary")
                .html('<i class="fa fa-edit"></i> Update');

        },

        error: function (xhr) {

            console.log(xhr);
            alert("Edit Error : " + xhr.status);

        }

    });

}


//======================== DELETE ========================//

function Delete(id) {

    if (confirm("Are you sure you want to delete?")) {

        $.ajax({

            url: "/Guest/Delete",
            type: "POST",
            data: { id: id },

            success: function (response) {

                if (response.success) {
                    alert(response.message);
                    location.reload();
                }
                else {
                    alert(response.message);
                }

            },

            error: function (xhr) {

                alert(xhr.responseText);

            }

        });

    }

}


//======================== CLEAR ========================//

function ClearData() {

    $("#GuestId").val("");
    $("#GuestName").val("");
    $("#MobileNo").val("");
    $("#Email").val("");
    $("#IdProofType").val("");
    $("#IdProofNumber").val("");
    $("#AadhaarNo").val("");
    $("#Gender").val("");
    $("#Address").val("");
    $("#City").val("");
    $("#State").val("");
    $("#Country").val("India");
    $("#Pincode").val("");

    $("#btnSave")
        .removeClass("btn-primary")
        .addClass("btn-success")
        .html('<i class="fa fa-save"></i> Save');

}