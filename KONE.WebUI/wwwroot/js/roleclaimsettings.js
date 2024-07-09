$(document).ready(function () {
    var datatable = $('#roleclaimtable').DataTable({
        "orderCellsTop": true,
        "fixedHeader": true,
        "pageLength": 25,
        "pagingType": "full_numbers", // Tüm sayfaları göster
        "lengthMenu": [[25, 50, 100, -1], [25, 50, 100, "Tümü"]],
        language: {
            "url": "https://cdn.datatables.net/plug-ins/1.12.0/i18n/tr.json"
        }
    });


    $('#roleclaimtable thead th').each(function () {
        var title = $(this).text();
        var classList = $(this).attr('class');

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
})

