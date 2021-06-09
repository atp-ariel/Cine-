function toggle_validator(e) {
    if ($("#remember_Me").val() == "off") {
        $("#remember_Me").val(false);
    }
    else {
        $("#remeber_Me").val(true);
    }
}
$(document).ready(function () {
    $("#show-password").click(function (e) {
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
    });
});