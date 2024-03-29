﻿var GigsController = function (attendanceService) {
    var button;

    var init = function (container) {
        $(container).on("click", ".js-toggle-attendance", toggleAttendance);
    };

    var toggleAttendance = function(e) {
        button = $(e.target);

        var gigId = button.attr("data-gig-id");

        if (button.hasClass("btn-default"))
            attendanceService.createAttendance(gigId, done, fail);
        else
            attendanceService.deleteAttendance(gigId, done, fail);
    };

    var fail = function () {
        alert("Algo salio mal!");
    };

    var done = function () {
        var text = (button.text() === "Voy") ? "¿ Ir ?" : "Voy";
        button.toggleClass("btn-info").toggleClass("btn-default").text(text);
    };

    return {
        init: init
    }
}(AttendanceService);