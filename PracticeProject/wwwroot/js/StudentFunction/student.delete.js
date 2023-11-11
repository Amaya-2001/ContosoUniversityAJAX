﻿$(document).ready(function () {
    $(document).on('click', '#btnDelete', function (e) {
        e.preventDefault(); 

        var id = $('#ID').val();
        var url = 'https://localhost:7153/Students/Delete/' + id;

        $.ajax({
            type: 'POST',
            url: url,
            success: function (response) {
                console.log(response);
                if (response.success) {
                    
                    window.location.href = 'https://localhost:7153/Students/Index';
                }
            },
            error: function (error) {
                // Handle the error, e.g., display an error message.               
                console.error('Error:', error);
            }
        });
    });
});
