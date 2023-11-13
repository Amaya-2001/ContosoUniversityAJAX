$(document).ready(function () {

    // Call the function when the document is ready
    getCourseDetails();

});
function getCourseDetails() {

    var id = $('#CourseID').val();
    console.log("id:", id);
    var url = 'https://localhost:7153/Courses/GetCourseDetails/' + id;

    $.ajax({
        type: 'GET',
        url: url,
        dataType: 'html',
        success: function (data) {

            $('#courseDetailsContainer').html(data);
            console.log("Course details loaded successfully");
        },
        error: function (error) {
            console.error('Error:', error);
        }
    });
}


