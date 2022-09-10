$(document).ready(function () {
    GetContact();
});

var SaveContact = function () {
    var full_name = $("#txtFull_Name").val();
    var phone_number = $("#txtPhone_Number").val();
    var email = $("#txtEmail").val();
    var message = $("#txtMessage").val();
   


    var model = {
        Full_Name: full_name, Phone_Number: phone_number, Email: email, Message: message,
    };
    $.ajax({
        url: "/Contact/SaveContact",
        method: "post",
        data: JSON.stringify(model),
        contentType: "application/json;charset=utf-8",
        datatype: "json",
        success: function (response) {
            alert("Massage Succesfully");

        }
    });
}

var GetContact = function () {
    debugger;
    $.ajax({
        url: "/Contact/GetContact",
        method: "post",

        contentType: "application/json;charset=utf-8",
        dataType: "json",
        async: false,
        success: function (response) { 
            var html = "",
            $("#Contact tbody").empty();
            $.each(response.model, function (index, elementValue) {
                html += "<tr><td>" + elementValue.Id + "</td><td>" + elementValue.Full_Name + "</td> <td>"
                    + elementValue.Phone_Number
                    + "</td><td>" + elementValue.Email
                    + "</td><td>" + elementValue.Message + "</td></tr>";

            });
            $("#Contact tbody").append(html);
        }
    });
};