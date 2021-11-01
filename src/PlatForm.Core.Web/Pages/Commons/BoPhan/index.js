$(function () {
    var l = abp.localization.getResource('Core');

    var createModal = new abp.ModalManager(abp.appPath + 'Commons/BoPhan/CreateModal');
    var editModal = new abp.ModalManager(abp.appPath + 'Commons/BoPhan/EditModal');

    var dataTable = $('#BoPhanTable').DataTable(abp.libs.datatables.normalizeConfiguration({
        processing: true,
        serverSide: true,
        paging: true,
        searching: false,
        autoWidth: true,
        fixedColumns: true,
        fixedHeader: true,
        bLengthChange: false,
        scrollCollapse: true,
        ordering: false,
        ajax: abp.libs.datatables.createAjax(platForm.core.commons.boPhan.getList),
        columnDefs: [
            {
                render: function (data, type, full, meta) {
                    var table = $('#BoPhanTable').DataTable();
                    var info = table.page.info();
                    return info.page * table.page.len() + meta.row + 1;
                },
                className: "text_center",
                width: "5%"
            },
            { data: "name", width: "65%" },
            { data: "ghiChu", width: "20%" },
            {
                className: "action_table",
                data: "id", render: function (data) {
                    var htmlRender = '';
                    if (abp.auth.isGranted('Common.BoPhan.Update')) {
                        htmlRender += '<button title="Chỉnh sửa" class="btn-action btn-edit" type="button" _type="edit" _id="'
                            + data + '"><i class="fa fa-pencil-square-o"></i></button>';
                    }
                    if (abp.auth.isGranted('Common.BoPhan.Delete')) {
                        htmlRender += '<button title="Xóa" class="btn-action btn-delete" type="button" _id="'
                            + data + '"><i class="fa fa-trash-o"></i> </button>';
                    }
                    return htmlRender;
                },
                width: "10%"
            },

        ],
        "fnDrawCallback": function (oSettings) {
            if ($('#BoPhanTable').DataTable().page.info().pages < 2) {
                $('.dataTable_footer').hide();
            } else {
                $('.dataTable_footer').show();
            }
        }
    }));

    $('#BoPhanTable tbody').on('click', 'button', function () {
        var id = $(this).attr("_id");
        if ($(this).attr("_type") === "edit") {
            editModal.open({ id: id });
        } else {
            abp.message.confirm(
                l('MsgDelete'),
                l('MsgDeleteTitle'),
                function (isConfirmed) {
                    if (isConfirmed) {
                        platForm.core.commons.boPhan
                            .delete(id)
                            .then(function () {
                                abp.notify.info(l('SuccessfullyDeleted'));
                                dataTable.ajax.reload();
                            });
                    }
                });
        }

    });

createModal.onResult(function () {
    dataTable.ajax.reload();
});

editModal.onResult(function () {
    dataTable.ajax.reload(null, false);
});

$('#NewBoPhan').click(function (e) {
    e.preventDefault();
    createModal.open();
});

$('#Search').click(function () {
    Search();
});

$('#keyword').keypress(function (event) {
    var keycode = (event.keyCode ? event.keyCode : event.which);
    if (keycode == '13') {
        Search();
    }
});

function Search() {
    dataTable.destroy();
    var input = {
        'keyword': $("#keyword").val(),
        'SkipCount': 0,
        'MaxResultCount': 10
    }
    dataTable = $('#BoPhanTable').DataTable(abp.libs.datatables.normalizeConfiguration({
        processing: true,
        serverSide: true,
        paging: true,
        searching: false,
        autoWidth: true,
        fixedColumns: true,
        fixedHeader: true,
        bLengthChange: false,
        scrollCollapse: true,
        ordering: false,
        ajax: abp.libs.datatables.createAjax(platForm.core.commons.boPhan.search, function () {
            return input;
        }),
        columnDefs: [
            {
                render: function (data, type, full, meta) {
                    var table = $('#BoPhanTable').DataTable();
                    var info = table.page.info();
                    return info.page * table.page.len() + meta.row + 1;
                },
                className: "text_center",
                width: "5%"
            },
            { data: "name", width: "65%" },
            { data: "ghiChu", width: "20%" },
            {
                className: "action_table",
                data: "id", render: function (data) {
                    var htmlRender = '';
                    if (abp.auth.isGranted('Common.BoPhan.Update')) {
                        htmlRender += '<button title="Chỉnh sửa" class="btn-action btn-edit" type="button" _type="edit" _id="'
                            + data + '"><i class="fa fa-pencil-square-o"></i></button>';
                    }
                    if (abp.auth.isGranted('Common.BoPhan.Delete')) {
                        htmlRender += '<button title="Xóa" class="btn-action btn-delete" type="button" _id="'
                            + data + '"><i class="fa fa-trash-o"></i> </button>';
                    }
                    return htmlRender;
                },
                width: "10%"
            },

        ],
        "fnDrawCallback": function (oSettings) {
            if ($('#BoPhanTable').DataTable().page.info().pages < 2) {
                $('.dataTable_footer').hide();
            } else {
                $('.dataTable_footer').show();
            }
        }
    }));
}

//Check tránh trường hợp nhập khoảng trắng
$("input").on('change', function () {
    $(this).val($(this).val().trim());
});
});
