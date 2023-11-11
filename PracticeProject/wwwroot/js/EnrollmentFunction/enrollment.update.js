﻿$(document).ready(function () {
    $(document).on('click', '#btnUpdate', function (e) {
        e.preventDefault();

        var id = $('#EnrollmentID').val();
        console.log(id);
        var url = 'https://localhost:7153/Enrollments/Edit/' + id;
        var formData = $('#formUpdate').serialize();
        console.log(formData);

        $.ajax({
            type: 'POST',
            url: url,
            data: formData,
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
