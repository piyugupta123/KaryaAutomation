
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
            $("#tblGallery").empty();
            $.each(response.model, function (index, elementValue) {          
                html += "<div class='col-lg-3 col-md-6' data-aos='fade-up' data-aos-delay='100'>";
                html += "<div class='card'>";
                html += "<div class='card-img'>";
                html += "<img src='../Content/img/" + elementValue.Photo + " 'width='500px' height='70px'' /*class='img-fluid'*/>";
                html += "<h3><a class='card-title text-right'>" + elementValue.Title + "<i class='material-icons'></i> </a></h3>";   
                html += "</div>";
                html += "<p></p>";
                html += "</div>";
                html += "</div>";
            })
            $("#tblGallery").append(html);
        }


    });
};
