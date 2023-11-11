$(document).ready(function () {
    function loadEnrollmentList() {
        var url = 'https://localhost:7153/Enrollments/Index';

        $.ajax({
            type: 'GET',
            url: url,
            dataType: 'html',
            success: function (data) {

                $('#enrollmentTable tbody').replaceWith($(data).find('#enrollmentTable tbody'));
            },
            error: function (error) {
                console.error('Error:', error);
            }
        });
    }

    // Call the function when the document is ready
    loadEnrollmentList();
    $(document).on('click', '#btnCreate', function (e) {
        e.preventDefault();
        var url = 'https://localhost:7153/Enrollments/Create';
        loadStudentForm(url, null);
    });


});

