//Управление вкладками
document.addEventListener("DOMContentLoaded", function () {
    var currentUrl = window.location.href;
    var navigationLinks = document.querySelectorAll('.sidebar a.tab');

    navigationLinks.forEach(function (link) {
        if (link.href === currentUrl) {
            link.classList.add('active');
        }
    });
});



