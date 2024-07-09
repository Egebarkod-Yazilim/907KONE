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
            { "data": 'firms' },
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
            {
                "targets": [8],
                "render": function (data, type, row, meta) {
                    var badges = '';
                    for (let i = 0; i < data.length; i++) {
                        if (i == 0) {
                            badges += '<span class="badge bg-warning-transparent">' + data[i].name + '</span>'
                        }
                        if (i == 1) {
                            badges += '<span class="badge bg-primary-transparent">' + data[i].name + '</span>'
                        }
                        if (i == 2) {
                            var leftCount = (data.length - 3);
                            badges += '<span class="badge bg-danger-transparent">' + data[i].name + '</span>'
                            if (leftCount != 0) {
                                badges += '<span class="badge bg-success-transparent">' + '+' + leftCount + '</span>'
                            }
                        }
                    }

                    return badges;
                }
            },
            {
                "targets": [9],
                "render": function (data, type, row, meta) {
                    var badges = '';
                    for (let i = 0; i < data.length; i++) {
                        if (i == 0) {
                            badges += '<span class="badge bg-warning-transparent">' + data[i].name + '</span>'
                        }
                        if (i == 1) {
                            badges += '<span class="badge bg-primary-transparent">' + data[i].name + '</span>'
                        }
                        if (i == 2) {
                            var leftCount = (data.length - 3);
                            badges += '<span class="badge bg-danger-transparent">' + data[i].name + '</span>'
                            if (leftCount != 0) {
                                badges += '<span class="badge bg-success-transparent">' + '+' + leftCount + '</span>'
                            }
                        }
                    }

                    return badges;
                }
            },
            {
                "targets": [12],
                "render": function (data, type, row, meta) {
                    return '<div class="hstack gap-2">' +
                        '<a aria-label="anchor" href="/User/AddOrUpdateUser/' + row.id + '" class="btn btn-icon btn-wave waves-effect waves-light btn-sm btn-konfrut-light-4"><i class="ri-edit-line" data-bs-toggle="tooltip" data-bs-placement="top" title="Kullanıcı Güncelle"></i></a>' +
                        '<a aria-label="anchor" href="/User/UserDetail/' + row.id + '" class="btn btn-icon btn-wave waves-effect waves-light btn-sm btn-konfrut-light-1"><i class="bx bx-id-card" data-bs-toggle="tooltip" data-bs-placement="top" title="Kullanıcı Detayı"></i></a>' +
                        '</div>';
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

    $('#userlisttable thead th').each(function () {
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
});