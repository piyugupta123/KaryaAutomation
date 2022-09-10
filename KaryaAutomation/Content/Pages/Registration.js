
$(document).ready(function () {
    GetRegistration();
});


var SaveRegistration = function () {
    var name = $("#txtName").val();
    var address = $("#txtAddress").val();
    var gender = $("#txtGender").val();
    var city = $("#ddlCity").val();
    var mobile = $("#txtMobileNumber").val();
    var pincode = $("#txtPincode").val();
    var state = $("#txtState").val();
    var password = $("#txtPassword").val();
    var email = $("#txtEmail").val();
    var confirmpassword = $("#txtConfirmPassword").val();


    var model = {
        Name: name, Address: address, Gender: gender, City: city, Mobile_Number: mobile, Pincode: pincode, State: state, Email: email, Password: password, ConfirmPassword: confirmpassword
    };
   
    if (name == "") {
        alert("please enter your Name ");
        $("#txtName").focus();
        return false;
    }
    else if (address == "") {
        alert("please enter your address");
        $("#txtAddress").focus();
        return false;
    }
    else if (gender == "") {
        alert("please enter your Gender");
        $("#txtGender").focus();
        return false;
    }
    else if (city == "") {
        alert("please select your city");
        $("#txtCity").focus();
        return false;
    }
    else if (mobile == "") {
        alert("please select your MobileNumbr");
        $("#txtMobileNumber").focus();
        return false;
    }
    else if (pincode == "") {
        alert("please select your PinCode");
        $("#txtPincode").focus();
        return false;
    }
    
    else if (state == "") {
        alert("please enter your State");
        $("#txtState").focus();
        return false;
    }
    else if (password == "") {
        alert("please enter your Password");
        $("#txtPassword").focus();
        return false;
    }

    else if (email == "") {
        alert("please enter your email id");
        $("#txtEmail").focus();
        return false;
    }
    var filter = /^([a-zA-Z0-9_\.\-])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$/;

    if (!filter.test(email)) {
        alert('Please enter a valid email address');
    }

   
    else if (confirmpassword == "") {
        alert("please enter your Password");
        $("#txtConfirmPassword").focus();
        return false;
    }




    $.ajax({
        url: "/Registration/SaveRegistration",
        method: "post",
        data: JSON.stringify(model),
        contentType: "application/json;charset=utf-8",
        datatype: "json",
        success: function (response) {
            alert("Massage Succesfully");

        }
    });
}

var GetRegistration = function () {
    $.ajax({
        url: "/Registration/GetRegistration",
        method: "post",

        contentType: "application/json;charset=utf-8",
        dataType: "json",
        async: false,
        success: function (response) {
            var html = "";
            $("#tblVotting tbody").empty();
            $.each(response.model, function (index, elementvalue) {
                html += "<tr><td>" + elementvalue.Id + "</td><td>" + elementvalue.Name + "</td><td>" + elementvalue.Address + "</td><td>" + elementvalue.Gender + "</td><td>" + elementvalue.City + "</td><td>" + elementvalue.Mobile_Number +
                    "</td><td>" + elementvalue.Pincode + "</td><td>" + elementvalue.State + "</td><td>" + elementvalue.Email + "</td><td>" + elementvalue.Password + "</td><td>" + elementvalue.ConfirmPassword + "</td><td><input type = 'Button' value ='Delete' onclick ='deleteRegistration(" + elementvalue.Id + ")'/> </td></tr> ";
            });
            $("#tblRegistration tbody").append(html);
            deleteRegistration();
        }
    });
};

var deleteRegistration = function (id) {
    var model = { Id: id };

    $.ajax(
        {
            url: "/Registration/deleteRegistration",
            method: "post",
            data: JSON.stringify(model),
            contentType: "application/json;charset=utf-8",
            dataType: "json",
            async: false,
            success: function (response) {
                alert("Record Deleted Successfully ....");
            }
        });
}
