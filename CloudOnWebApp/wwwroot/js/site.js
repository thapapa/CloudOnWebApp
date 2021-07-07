// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.





function loadProducts() {

    var url = "https://pharmacyonenew.oncloud.gr/s1services/JS/updateItems/cloudOnTest";

    $.ajax({
        url: url,
        method: 'GET',
        contentType: 'application/json'
    }).done(response => {

        let divText = "<ul>"
        response.forEach(function (item) {
            divText = divText + "<li>" + item.firstName + "</li>"
        })
        divText = divText + "</ul>"

        $('#ProductsContent').html(divText)
    }).fail(failure => {

        $('#ProductsContent').html('Error in the communication')
    }).always(response => {
        console.log(response);
    });

}
