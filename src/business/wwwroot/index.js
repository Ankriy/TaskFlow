function showContent(page) {
    
    setTab();
    setContent(page);
}
function setTab() {
    $('.tab').on('click', function () {
        $('.tab').removeClass('active');
        $(this).addClass('active');
    });
}
function setContent(page) {
    if (page === '') {
        page = 'dashboard';
    }
    $.ajax({
        url: "/Home/" + page,
        type: "GET",
        data: {}
    })
        .done(function (partialViewResult) {
            $("#content").html(partialViewResult);
        });
}

