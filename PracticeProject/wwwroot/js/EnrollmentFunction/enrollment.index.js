$(document).ready(function () {
    

    // Call the function when the document is ready
    loadEnrollmentList();
    


});

function loadEnrollmentList() {
    var url = 'https://localhost:7153/Enrollments/GetEnrollmentList';
    var jwtToken = localStorage.getItem("token");
    var headers = { Authorization: `Bearer ${jwtToken}` };


    $.ajax({
        type: 'GET',
        url: url,
        dataType: 'html',
        headers: headers,
        success: function (data) {

            $('#enrollmentTableList').html(data);
        },
        error: function (error) {
            console.error('Error:', error);
        }
    });
}

