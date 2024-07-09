$(document).ready(function () {

    var datatable = $('#currentCarddatatable').DataTable({
        "fixedHeader": true,
        "pageLength": 25,
        "pagingType": "full_numbers", // Tüm sayfalarý göster
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
                            columns: ':visible' // Sadece görünür sütunlarý dýþa aktar
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
                            doc.defaultStyle.fontSize = 10; // Yazý tipi boyutunu küçült
                        }
                    },
                    {
                        extend: 'csv',
                        exportOptions: {
                            columns: ':visible' // Sadece görünür sütunlarý dýþa aktar
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
                colvis: 'Sütunlarý Göster/Gizle' // Buton metnini burada da ekleyebilirsiniz
            }
        },
        buttons: [
            {
                extend: 'colvis',
                text: 'Sütunlarý Göster/Gizle', // Buton metnini buraya ekliyoruz
                collectionLayout: 'fixed two-column'
            }
        ],
    });

    $('#currentCarddatatable thead th').each(function (i) {
        var title = $(this).text();
        var classList = $(this).attr('class'); // Öðenin sýnýf listesini al

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