$(document).ready(function () {
    

    // Call the function when the document is ready
    loadCourseList();
    
});

function loadCourseList() {
    var url = 'https://localhost:7153/Courses/GetCourseList';
    var jwtToken = localStorage.getItem("token");
    var headers = { Authorization: `Bearer ${jwtToken}` };
    $.ajax({
        type: 'GET',
        url: url,
        dataType: 'html',
        headers:headers,
        success: function (data) {

            $('#courseTableList').html(data);
        },
        error: function (error) {
            console.error('Error:', error);
        }
    });
}

