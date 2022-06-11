var dataTable;

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#tblOrders').DataTable({

        "ajax": {
            "url": "/Orders/Index",
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "id", "width": "10%" },
            { "data": "OrderUserId", "width": "10%" },
            { "data": "OrderProductId", "width": "10%" },
            { "data": "UnitValue", "width": "10%" },
            { "data": "Amount", "width": "10%" },
            { "data": "SubTotal", "width": "10%" },
            { "data": "IVA", "width": "10%" },
            { "data": "Total", "width": "10%" },            
            {
                "data": "id",
                "render": function (data) {
                    return `<div class="text-center">
                            <a href="/Orders/Update/${data}" class="btn btn-success text-white" style="cursor-pointer;">Editar</a>
                            &nbsp;
                             <a onclick=Delete("/Orders/Delete/${data}") class="btn btn-danger text-white" style="cursor-pointer;">Borrar</a>
                            </div>`;
                }, "width": "20%"
            }
        ]
    });
}

function Delete(url) {
    swal({
        title: "Esta seguro de querer borrar el registro?",
        text: "Esta acción no puede ser revertida!",
        icon: "warning",
        buttons: true,
        dangerMode: true
    }).then((willDelete) => {
        if (willDelete) {
            $.ajax({
                type: 'DELETE',
                url: url,
                success: function (data) {
                    if (data.success) {
                        toastr.success(data.message);
                        dataTable.ajax.reload();
                    }
                    else {
                        toastr.error(data.message);
                    }
                }
            });
        }
    });
}