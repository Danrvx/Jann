$(document).ready(function () {

    function popularTable(tableId, clientes) {
        var tableContainer = document.getElementById('divTabla');
        tableContainer.innerHTML = '';

        var table = document.createElement('table');
        table.classList.add('table');
        table.classList.add('table-dark');

        var thead = document.createElement('thead');
        var tbody = document.createElement('tbody');

        for (var i = 0; i < clientes.length; i++) {
            var clientesKeys = Object.keys(clientes[i]);

            if (i === 0) {
                var trh = document.createElement('tr');

                for (var j = 0; j < clientesKeys.length; j++) {
                    var th = document.createElement('th');
                    th.appendChild(document.createTextNode(clientesKeys[j]))
                    trh.appendChild(th);
                }

                thead.appendChild(trh);
                table.appendChild(thead);
            }


            var tr = document.createElement('tr');

            for (var j = 0; j < clientesKeys.length; j++) {
                var td = document.createElement('td');
                var clientePropiedad = clientes[i][clientesKeys[j]];
                td.appendChild(document.createTextNode(clientePropiedad));
                tr.appendChild(td);
            }

            tbody.appendChild(tr);
        }

        table.appendChild(tbody);

        document.getElementById(tableId).appendChild(table);
    }

    $("#BuscarCliente").on("submit", function (e) {
        e.preventDefault();

        const model = $(this).serializeArray().reduce((prev, curr) => {
            prev[curr.name] = curr.value;
            return prev;
        }, {});

        $.ajax({
            method: "POST",
            url: "Home/Clientes",
            data: JSON.stringify(model),
            contentType: "application/json; charset=utf-8",
            dataType: "json"
        }).done(function (clientes) {
            popularTable('divTabla', clientes)
            console.log(clientes);
        });

    })
});



