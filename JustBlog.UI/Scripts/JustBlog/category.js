var categoryId;
$(document).off("click", "#blogCategoryTab").on("click", "#blogCategoryTab", function () {
    PopulateCategoryList();
    $('#cardCategory').show();
    $('#cardPage').hide();
    $('#cardPost').hide();
    $('#cardDashboard').hide();
});

function PopulateCategoryList() {
    $.ajax({
        url: '/Blog/BLog/LoadCategoryTab',
        type: 'GET',
        cache: false,
        success: function (data) {
            var tableId = '#categoryListTable';
            var columns = [
                {
                    "className": "hide_column",
                    title: "CategoryId", data: "CategoryId",
                    render: function (data, type, full) {
                        return '<input id="hdnCategoryId" type="hidden" value="' + full.CategoryId + '" />'
                    }
                },
                {
                    title: "Category Name", data: "CategoryName"
                },
                {
                    title: "Date Created", data: "CreateTime",
                    render: function (data, type, full) {
                        if (full.CreateTime != null) {
                            return moment(full.CreateTime).format('M/D/YYYY hh:mm A');
                        }
                        return "";
                    }
                },
                {
                    title: "Frequence", data: "Frequence",
                },
                {
                    title: "Actions",
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