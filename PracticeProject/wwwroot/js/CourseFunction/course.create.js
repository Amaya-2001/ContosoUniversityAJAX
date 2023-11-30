$(document).ready(function () {
    $(document).on('click', '#btnCreate', function (e) {
        console.log("Button clicked");

        var formData = $('#formCreate').serialize();
        var jwtToken = localStorage.getItem("token");
        var headers = { Authorization: `Bearer ${jwtToken}` };

        $.ajax({
            type: 'POST',
            url: 'https://localhost:7153/Courses/Create',
            data: formData,
            headers: headers,
            success: function (response) {
                console.log(response);
                if (response.success) {
                    window.location.href = 'https://localhost:7153/Courses/Index';

                }

            }, error: function (error) {
                // Handle the error, e.g., display an error message.               
                console.error('Error:', error);
            }

        });
    });

});

