


//*****************************Page Tab**************************************************//
var pageId;
$(document).off("click", "#blogPageTab").on("click", "#blogPageTab", function () {
    PopulatePageList();
    $('#cardPage').show();
    $('#cardPost').hide();
    $('#cardCategory').hide();
    $('#cardDashboard').hide();
});

$(document).off("click", "#btnAddPage").on("click", "#btnAddPage", function () {
    $('#PageTitle').text('Add Page');
    $('#AddEditPage').modal({ backdrop: 'static', keyboard: false });
});

$(document).off("click", "#btnPageClose").on("click", "#btnPageClose", function () {
    ClearPage();
    $('#AddEditPage').modal('hide');
});

$(document).off("click", "#btnPageClose1").on("click", "#btnPageClose1", function () {
    ClearPage();
    $('#AddEditPage').modal('hide');
});

$(document).off("click", "#btnSavePage").on("click", "#btnSavePage", function () {
    var model;

    var title = $("#title").val();
    var content = $("#content").val();
    model = {
        PageId: pageId,
        Title: title,
        PagesContent: content
    };

    $.ajax({
        url: '/blog/blog/AddorUpdatePage',
        data: { viewModel: model },
        type: "POST",
        cache: false,
        success: function (data) {
            alert("Page successfully saved.");
            $('#AddEditPage').modal('hide');
            PopulatePageList();
            ClearPage();

        },
        error: function (data) {
            alert("An error occurred while processing the data.");
        }
    });
});

$(document).off("click", "#btnEditPage").on("click", "#btnEditPage", function () {
    pageId = $(this).closest('tr').find('#hdnPageId').val();
    $('#pageId').val(pageId);
    $.ajax({
        url: '/Blog/BLog/GetPageById',
        type: "GET",
        cache: false,
        data: { pageId: pageId },
        success: function (data) {
            $("#title").val(data.Title);
            $('#content').val(data.PagesContent);
            $('#AddEditPage').modal({ backdrop: 'static', keyboard: false });
        },
        error: function (response) {
            alert("Error retreiving data");
        }
    });
});

$(document).off("click", "#btnDeletePage").on("click", "#btnDeletePage", function () {
    pageId = $(this).closest('tr').find('#hdnPageId').val();
    $('#pageId').val(pageId);
    alert("Sorry this features is for admin use only");
});

function PopulatePageList() {
    $.ajax({
        url: '/Blog/BLog/LoadPageTab',
        type: 'GET',
        cache: false,
        success: function (data) {
            var tableId = '#pageListTable';
            var columns = [
                {
                    "className": "hide_column",
                    title: "Title", data: "PageId",
                    render: function (data, type, full) {
                        return '<input id="hdnPageId" type="hidden" value="' + full.PageId + '" />'
                    }
                },
                {
                    title:"Title", data: "Title"
                },
                { title:"Content", data: "PagesContent" },
                {
                    title:"Date Created", data: "CreateTime",
                    render: function (data, type, full) {
                        if (full.CreateTime != null) {
                            return moment(full.CreateTime).format('M/D/YYYY hh:mm A');
                        }
                        return "";
                    }
                },
                {
                    title:"Last Updated", data: "UpdateTime",
                    render: function (data, type, full) {
                        if (full.UpdateTime != null) {
                            return moment(full.UpdateTime).format('M/D/YYYY hh:mm A');
                        }
                        return "";
                    }
                },
                {
                    title:"Actions",
                    render: function (data, type, full) {
                        if (full.Title != null) {
                            return '<button id="btnEditPage" class="btn btn-primary"><i class="fa fa-edit fa-xs"></i></button> <button id = "btnDeletePage" class="btn btn-danger"><i class="fa fa-trash fa-xs"></button>'
                        }
                        return "";
                     }
                }
            ];
            if ($.fn.dataTable.isDataTable(tableId)) {
                $(tableId).DataTable().clear().destroy();
                $(tableId).empty();
            }
         PageTable = $(tableId).DataTable({
             "data": data,
             "columns": columns,
             "processing": true,
             "deferRender": true,
             "bLengthChange": false,
             "paging": true,
             "iDisplayLength": 10,
             "info": true,
             "sPaginationType": "simple_numbers",
             "oLanguage": {
                 "sProcessing": "Loading, please wait...",
                 "sEmptyTable": "No Data Available"
             },
             "order": [[0, "desc"]],
             "dom":
                 "<'row'<'col-sm-12 col-md-10'l><'col-sm-12 col-md-2'f>>" +
                 "<'row'<'col-sm-12'tr>>" +
                 "<'row'<'col-sm-12 col-md-10'i><'col-sm-12 col-md-2'p>>"
         });
        },
        error: function (data) {
            alert("Error retreiving data.")
        }
    });
}

function ClearPage() {
    pageId = 0;
    $("#pageId").val(0);
    $("#title").val('');
    $("#content").val('');
}