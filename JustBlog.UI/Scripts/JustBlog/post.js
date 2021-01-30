﻿var postId;
$(document).off("click", "#blogPostTab").on("click", "#blogPostTab", function () {
    PopulatePostList();
    $('#cardPost').show();
    $('#cardPage').hide();
    $('#cardCategory').hide();
    $('#cardDashboard').hide();
});

$(document).off("click", "#btnAddPost").on("click", "#btnAddPost", function () {
    $('#PostTitle').text('Add Page');
    $('#AddEditPost').modal({ backdrop: 'static', keyboard: false });
});

function displayImage(input) {
    if (input.files && input.files[0]) {
        var readFile = new FileReader();
        readFile.onload = function (e) {
            $('#imgDisplay')
                .attr('src',e.target.result)
                .width(240)
                .height(150)
        };
        readFile.readAsDataURL(input.files[0]);
    }
}

function PopulatePostList() {
    $.ajax({
        url: '/Blog/BLog/LoadPostTab',
        type: 'GET',
        cache: false,
        success: function (data) {
            var tableId = '#postListTable';
            var columns = [
                {
                    "className": "hide_column",
                    title: "PostId", data: "PostId",
                    render: function (data, type, full) {
                        return '<input id="hdnPostId" type="hidden" value="' + full.PostId + '" />'
                    }
                },
                {
                    title: "Title", data: "Title"
                },
                { title: "Content", data: "PostContent" },
                { title: "Frequence", data: "Frequence" },
                { title: "Comment", data: "Comment" },
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
                    title: "Last Updated", data: "UpdateTime",
                    render: function (data, type, full) {
                        if (full.UpdateTime != null) {
                            return moment(full.UpdateTime).format('M/D/YYYY hh:mm A');
                        }
                        return "";
                    }
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
