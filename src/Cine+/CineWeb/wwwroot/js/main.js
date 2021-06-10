function toggle_validator(e) {
    if ($("#remember_Me").val() == "off") {
        $("#remember_Me").val(false);
    }
    else {
        $("#remeber_Me").val(true);
    }
}



function ShowHidePassword(e) {
    e.preventDefault();
    var password_input = $("#password-input");
    if (password_input.attr("type") === "password") {
        password_input.attr("type", "text");
        $("#show-password > i").removeClass("fa-eye");
        $("#show-password > i").addClass("fa-eye-slash");
    }
    else {
        password_input.attr("type", "password");
        $("#show-password > i").removeClass("fa-eye-slash");
        $("#show-password > i").addClass("fa-eye");
    }
}

function AdjustHeaderToTop() {
    var nav = $("#main-nav");
    var toTop = $("#to-top");
    if ($(window).scrollTop() > parseInt(nav.attr("data-scroll"))) {
        // Header fixed
        if (!nav.hasClass("fixed-top"))
            nav.addClass("fixed-top");
            
        // Button to top
        toTop.addClass("show");
    }
    else {
        nav.removeClass("fixed-top");
        toTop.removeClass("show");
    }
}

$(document).ready(function () {
    $("#show-password").click(function (e) { ShowHidePassword(e); });

    AdjustHeaderToTop();
    $(window).scroll(function () { AdjustHeaderToTop(); });
    $("#to-top").click(function (e) {
        e.preventDefault();
        $('html, body').animate({ scrollTop: 0 }, '300');
    });
    $("#year").text(new Date().getFullYear());
});