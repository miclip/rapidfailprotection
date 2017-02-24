
$(document).ready(function($) {

    $("#soEx").click(function () {
        $(".alert-success").addClass("hidden");
        var numberEx = $("#numberOfSOExceptions").val();
        $.ajax({
            url: "/Home/TriggerStackOverFlow",
            type: "post",
            data: { numberExceptions: numberEx || 1 },
            success: function (result) {
                $(".alert-success").toggleClass("hidden");
            }
        });
    });
    $("#avEx").click(function () {
        var numberEx = $("#numberOfAVExceptions").val();
        $(".alert-success").addClass("hidden");
        $.ajax({
            url: "/Home/TriggerAccessViolation",
            type: "post",
            data: { numberExceptions: numberEx || 1 },
            success: function (result) {
                $(".alert-success").toggleClass("hidden");
            }
        });
    });
});