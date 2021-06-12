function toggle_validator(e) {
    if ($("#remember_Me").val() === "off") {
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
    /* Show & Hide password on sign in form */
    $("#show-password").click(function (e) { ShowHidePassword(e); });

    /* Sticky and Fixed header */
    AdjustHeaderToTop();
    $(window).scroll(function () { AdjustHeaderToTop(); });

    /* To Top button */
    $("#to-top").click(function (e) {
        e.preventDefault();
        $('html, body').animate({ scrollTop: 0 }, '300');
    });

    /* Set year on the footer */
    $("#year").text(new Date().getFullYear());

    /* Counter of error pages */
    $(".counter").each(function () {
        var $this = $(this);
        jQuery({ Counter: 0 }).animate(
            { Counter: parseInt($this.attr("data-counter")) },
            {
                duration: 1000,
                easing: 'swing',
                step: function () { $this.text(Math.floor(this.Counter) + 1); }
            });
    });

    $(function () {
        // ------------------------------------------------------- //
        // Multi Level dropdowns
        // ------------------------------------------------------ //
        $("ul.dropdown-menu [data-toggle='dropdown']").on("click", function (event) {
            event.preventDefault();
            event.stopPropagation();

            $(this).siblings().toggleClass("show");


            if (!$(this).next().hasClass('show')) {
                $(this).parents('.dropdown-menu').first().find('.show').removeClass("show");
            }
            $(this).parents('li.nav-item.dropdown.show').on('hidden.bs.dropdown', function (e) {
                $('.dropdown-submenu .show').removeClass("show");
            });

        });
    });

   // * Multiselect configuration
    $(".ms").each(function () {
        var $this = $(this);
        $this.multiselect({
            // Button configurations
            buttonWidth: '100%',
            nonSelectedText: 'Selecciona la(s) opción(es)',
            nSelectedText: " - " + $this.attr("data-field") + " seleccionados",
            numberDisplayed: 3,
            allSelectedText: "Todas seleccionadas",
            delimiterText: ' , ',
            // Filter configurations
            enableFiltering: true,
            filterPlaceholder: 'Busca ...',
            enableCaseInsensitiveFiltering: true,
            // Select all configurations
            includeSelectAllOption: true,
            selectAllNumber: false,
            selectAllText: 'TODO',
            // Adjust width
            widthSynchronizationMode: 'ifPopupIsSmaller',
            // Checkbox name
            checkboxName: function (option) {
                return $this.attr("data-name");
            },
            // Template
            templates: {
                filter: '<div class="multiselect-filter d-flex align-items-center"><i class="fa fa-search text-muted"></i><input type="search" class="multiselect-search form-control" /></div>',
            }
        })
    });

});

