$(document).ready(function () {


    function tableCreate(resultString) {
        let resultDiv = document.getElementById('result');

        isTbl = document.getElementById("tablec");


        if(isTbl)
        {

            let tr = document.createElement('tr');

            let td = document.createElement('td');

            td.appendChild(document.createTextNode(resultString));


            tr.appendChild(td);
            $('#tablec tr:last').after(tr);
        }
        if (!isTbl) {

            var tbl = document.createElement('table');


            tbl.id = "tablec"
            tbl.classList.add("table");
            tbl.classList.add("table-dark");
            tbl.classList.add("table-hover");
            tbl.classList.add("items-table");
            tbl.classList.add("mt-5");
            tbl.classList.add("mx-1");
            let thead = document.createElement('thead');
            let trh = document.createElement('tr');

            let th = document.createElement('th');
            th.appendChild(document.createTextNode('text'));


            trh.appendChild(th);
            thead.appendChild((trh));
            tbl.appendChild(thead);


            var tbdy = document.createElement('tbody');


            let tr = document.createElement('tr');

            let td = document.createElement('td');

            td.appendChild(document.createTextNode(resultString))


            tr.appendChild(td);
            tbdy.appendChild(tr);


            tbl.appendChild(tbdy);
            resultDiv.appendChild(tbl)
        }
    }


    function getData(list) {
        list = list.split(";")
        rez = "";
        for (selector of list) {
            console.log(selector)
            $(selector).each(function () {

                rez += $(this).text();
            })
        }

        tableCreate(rez)


    }


    $("#okc").click(() => {
        try {
            getData(document.getElementById("inputc").value)
        } catch (e) {
            alert(e)
        }
    });

});
