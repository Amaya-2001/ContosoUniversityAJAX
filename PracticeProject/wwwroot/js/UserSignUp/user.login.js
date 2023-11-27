$(document).ready(function () {
    $(document).on('click', '#btnLogin', function (e) {
        e.preventDefault(); // Prevent the default form submission behavior
        console.log("Button clicked");

        var formData = $('#loginForm').serialize();

        $.ajax({
            type: 'POST',
            url: 'https://localhost:7153/Users/LoginPost',
            data: formData,
            
            success: function (response) {
                console.log('formData', formData);

                if (response.success) {

                    console.log(response.success);
                    //window.location.href = "https://localhost:7153/Users/DashBoard"
                }

            }, error: function (error) {
                // Handle the error, e.g., display an error message.
                console.error('Error:', error);
            }

        });
    });
});
