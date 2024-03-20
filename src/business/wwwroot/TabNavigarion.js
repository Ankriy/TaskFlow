//Managing tabs
document.addEventListener("DOMContentLoaded", function () {
    var currentUrl = window.location.href;
    var navigationLinks = document.querySelectorAll('.sidebar a.tab');

    navigationLinks.forEach(function (link) {
        if (link.href === currentUrl) {
            link.classList.add('active');
        }
    });
});

//customers

$(document).ready(function () {

    $('form').submit(function (event) {
        event.preventDefault();
        var data = {
            name1: $("input[name='name1']", this).val(),
            name2: $("input[name='name2']", this).val()
        };

        alert(JSON.stringify(data));
        console.log(JSON.stringify(data));

        $.ajax({
            type: 'POST',
            url: '/Home/client',
            dataType: 'json',
            data: data,
            success: function (response) {
                alert(response);
                console.log('Data received: ');
                console.log(response);
            },
            failure: function (response) {
                //...
            },
            error: function (response) {
                //...
            }
        });
    });
});




//function showContent(page) {

//    setTab();
//    //setContent(page);
//}
//function setTab() {
//    $('.tab').on('click', function () {
//        $('.tab').removeClass('active');
//        $(this).addClass('active');
//    });
//}

//function setContent(page) {
//    if (page === '') {
//        page = 'dashboard';
//    }
//    $.ajax({
//        url: "/Home/" + page,
//        type: "GET",
//        data: {}
//    })
//        .done(function (partialViewResult) {
//            $("#content").html(partialViewResult);
//        });
//}