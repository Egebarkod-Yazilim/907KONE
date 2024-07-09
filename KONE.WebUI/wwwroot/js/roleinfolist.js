﻿//$(document).ready(function () {
//    console.log("working");
//    var datatable = $('#roleintotable').DataTable({
//        "ajax": {
//            "url": "/Role/GetRoleList",
//            "type": "GET",
//            "datatype": "json"
//        },
//        "columns": [
//            { "data": null, "orderable": false },
//            { "data": 'id' },
//            { "data": 'name' },
//            { "data": 'createddate' },
//            { "data": 'createdbyname' },
//            { "data": 'isactive' },
//        ],
//        "columnDefs": [
//            {
//                "targets": [0],
//                "render": function (data, type, row, meta) {
//                    return '<div class="form-check form-check-md d-flex align-items-center"><input class="form-check-input" type = "checkbox" value ="' + data.Id + '" id="checkebox-md"></div >';
//                }
//            },
//        ],
//        "orderCellsTop": true,
//        "fixedHeader": true,
//        "pageLength": 25,
//        "pagingType": "full_numbers", // Tüm sayfaları göster
//        "lengthMenu": [[25, 50, 100, -1], [25, 50, 100, "Tümü"]],
//        "language": {
//            "url": "https://cdn.datatables.net/plug-ins/1.12.0/i18n/tr.json"
//        }
//    });

//    $('#roleintotable thead th').each(function () {
//        var title = $(this).text();
//        var classList = $(this).attr('class'); // Öğenin sınıf listesini al

//        if (classList && classList.indexOf('nonsearchable') !== -1) {
//            $(this).text(title);
//        } else {
//            $(this).html('<input type="text" class="form-control rounded-pill" placeholder="' + title + '" />');

//            $('input', this).on('keyup change', function () {
//                if (datatable.column(i).search() !== this.value) {
//                    datatable
//                        .column(i)
//                        .search(this.value)
//                        .draw();
//                }
//            });
//        }
//    });
//});

$(document).ready(function () {
    var datatable = $('#roleintotable').DataTable({
        "ajax": {
            "url": "/Role/GetRoleList",
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": null, "orderable": false },
            { "data": 'id' },
            { "data": 'name' },
            { "data": 'isactive' },
        ],
        "columnDefs": [
            {
                "targets": [0],
                "render": function (data, type, row, meta) {
                    return '<div class="form-check form-check-md d-flex align-items-center"><input class="form-check-input" type = "checkbox" value ="' + data.Id + '" id="checkebox-md"></div >';
                }
            },
            {
                "targets": [3],
                "render": function (data, type, row, meta) {
                    if (data === true) {
                        return '<span class="badge bg-success-transparent"><svg class="flex-shrink-0 me-2 svg-success" xmlns="http://www.w3.org/2000/svg" height="1rem" viewBox="0 0 24 24" width="1rem" fill="#000000"><path d="M0 0h24v24H0V0zm0 0h24v24H0V0z" fill="none"></path><path d="M16.59 7.58L10 14.17l-3.59-3.58L5 12l5 5 8-8zM12 2C6.48 2 2 6.48 2 12s4.48 10 10 10 10-4.48 10-10S17.52 2 12 2zm0 18c-4.42 0-8-3.58-8-8s3.58-8 8-8 8 3.58 8 8-3.58 8-8 8z"></path></svg> Evet</span>';
                    } else if (data === false) {
                        return '<span class="badge bg-warning-transparent"><svg class="flex-shrink-0 me-2 svg-warning" xmlns="http://www.w3.org/2000/svg" enable-background="new 0 0 24 24" height="1rem" viewBox="0 0 24 24" width="1rem" fill="#000000"><g><rect fill="none" height="24" width="24"></rect></g><g><g><g><path d="M15.73,3H8.27L3,8.27v7.46L8.27,21h7.46L21,15.73V8.27L15.73,3z M19,14.9L14.9,19H9.1L5,14.9V9.1L9.1,5h5.8L19,9.1V14.9z"></path><rect height="6" width="2" x="11" y="7"></rect><rect height="2" width="2" x="11" y="15"></rect></g></g></g></svg> Hayır</span>';
                    } else {
                        return '<span class="badge bg-warning-transparent">Hayır</span>';
                    }
                }

            },
            {
                "targets": [4],
                "render": function (data, type, row, meta) {
                    return '<div class="hstack gap-2">' +
                        '<a aria-label="anchor" href="/Admin/AddOrUpdateRole/' + row.id + '" class="btn btn-icon btn-wave waves-effect waves-light btn-sm btn-konfrut-light-4"><i class="ri-edit-line" data-bs-toggle="tooltip" data-bs-placement="top" title="Rol Güncelle"></i></a>' +
                        '</div>';
                }
            },
        ],
        "orderCellsTop": true,
        "fixedHeader": true,
        "pageLength": 25,
        "pagingType": "full_numbers", // Tüm sayfaları göster
        "lengthMenu": [[25, 50, 100, -1], [25, 50, 100, "Tümü"]],
        language: {
            "url": "https://cdn.datatables.net/plug-ins/1.12.0/i18n/tr.json"
        }, layout: {
            topStart: {
                "buttons": [
                    {
                        extend: 'colvis',
                        columns: ':not(.noVis)',
                        popoverTitle: 'Sütunlar'
                    },
                    {
                        extend: 'excel',
                        exportOptions: {
                            columns: ':visible' // Sadece görünür sütunları dışa aktar
                        }
                    },
                    {
                        extend: 'pdfHtml5',
                        text: 'PDF',
                        exportOptions: {
                            columns: ':visible'
                        },
                        customize: function (doc) {
                            doc.pageSize = 'A3'; // PDF boyutunu A3 olarak ayarla
                            doc.defaultStyle.fontSize = 10; // Yazı tipi boyutunu küçült
                        }
                    },
                    {
                        extend: 'csv',
                        exportOptions: {
                            columns: ':visible' // Sadece görünür sütunları dışa aktar
                        }
                    }
                ]
            }
        },
        "buttonsDom": {
            "button": {
                "tag": "button",
                "className": "btn btn-outline-secondary"
            },
            "buttonLiner": {
                "tag": null
            }
        },
        language: {
            buttons: {
                colvis: 'Sütunları Göster/Gizle' // Buton metnini burada da ekleyebilirsiniz
            }
        },
        buttons: [
            {
                extend: 'colvis',
                text: 'Sütunları Göster/Gizle', // Buton metnini buraya ekliyoruz
                collectionLayout: 'fixed two-column'
            }
        ],
    });

    $('#roleintotable thead th').each(function (i) {
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