$(document).ready(function () {
    GetProduct();

});
var saveproduct = function () {
    var massage = "";
    $formData = new FormData();
    var img = document.getElementById('file1');
    if (img.files.length > 0) {
        for (var i = 0; i < img.files.length; i++) {
            $formData.append('file-' + i, img.files[i]);
        }
    }
    var title = $("#txtTitle").val();
    var description = $("#txtDescription").val();
    var price = $("#txtPrice").val();
    $formData.append('Title', title);
    $formData.append('Description', description);
    $formData.append('Price', price);
    $.ajax({
        url: "/Product/SaveProduct",
        method: "post",
        data: $formData,
        dataType: 'json',
        /* contentType: "application/json;charset=utf-8",*/
        contentType: false,
        processData: false,
        success: function (response) {
            alert("Successfull");
            GetProduct();
            $("#txtTitle").val('');
            $("#txtDescription").val('');
            $("#file1").val('');
            $("#txtPrice").val('');
        }
    });

}

var GetProduct = function () {

    $.ajax({
        url: "/Product/GetProduct",
        method: "Post",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        async: false,
        success: function (response) {
            var html = "";
            $("#tblProduct tbody").empty();
            $.each(response.model, function (index, elementValue) {
                html += "<tr><td>"+ elementValue.Id
                    + "</td><td>" + elementValue.Title
                    + "</td><td>" + "<img src='../Content/img/" + elementValue.Image + " 'width='200' height='200'/>"
                    + "</td><td>" + elementValue.Description
                    + "</td><td>" + elementValue.Price + "</td></tr>"


                //html += "<div class='container'>";
                //html += "<div class='container mt-4'>";
                //html += "<div class='row'>";
                //html += "<div class='flex-container'>";
                //html += "<div class='col-md-3 /*col-sm-6*/'>";
                //html += "<div class='card card-block'>";
                //html += "<h4 class='card-title text-right'>" + elementValue.Title + "<i class='material-icons'></i></h4>";
                //html += "<img src='../Content/img/" + elementValue.Image + "'/>";
                //html += "<h5 class='card-title mt-3 mb-3'>" + elementValue.Description + "</h5>";
                //html += "<p class='card-text'></p>";
                //html += "</div>";
                //html += "</div>";
                //html += "</div>";
                //html += "</div>";
                //html += "</div>";


                //html += "<div class='col-lg-4 col-md-6' data-aos='fade-up' data-aos-delay='100'>";
                //html += "<div class='card'>";
                //html += "<div class='card-img'>";
                //html += "<h3><a class='card-title text-right'>" + elementValue.Title + "<i class='material-icons'></i> ></a></h3>";
                //html += "<img src='../Content/img/" + elementValue.Image + "'style='width:'50px; height:50px;'' alt='' class='img-fluid'>";
                //html += "</div>";
                //html += "<h5><a class='card-title mt-3 mb-3'>" + elementValue.Description + " ></a></h5>";
                //html += "<p></p>";
                //html += "</div>";
                //html += "</div>";
            })
            $("#tblProduct tbody").append(html);
            $("#txtTitle").val('');
            $("#txtDescription").val('');
            $("#file1").val('');
            $("#txtPrice").val('');
        }


    });
};