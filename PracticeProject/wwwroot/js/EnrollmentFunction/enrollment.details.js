$(document).ready(function () {

    // Call the function when the document is ready
    getEnrollmentDetails();

});
function getEnrollmentDetails() {
    
    var id = $('#EnrollmentID').val();
    console.log("id:", id);
    var url = 'https://localhost:7153/Enrollments/GetEnrollmentDetails/' + id;
    var jwtToken = localStorage.getItem("token");
    var headers = { Authorization: `Bearer ${jwtToken}` };


    $.ajax({
        type: 'GET',
        url: url,
        dataType: 'html',
        headers:headers,
        success: function (data) {

            $('#enrollmentDetailsContainer').html(data);
            console.log("Enrollment details loaded successfully");
        },
        error: function (error) {
            console.error('Error:', error);
        }
    });
}


