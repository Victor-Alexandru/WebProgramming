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
    console.log(start, end)
    getData(start, end);


    $("#previous-button").click(() => {

        if (start !== 0) {
            start = start - 4;
            end = end - 4;
            console.log(start, end)
            getData(start, end);
        }

    });

    $("#next-button").click(() => {
        if ($("tr").length >= 5) {
            start = start + 4;
            end = end + 4;
            console.log(start, end)
            getData(start, end);
        }

    });

});