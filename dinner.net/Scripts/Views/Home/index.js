$(document).ready(function () {
    loadHistory();
});

$(function () {
    $(".datepicker").datepicker();
});

function loadHistory() {
    $.get("/api/RecentMeals", function (data) {
        var ul = document.getElementById("list-recent");
        ul.innerHTML = "";
        var li;
        var count = data.length;
        var lastAte;
        for (var i = 0; i < count; i++) {
            li = document.createElement("li");
            if (data[i].LastAte) {
                lastAte = $.datepicker.formatDate('mm/dd/yy', new Date(data[i].LastAte));
            }
            else {
                lastAte = "(date unknown)";
            }
            li.innerHTML = data[i].Name + " - " + lastAte;
            ul.appendChild(li);
        }
    });
}

function addHistory() {
    var mealID = document.getElementById("ddl-meal-history").value;
    var mealDate = document.getElementById("txt-meal-date").value;
    if (mealDate.length > 0) {
        $.post("/Meal/AddHistory/" + mealID,
            { dateAte: mealDate },
            function (data) {
                loadHistory();
            });
    }
}