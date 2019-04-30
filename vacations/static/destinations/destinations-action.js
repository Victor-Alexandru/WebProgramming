$(document).ready(function () {
    let start = 0;
    let end = 4;

    function getData(start, end) {
        $.ajax({
            type: "POST",
            url: "static/fetchDestinations.php",
            data: {start: start, end: end},
            cache: false,
            success: function (data) {
                $("#result").html(data);
            },


        });
    }
    getData(start, end);


    $("#previous-button").click(() => {

        if (start !== 0) {
            start = start - 4;
            end = end - 4;
            getData(start, end);
        }

    });

    $("#next-button").click(() => {
        start = start + 4;
        end = end + 4;
        getData(start, end);


    });

});