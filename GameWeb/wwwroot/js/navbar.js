$(window).scroll(() => {
    if ($(this).scrollTop() > 50) {
        $("#navbar-top").removeClass("navbar-transparent");
    } else {
        $("#navbar-top").addClass("navbar-transparent");
    }
});