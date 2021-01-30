var categoryId;
$(document).off("click", "#blogCategoryTab").on("click", "#blogCategoryTab", function () {
    PopulateCategoryList();
    $('#cardCategory').show();
    $('#cardPage').hide();
    $('#cardPost').hide();
    $('#cardDashboard').hide();
});


$(document).off("click", "#btnAddCategory").on("click", "#btnAddCategory", function () {
    $('#CategoryTitle').text('Add Category');
    $('#AddEditCategory').modal({ backdrop: 'static', keyboard: false });
});

$(document).off("click", "#btnCategoryClose").on("click", "#btnCategoryClose", function () {
    ClearPage();
    $('#AddEditCategory').modal('hide');
});

$(document).off("click", "#btnCategoryClose1").on("click", "#btnCategoryClose1", function () {
    ClearCategory();
    $('#AddEditCategory').modal('hide');
});

$(document).off("click", "#btnSaveCategory").on("click", "#btnSaveCategory", function () {
    var model;

    var category = $("#category").val();
    var description = $("#categoryDescription").val();
    model = {
        CategoryId: categoryId,
        CategoryName: category,
        Description: description
    };

    $.ajax({
        url: '/blog/blog/AddorUpdateCategory',
        data: { viewModel: model },
        type: "POST",
        cache: false,
        success: function (data) {
            alert("Category successfully saved.");
            $('#AddEditCategory').modal('hide');
            PopulateCategoryList();
            ClearCategory();

        },
        error: function (data) {
            alert("An error occurred while processing the data.");
        }
    });
});

$(document).off("click", "#btnEditCategory").on("click", "#btnEditCategory", function () {
    categoryId = $(this).closest('tr').find('#hdnCategoryId').val();
    $('#categoryId').val(categoryId);
    $.ajax({
        url: '/Blog/BLog/GetCategoryById',
        type: "GET",
        cache: false,
        data: { categoryId: categoryId },
        success: function (data) {
            $("#category").val(data.CategoryName);
            $('#categoryDescription').val(data.Description);
            $('#AddEditCategory').modal({ backdrop: 'static', keyboard: false });
        },
        error: function (response) {
            alert("Error retreiving data");
        }
    });
});

$(document).off("click", "#btnDeletePage").on("click", "#btnDeletePage", function () {
    categoryId = $(this).closest('tr').find('#hdnCategoryId').val();
    $('#categoryId').val(categoryId);
    alert("Sorry this features is for admin use only");
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
                    title: "Description", data: "Description"
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
                        if (full.CategoryName != null) {
                            return '<button id="btnEditCategory" class="btn btn-primary"><i class="fa fa-edit fa-xs"></i></button> <button id = "btnDeleteCategory" class="btn btn-danger"><i class="fa fa-trash fa-xs"></button>'
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

function ClearCategory() {
    categoryId = 0;
    $("#categoryId").val(0);
    $("#category").val('');
    $("#categoryDescription").val('');
}