$(document).ready(function () {
    $(document).on('click', '#btnDelete', function (e) {
        e.preventDefault();

        var id = $('#EnrollmentID').val();
        var url = 'https://localhost:7153/Enrollments/Delete/' + id;

        $.ajax({
            type: 'POST',
            url: url,
            success: function (response) {
                console.log(response);
                if (response.success) {

                    window.location.href = 'https://localhost:7153/Enrollments/Index';
                }
            },
            error: function (error) {
                // Handle the error, e.g., display an error message.               
                console.error('Error:', error);
            }
        });
    });
});
