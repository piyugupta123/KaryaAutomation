$(document).ready(function () {
    GetGallery();

});
var savegallery = function () {
    var massage = "";
    $formData = new FormData();
    var img = document.getElementById('file1');
    if (img.files.length > 0) {
        for (var i = 0; i < img.files.length; i++) {
            $formData.append('file-' + i, img.files[i]);
        }
    }
    var title = $("#txtTitle").val();
    $formData.append('Title', title);
    $.ajax({
        url: "/Gallery/SaveGallery",
        method: "post",
        data: $formData,
        dataType: 'json',
        /* contentType: "application/json;charset=utf-8",*/
        contentType: false,
        processData: false,
        success: function (response) {
            alert("Successfull");
            GetGallery();
            $("#txtTitle").val('');
            $("#file1").val('');
           
        }
    });

}

var GetGallery = function () {

    $.ajax({
        url: "/Gallery/GetGallery",
        method: "Post",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        async: false,
        success: function (response) {
            var html = "";
            $("#tblGallery tbody").empty();
            $.each(response.model, function (index, elementValue) {
                html += "<tr><td>" + elementValue.Id
                    + "</td><td>" + elementValue.Title
                    + "</td><td>" + "<img src='../Content/img/" + elementValue.Photo + " 'width='150' height='150'/>" + "</td ><td><input type='submit'value='Delete' onClick='Deletegallary(" + elementValue.Id + ")'/></td><td>";

            });
            $("#tblGallery tbody").append(html);
            $("#txtTitle").val('');
            $("#file1").val('');
        }


    });
}

var Deletegallary = function (Id) {
    var model = { Id: Id };

    $.ajax({
        url: "/Gallery/Deletegallary",
        method: "post",
        data: JSON.stringify(model),
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        async: false,
        success: function (response) {
           
            alert("Gallery Deleted Successfully ....");
        }

    });
}