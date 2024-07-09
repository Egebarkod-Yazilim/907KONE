$(document).ready(function () {
    var datatable = $('#userlisttable').DataTable({
        "ajax": {
            "url": "/User/GetUserList",
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": null, "orderable": false },
            { "data": 'id' },
            { "data": 'firstName' },
            { "data": 'lastName' },
            { "data": 'identifierNumber' },
            { "data": 'kgkRegistrationNumber' },
            { "data": 'serialNumber' },
            { "data": 'email' },
            { "data": 'roles' },
            { "data": 'birthDate' },
            { "data": 'phoneNumber' },
        ],
        "columnDefs": [
            {
                "targets": [0],
                "render": function (data, type, row, meta) {
                    return '<div class="form-check form-check-md d-flex align-items-center"><input class="form-check-input" type = "checkbox" value ="' + data.Id + '" id="checkebox-md"></div >';
                }
            },
        ],
        "orderCellsTop": true,
        "fixedHeader": true,
        "pageLength": 25,
        "pagingType": "full_numbers", // Tüm sayfaları göster
        "lengthMenu": [[25, 50, 100, -1], [25, 50, 100, "Tümü"]],
        "language": {
            "url": "https://cdn.datatables.net/plug-ins/1.12.0/i18n/tr.json"
        }
    });

    $('#userlisttable thead th').each(function (i) {
        var title = $(this).text();
        var classList = $(this).attr('class'); // Öğenin sınıf listesini al

        if (classList && classList.indexOf('nonsearchable') !== -1) {
            $(this).text(title);
        } else {
            $(this).html('<input type="text" class="form-control rounded-pill" placeholder="' + title + '" />');

            $('input', this).on('keyup change', function () {
                if (datatable.column(i).search() !== this.value) {
                    datatable
                        .column(i)
                        .search(this.value)
                        .draw();
                }
            });
        }
    });
});i 