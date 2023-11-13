$(document).ready(function () {

    // Call the function when the document is ready
    getEnrollmentDetails();

});
function getEnrollmentDetails() {
    
    var id = $('#EnrollmentID').val();
    console.log("id:", id);
    var url = 'https://localhost:7153/Enrollments/GetEnrollmentDetails/' + id;

    $.ajax({
        type: 'GET',
        url: url,
        dataType: 'html',
        success: function (data) {

            $('#enrollmentDetailsContainer').html(data);
            console.log("Enrollment details loaded successfully");
        },
        error: function (error) {
            console.error('Error:', error);
        }
    });
}


