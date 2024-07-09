//------------------------- Manufactures Product Graph JS START
var productSalesChartContainer = document.getElementById('echart1');
var productSalesChart = echarts.init(productSalesChartContainer, null, { devicePixelRatio: window.devicePixelRatio });
var productSalesChartOptions;

productSalesChartOptions = {
    title: {
        text: 'Elma Satışları'
    },
    tooltip: {
        trigger: 'axis',
        axisPointer: {
            type: 'shadow'
        }
    },
    legend: {
        data: ['Satış Miktarı']
    },
    grid: {
        left: '3%',
        right: '4%',
        bottom: '3%',
        containLabel: true
    },
    xAxis: {
        type: 'category',
        data: ['Ahmet', 'Mehmet', 'Aslı', 'Ayşe', 'Fatma', 'Mustafa', 'Arda', 'Burhan', 'Dursun', 'Hatice'] // İlgili kişilerin adlarını buraya ekleyin
    },
    yAxis: {
        type: 'value',
        name: 'Satış Miktarı'
    },
    series: [
        {
            name: 'Satış Miktarı',
            type: 'bar',
            data: [123, 450, 80, 148, 159, 946, 207, 520, 684, 754], // İlgili kişilerin sattıkları miktarı buraya ekleyin,
              itemStyle: {
                color: '#76C5E4'
            }
        }
      
    ]
};

// Grafik seçeneklerini uygulama
productSalesChartOptions && productSalesChart.setOption(productSalesChartOptions);

window.addEventListener('resize', function () {
    productSalesChart.resize();
});

$(document).ready(function () {
    // İlgili butonların referanslarını alıyoruz
    const appleButton = document.getElementById('elmaButton');
    const orangeButton = document.getElementById('portakalButton');
    const pomegranateButton = document.getElementById('narButton');
    const strawberryButton = document.getElementById('cilekButton');

    // Her bir butona tıklama olayı ekliyoruz
    appleButton.addEventListener('click', function () {
        productSalesChartOptions.series[0].data = [123, 450, 80, 148, 159, 946, 207, 520, 684, 754]; // Elma için satış miktarlarını güncelliyoruz
        productSalesChartOptions.title.text = 'Elma Satışları'; // Başlığı güncelliyoruz
        productSalesChart.setOption(productSalesChartOptions); // Grafikleri güncelliyoruz
    });

    orangeButton.addEventListener('click', function () {
        productSalesChartOptions.series[0].data = [323, 250, 580, 48, 359, 846, 607, 720, 84, 554]; // Portakal için satış miktarlarını güncelliyoruz
        productSalesChartOptions.title.text = 'Portakal Satışları'; // Başlığı güncelliyoruz
        productSalesChart.setOption(productSalesChartOptions); // Grafikleri güncelliyoruz
    });

    pomegranateButton.addEventListener('click', function () {
        productSalesChartOptions.series[0].data = [160, 498, 134, 68, 735, 197, 354, 72, 546, 177]; // Nar için satış miktarlarını güncelliyoruz
        productSalesChartOptions.title.text = 'Nar Satışları'; // Başlığı güncelliyoruz
        productSalesChart.setOption(productSalesChartOptions); // Grafikleri güncelliyoruz
    });

    strawberryButton.addEventListener('click', function () {
        productSalesChartOptions.series[0].data = [10, 70, 150, 379, 415, 761, 469, 643, 245, 684]; // Çilek için satış miktarlarını güncelliyoruz
        productSalesChartOptions.title.text = 'Çilek Satışları'; // Başlığı güncelliyoruz
        productSalesChart.setOption(productSalesChartOptions); // Grafikleri güncelliyoruz
    });

    // Dropdown menüsünün referansını alıyoruz
    const chartTypeSelect = document.getElementById('chartType');

    // Dropdown menüsünün değişiklik olayını dinliyoruz
    chartTypeSelect.addEventListener('change', function () {
        const selectedChartType = chartTypeSelect.value; // Seçilen grafik türünü alıyoruz

        // Seçilen grafik türüne göre option'u güncelliyoruz
        if (selectedChartType === 'bar') {
            productSalesChartOptions.series[0].type = 'bar';
            productSalesChartOptions.yAxis.type = 'value'; // Çizgi grafiği için y ekseninin tipini güncelliyoruz
            productSalesChartOptions.series[0].label = {
                show: true,
                position: 'top',
                formatter: '{c}' // Çubuk grafiği için etiket formatını güncelliyoruz
            };
        } else if (selectedChartType === 'line') {
            productSalesChartOptions.series[0].type = 'line';
            productSalesChartOptions.yAxis.type = 'value'; // Çizgi grafiği için y ekseninin tipini güncelliyoruz
        }

        // Grafikleri güncelliyoruz
        productSalesChart.setOption(productSalesChartOptions);
    });
});
//------------------------- Manufactures Product Graph JS END


//------------------------- Manufactures Product Graph 2 JS START
var datatable = $('#currentusers').DataTable({
    "orderCellsTop": true,
    "fixedHeader": true,
    "pageLength": 25,
    "pagingType": "full_numbers",
    "lengthMenu": [[25, 50, 100, -1], [25, 50, 100, "Tümü"]],
    language: {
        "url": "https://cdn.datatables.net/plug-ins/1.12.0/i18n/tr.json"
    }
});

var products = {
    "Aslı": ["Elma", "Armut", "Çilek"],
    "Murat": ["Portakal", "Ayva", "Karpuz"],
    "Orhan": ["Ürün O1", "Ürün O2", "Ürün O3"],
    "Oktay": ["Ürün Ok1", "Ürün Ok2", "Ürün Ok3"],
    "Nuray": ["Ürün N1", "Ürün N2", "Ürün N3"],
    "Ece": ["Ürün E1", "Ürün E2", "Ürün E3"]
};

// Satır tıklama olayı
// Select2 seçildiğinde
$('#specificSizeSelectCurrentUsers').on('select2:select', function (e) {
    var selectedUser = e.params.data.text; // Seçilen kullanıcı adını al
    console.log('Selected User:', selectedUser);

    var productList = products[selectedUser]; // Seçilen kullanıcının ürün listesini al

    var dropdownMenu = $('#productDropdown');
    dropdownMenu.empty();

    // Ürünleri dropdown menüsüne ekle
    productList.forEach(function (product) {
        var option = $('<option>').text(product);
        dropdownMenu.append(option);
    });

    $('#productDropdown').show(); // Dropdown menüsünü göster
});


$(document).ready(function () {
    $('#productDropdown').change(function () {
        var data = generateRandomProductionData();
        var chart = createChart2(data);


        window.addEventListener('resize', function () {
            chart.resize();
        });
    });
});

function createChart2(data) {
    // Assuming 'echart3' is your correct container ID
    var chartsContainer = document.getElementById('echart3');

    if (!chartsContainer) {
        console.error("Container 'echart3' not found!");
        return;
    }

    // Initialize eCharts instance
    var chart = echarts.init(chartsContainer);

    // Configure chart options
    var option = {
        title: {
            text: "Üretim Verileri",
        },
        tooltip: {
            trigger: 'axis'
        },
        legend: {
            data: ['Üretim Miktarı', 'Üretim Kalitesi']
        },
        xAxis: {
            type: 'category',
            data: data.map(item => item.name)
        },
        yAxis: [{
            type: 'value',
            name: 'Amount'
        }, {
            type: 'value',
            name: 'Quality'
        }],
        series: [{
            name: 'Production Amount',
            type: 'bar',
            data: data.map(item => item.productionAmount),
            itemStyle: {
                color: '#76C5E4'  // Bar rengi
            }
        }, {
            name: 'Production Quality',
            type: 'line',
            yAxisIndex: 1,
            data: data.map(item => item.productionQuality),
            itemStyle: {
                color: '#E85924'  // Çizgi rengi
            }
        }]
    };


    // Set options and render chart
    chart.setOption(option);

    return chart;
}


//------------------------- Manufactures Product Graph 2 JS END


//------------------------- Product Distribution By Producer Graph Start
var productDistributionChartContainer = document.getElementById('echart2');
var productDistributionChart = echarts.init(productDistributionChartContainer);
var productDistributionChartOptions;

productDistributionChartOptions = {
    tooltip: {
        trigger: 'item',
        formatter: '{a} <br/>{b}: {c} ({d}%)'
    },
    legend: {
        orient: 'vertical',
        left: 10,
        data: ['İhracat', 'İç Piyasa', 'Suluk']
    },
    series: [
        {
            name: 'Müstahsil Ürün Dağılımı',
            type: 'pie', // Pie olarak bırakılıyor
            radius: ['50%', '70%'],
            avoidLabelOverlap: false,
            label: {
                show: true,
                formatter: '{b}: {d}%', // Her dilim üzerinde kategori adı ve yüzdelik değeri gösteriliyor
                fontSize: 14,
                fontWeight: 'bold'
            },
            emphasis: {
                label: {
                    show: true,
                    fontSize: 20,
                    fontWeight: 'bold'
                }
            },
            labelLine: {
                show: false
            },
            data: [],
            color: ['#E85924', '#163257', '#80C65B']
        }
    ]
};

var farmersData = {
    '1': [60, 20, 20],
    '2': [50, 30, 20],
    '3': [40, 40, 20],
    '4': [70, 15, 15],
    '5': [55, 25, 20],
    '6': [45, 35, 20],
    '7': [65, 20, 15],
    '8': [75, 15, 10],
    '9': [60, 25, 15],
    '10': [50, 30, 20]
};

// Dropdown değiştiğinde grafik güncellemesi
var farmerSelectElement = document.getElementById('farmers');
var farmerNameDisplayElement = document.getElementById('farmername');
$('#farmers').on('select2:select', function (e) {
    var selectedFarmerId = e.params.data.id;
    var selectedFarmerName = e.params.data.text;
    var selectedFarmerData = farmersData[selectedFarmerId];

    // Update DOM elements
    document.getElementById('farmername').innerText = selectedFarmerName;

    // Call function to update chart
    updateProductDistributionChart(selectedFarmerData);
});


function updateProductDistributionChart(data) {
    productDistributionChartOptions.series[0].data = [
        { value: data[0], name: 'İhracat' },
        { value: data[1], name: 'İç Piyasa' },
        { value: data[2], name: 'Suluk' }
    ];
    productDistributionChart.setOption(productDistributionChartOptions);
}

// İlk başta bir müstahsilin grafiğini göster
var initialFarmer = farmerSelectElement.value;

productDistributionChart.setOption(productDistributionChartOptions);

window.addEventListener('resize', function () {
    productDistributionChart.resize();
});
//------------------------- Product Distribution By Producer Graph End



//------------------------- Quality Management By Provinces Graph Start
$.ajax({
    url: '/StatisticsVisualization/ProvinceList',
    method: 'GET',
    dataType: 'json',
    success: function (data) {
        var checkboxContainer = $('#provinces'); // Bu container checkboxları içerecek bir div veya başka bir element olmalı
        checkboxContainer.empty(); // Önce container'ı boşaltıyoruz

        $.each(data, function (index, province) {
            var checkboxDiv = $('<div>', { class: 'form-check' });
            var checkboxInput = $('<input>', {
                class: 'form-check-input',
                type: 'checkbox',
                value: province.id,
                id: 'province' + province.id // Örneğin: province1, province2, ...
            });
            var checkboxLabel = $('<label>', {
                class: 'form-check-label',
                for: 'province' + province.id,
                text: province.name
            });

            checkboxDiv.append(checkboxInput).append(checkboxLabel);
            checkboxContainer.append(checkboxDiv);
        });
    },
    error: function (xhr, status, error) {
        console.error('Error fetching provinces:', error);
    }
});

// İl seçildiğinde grafik oluştur
$('#provinces').on('change', '.form-check-input', function () {
    var isChecked = $(this).prop('checked'); // Checkbox'un checked durumunu alır

    if (isChecked) {
        // Checkbox seçili ise buraya gelen kodları ekleyebilirsiniz
        var selectedProvinces = []; // Seçilen il id'lerini saklamak için boş bir dizi oluşturuyoruz.

        // Tüm checkbox'ları dolaşıyoruz.
        $('.form-check-input:checked').each(function () {
            selectedProvinces.push($(this).val()); // Seçili checkbox'ın değerini (il id) diziye ekliyoruz.
        });

        // En az bir il seçilmişse işlem yap
        if (selectedProvinces.length > 0) {
            // Rastgele veri oluşturma işlevini çağır
            var data = generateRandomData();
            createChart(data); // Oluşturulan verilerle grafik oluştur
        } else {
            // Hiçbir il seçili değilse, grafik veya başka bir işlem yapma
            // Örneğin, console'da bir mesaj gösterebiliriz:
            console.log("Lütfen bir il seçiniz.");
        }
    } else {
        // Checkbox seçili değil ise buraya gelen kodları ekleyebilirsiniz
        console.log("Checkbox seçili değil.");
        // Örneğin, bir işlem yapmayabiliriz veya uyarı verebiliriz.
    }
});


// Rastgele veri oluşturma fonksiyonu
function generateRandomData() {
    var producers = ['Aslı', 'Mehmet', 'Burhan', 'Orhan', 'Tekin'];
    var data = [];
    for (var i = 0; i < producers.length; i++) {
        data.push({
            name: producers[i],
            productionAmount: Math.floor(Math.random() * 100) + 1, // 1 ile 100 arasında rastgele miktar
            productionQuality: Math.floor(Math.random() * 100) + 1 // 1 ile 100 arasında rastgele kalite
        });
    }
    return data;
}

function generateRandomProductionData() {
    var producers = ['1. Üretim', '2. Üretim', '3. Üretim', '4. Üretim', '5. Üretim', '6. Üretim','7. Üretim'];
    var data = [];
    for (var i = 0; i < producers.length; i++) {
        data.push({
            name: producers[i],
            productionAmount: Math.floor(Math.random() * 100) + 1, // 1 ile 100 arasında rastgele miktar
            productionQuality: Math.floor(Math.random() * 100) + 1 // 1 ile 100 arasında rastgele kalite
        });
    }
    return data;
}

// ECharts grafiğini oluştur
function createChart(data, provinceId) {
    var chartsContainer = document.getElementById('charts-container');

    // Yeni kart için bir div oluştur
    var cardDiv = document.createElement('div');
    cardDiv.className = 'card col-md-6 p-2';
    cardDiv.style.marginBottom = '20px'; // Grafik kartının altında 20px'lik bir boşluk bırakır

    // Seçilen seçim kutusu metnini al
    var selectedProvinceText = $('#provinces option:selected').text();

    // Satır oluştur
    var rowDiv = document.createElement('div');
    rowDiv.className = 'row align-items-center'; // Satırı dikeyde hizalar
    rowDiv.style.marginBottom = '10px'; // Satırın altında 10px'lik bir boşluk bırakır

    // Seçilen seçim kutusu metnini içeren div
    var textDiv = document.createElement('div');
    textDiv.className = 'col-md-6'; // İl metni ve buton yarımşar genişlikte olsun
    textDiv.textContent = selectedProvinceText;
    textDiv.style.fontSize = "15px";
    textDiv.style.fontWeight = "bolder";
    rowDiv.appendChild(textDiv);

    // Kapatma butonu
    var closeButton = document.createElement('button');
    closeButton.className = 'close-btn btn btn-danger';
    closeButton.innerHTML = "&#x2716;"; // Unicode kapatma işareti (✖)
    closeButton.onclick = function () {
        chartsContainer.removeChild(cardDiv);
    };

    // Buton divini oluştur ve stili ayarla
    var closeButtonDiv = document.createElement('div');
    closeButtonDiv.className = 'col-md-6 d-flex justify-content-end align-items-center'; // Butonu sağa ve dikeyde hizalar
    closeButtonDiv.style.height = '100%'; // Buton divinin yüksekliğini 100% olarak ayarla

    // Butonu buton divine ekle
    closeButtonDiv.appendChild(closeButton);

    // Satır divine buton divini ekle
    rowDiv.appendChild(closeButtonDiv);


    // Kartı ve satırı chartsContainer'a ekle
    cardDiv.appendChild(rowDiv);
    chartsContainer.appendChild(cardDiv);

    // Yeni grafik için bir div oluştur
    var chartDiv = document.createElement('div');
    chartDiv.style.width = '100%'; // Grafik kartının tam genişliğinde olmasını sağlar
    chartDiv.style.height = '400px';
    cardDiv.appendChild(chartDiv);

    var myChart = echarts.init(chartDiv);
    var option = {
        title: {
            text: "",
        },
        tooltip: {
            trigger: 'axis'
        },
        legend: {
            data: ['Üretim Miktarı', 'Üretim Kalitesi']
        },
        xAxis: {
            type: 'category',
            data: data.map(item => item.name) // Müstahsil isimleri
        },
        yAxis: [{
            type: 'value',
            name: 'Miktar'
        }, {
            type: 'value',
            name: 'Kalite'
        }],
        series: [{
            name: 'Üretim Miktarı',
            type: 'bar', itemStyle: {
                color: '#76C5E4' // Bar rengi
            },
            data: data.map(item => item.productionAmount), // Üretim miktarları
            
        }, {
            name: 'Üretim Kalitesi',
            type: 'line',
            yAxisIndex: 1,
            itemStyle: {
                color: '#E85924' // Çizgi rengi
            },
            data: data.map(item => item.productionQuality) // Üretim kaliteleri
        }]
    };
    myChart.setOption(option);
    // Grafik boyutunu yeniden ayarla
    window.addEventListener('resize', function () {
        myChart.resize();
    });
}
//------------------------- Quality Management By Provinces Graph End


//------------------------- Quality Management By Provinces Graph End
$(document).ready(function () {
    $('#currentuserstimeline tr').click(function () {
        // Tüm satırların arka plan rengini temizle
        $('#currentuserstimeline tr').removeClass('selected-row');

        // Seçilen satırın arka plan rengini değiştir
        $(this).addClass('selected-row');

        var selectedUser = $(this).data('user');
        console.log('Selected User:', selectedUser); // Seçilen müşteri adını konsola yazdır

        // Rastgele meyve isimleri
        var fruits = ['Elma', 'Armut', 'Muz', 'Çilek', 'Portakal'];

        // Dropdown'ı temizle
        var $dropdown = $('#productDropdownTimeLine');
        $dropdown.empty();
        $dropdown.append('<option value="">Lütfen Ürün Seçiniz</option>');

        // Dropdown'ı meyve isimleri ile doldur
        fruits.forEach(function (fruit) {
            $dropdown.append('<option value="' + fruit + '">' + fruit + '</option>');
        });
    });

});
function createTimeline() {
    var selectedFruit = $('#productDropdownTimeLine').val();
    if (!selectedFruit) {
        console.log('Lütfen bir meyve seçiniz');
        return;
    }

    console.log('Selected Fruit:', selectedFruit); // Seçilen meyveyi konsola yazdır

    // Rastgele timeline verileri oluştur
    var timelineData = generateRandomTimelineData(selectedFruit);

    // Timeline'ı oluştur
    var $timeline = $('.timelinediv');
    $timeline.empty();

    timelineData.forEach(function (item) {
        var timelineItem = '<ul class="timeline list-unstyled"><li>' +
            '<div class="timeline-time text-end">' +
            '<span class="date">' + item.date + '</span>' +
            '<span class="time d-inline-block">' + item.time + '</span>' +
            '</div>' +
            '<div class="timeline-icon">' +
            '<a href="javascript:void(0);"></a>' +
            '</div>' +
            '<div class="timeline-body">' +
            '<div class="d-flex align-items-top timeline-main-content flex-wrap mt-0">' +
            '<div class="avatar avatar-md online me-3 avatar-rounded mt-sm-0 mt-4">' +
            '<img alt="avatar" src="' + item.avatar + '">' +
            '</div>' +
            '<div class="flex-fill">' +
            '<div class="d-flex align-items-center">' +
            '<div class="mt-sm-0 mt-2">' +
            '<p class="mb-0 fs-14 fw-semibold">' + item.user + '</p>' +
            '<p class="mb-0 text-muted">' + item.content + '</p>' +
            '</div>' +
            '<div class="ms-auto">' +
            '<span class="float-end badge bg-light text-muted timeline-badge">' +
            item.badge +
            '</span>' +
            '</div>' +
            '</div>' +
            '</div>' +
            '</div>' +
            '</div>' +
            '</li>';
            '</ul>';
        $timeline.append(timelineItem);
    });
}

function generateRandomTimelineData(fruit) {
    // Örnek rastgele Türkçe timeline verileri
    var explanations = [
        fruit + ' kantar işlemi gerçekleştirildi.',
        fruit + ' sevkiyata çıktı.',
        fruit + ' soğuk hava depolarına yerleştirildi.',
        fruit + ' kalite kontrolü yapıldı.',
        fruit + ' ambalajlandı.',
        fruit + ' satışa hazır hale getirildi.',
        fruit + ' satış noktasına gönderildi.',
        fruit + ' depoda kontrol edildi.',
        fruit + ' müşteri onayı alındı.',
        fruit + ' yola çıktı.',
        fruit + ' üretim tamamlandı.',
        fruit + ' kalite testleri yapıldı.',
        fruit + ' teslim edildi.',
        fruit + ' geri bildirimi alındı.',
        fruit + ' yeniden sipariş verildi.'
    ];

    var names = ['Ahmet Yılmaz', 'Ayşe Demir', 'Mehmet Şahin', 'Fatma Kara', 'Ali Vural', 'Emine Özkan', 'Hasan Çelik', 'Elif Aydın', 'Osman Koç', 'Zeynep Kaya'];

    function getRandomElement(arr) {
        return arr[Math.floor(Math.random() * arr.length)];
    }

    function getRandomDate() {
        var days = ['PAZARTESİ', 'SALI', 'ÇARŞAMBA', 'PERŞEMBE', 'CUMA', 'CUMARTESİ', 'PAZAR'];
        var day = getRandomElement(days);
        var hour = Math.floor(Math.random() * 24);
        var minute = Math.floor(Math.random() * 60);
        return {
            day: day,
            time: (hour < 10 ? '0' + hour : hour) + ':' + (minute < 10 ? '0' + minute : minute)
        };
    }

    // Rastgele bir sayı seç (2 ile 8 arasında)
    var numberOfEntries = Math.floor(Math.random() * 7) + 2;

    var timelineData = [];
    for (var i = 0; i < numberOfEntries; i++) {
        var randomDate = getRandomDate();
        timelineData.push({
            date: randomDate.day,
            time: randomDate.time,
            avatar: '../Theme/HTML/src/assets/images/faces/oxfam_176585.png',
            user: getRandomElement(names),
            content: getRandomElement(explanations),
            badge: new Date().toLocaleDateString('tr-TR') // Bugünün tarihi
        });
    }

    return timelineData;
}


//------------------------- Quality Management By Provinces Graph Start



//------------------------- Scripts for all view  starts
$(document).ready(function () {
    $(".list-group-item").click(function () {
        $(".list-group-item").removeClass("active");
        $(this).addClass("active");
    });
});
//------------------------- Scripts for all view  ends
