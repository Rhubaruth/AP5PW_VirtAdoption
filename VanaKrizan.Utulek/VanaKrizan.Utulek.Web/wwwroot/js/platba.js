$(function () {

    var month = 0;
    var html = document.getElementsByTagName('html')[0];
    var number = "";

    var selected_card = -1;

    $(document).click(function (e) {
        if (!$(e.target).is(".expire") || !$(e.target).closest(".expire").length) {
            $(".date_value").css("color", "var(--text-color)");
        }
    });

    //Date expire input
    $(".expire").keypress(function (event) {
        if (event.charCode >= 48 && event.charCode <= 57) {
            if ($(this).val().length === 1) {
                $(this).val($(this).val() + event.key + " / ");
            } else if ($(this).val().length === 0) {
                if (event.key == 1 || event.key == 0) {
                    month = event.key;
                    return event.charCode;
                } else {
                    $(this).val(0 + event.key + " / ");
                }
            } else if ($(this).val().length > 2 && $(this).val().length < 9) {
                return event.charCode;
            }
        }
        return false;
    }).keyup(function (event) {
        $(".date_value").html($(this).val());
        if (event.keyCode == 8 && $(".expire").val().length == 4) {
            $(this).val(month);
        }

        if ($(this).val().length === 0) {
            $(".date_value").text("MM / YYYY");
        }
    }).keydown(function () {
        $(".date_value").html($(this).val());
    }).focus(function () {
        $(".date_value").css("color", "white");
    });
});