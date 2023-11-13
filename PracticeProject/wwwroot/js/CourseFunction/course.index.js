$(document).ready(function () {
    

    // Call the function when the document is ready
    loadCourseList();
    
});

function loadCourseList() {
    var url = 'https://localhost:7153/Courses/GetCourseList';

    $.ajax({
        type: 'GET',
        url: url,
        dataType: 'html',
        success: function (data) {

            $('#courseTableList').html(data);
        },
        error: function (error) {
            console.error('Error:', error);
        }
    });
}

