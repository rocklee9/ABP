
$(document).ready(function () {
    $('.datepicker').datepicker({
        format: consts.datetime_format,
        autoclose: true,
        language: consts.lang //import bootstrap-datepicker.vi.min.js to change language to Vietnamese
    });
    /*Daterangepicker */
    $('.daterangepicker-notime').daterangepicker({
        "singleDatePicker": true,
        "autoUpdateInput": false,
        "locale": {
            "format": "DD/MM/YYYY",
            "separator": " - ",
            "applyLabel": "Chọn",
            "cancelLabel": "Huỷ",
            "customRangeLabel": "Custom",
            "weekLabel": "W",
            "daysOfWeek": [
                "CN",
                "T2",
                "T3",
                "T4",
                "T5",
                "T6",
                "T7"
            ],
            "monthNames": [
                "Tháng 1",
                "Tháng 2",
                "Tháng 3",
                "Tháng 4",
                "Tháng 5",
                "Tháng 6",
                "Tháng 7",
                "Tháng 8",
                "Tháng 9",
                "Tháng 10",
                "Tháng 11",
                "Tháng 12"
            ],
            "firstDay": 1
        },
        "opens": "right"
    });
    $('.daterangepicker-notime').on('apply.daterangepicker', function(ev, picker) {
        $(this).val(picker.startDate.format('DD/MM/YYYY'));
    });
  
    $('.daterangepicker-notime').on('cancel.daterangepicker', function(ev, picker) {
        $(this).val('');
    });
    
    $('.daterangepicker-hastime').daterangepicker({
        "singleDatePicker": true,
        "timePicker": true,
        "timePicker24Hour": true,
        "autoUpdateInput": false,
        "locale": {
            "format": "HH:mm - DD/MM/YYYY",
            "separator": " - ",
            "applyLabel": "Chọn",
            "cancelLabel": "Huỷ",
            "customRangeLabel": "Custom",
            "weekLabel": "W",
            "daysOfWeek": [
                "CN",
                "T2",
                "T3",
                "T4",
                "T5",
                "T6",
                "T7"
            ],
            "monthNames": [
                "Tháng 1",
                "Tháng 2",
                "Tháng 3",
                "Tháng 4",
                "Tháng 5",
                "Tháng 6",
                "Tháng 7",
                "Tháng 8",
                "Tháng 9",
                "Tháng 10",
                "Tháng 11",
                "Tháng 12"
            ],
            "firstDay": 1
        },
        "opens": "right"
    });
    $('.daterangepicker-hastime').on('apply.daterangepicker', function(ev, picker) {
        $(this).val(picker.startDate.format('HH:mm - DD/MM/YYYY'));
    });
  
    $('.daterangepicker-hastime').on('cancel.daterangepicker', function(ev, picker) {
        $(this).val('');
    });
    /*Chart */
    var ctx3 = document.getElementById('line-chart');
    var myChart = new Chart(ctx3, {
        type: 'line',
        data: {
            labels: [
                'Tháng 1',
                'Tháng 2',
                'Tháng 3',
                'Tháng 4',
                'Tháng 5',
                'Tháng 6',
                'Tháng 7',
                'Tháng 8',
                'Tháng 9',
                'Tháng 10',
                'Tháng 11',
                'Tháng 12'
            ],
            datasets: [{
                label: '',
                data: [400, 535, 680, 800, 790, 710, 650, 780, 800, 900, 1000],
                fill:false,
                borderColor: '#3A96FD',
                lineTension: 0.1
            }]
        },
        options: {
            legend: {
                display: false
            },
            scales: {
                yAxes: [{
                    ticks: {
                        beginAtZero: true
                    },
                    gridLines: {
                        borderDash: [4, 4],
                    }
                }],
                xAxes: [{
                    ticks: {
                        beginAtZero: true
                    },
                    gridLines: {
                        borderDash: [4, 4],
                    }
                }],
                pointLabels :{
                    fontColor: '#212529'
                }
            }
        }
    });
    $(".js-select2").select2();
    // $(".form-select2").select2({
    //     minimumResultsForSearch: Infinity
    // });


})
$('.submitButton').click(function () {
    if ($(this).hasClass('active')) {
        $(this).removeClass('active')
        $('body').removeClass("fixedPosition");
    } else {
        $(this).addClass('active')
        $('body').addClass("fixedPosition");
    }
})

function htmldecode(str) {
    var txt = document.createElement('textarea');
    txt.innerHTML = str;
    return txt.value;
}

function formatdate(str) {
    var date = new Date(str);
    var formatDate = date.getDate() + "/" + (date.getMonth() + 1) + "/" + date.getFullYear()
    return formatDate;
}

function commaSeparateNumber(val) {
    while (/(\d+)(\d{3})/.test(val.toString())) {
        val = val.toString().replace(/(\d+)(\d{3})/, '$1' + ',' + '$2');
    }
    return val;
}

