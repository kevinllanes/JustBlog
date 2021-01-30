$(document).ready(function () {
    $('#cardPost').hide();
    $('#cardPage').hide();
    $('#cardCategory').hide();
    $('#cardDashboard').show();
});
$(document).off("click", "#blogDashboardTab").on("click", "#blogDashboardTab", function () {
    $('#cardPost').hide();
    $('#cardPage').hide();
    $('#cardCategory').hide();
    $('#cardDashboard').show();
});