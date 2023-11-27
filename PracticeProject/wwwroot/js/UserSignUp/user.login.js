$(document).ready(function () {
    $(document).on('submit', '#btnLogin', function (e) {
        e.preventDefault(); // Prevent the default form submission behavior
        console.log("Button clicked");

        var formData = $('#loginForm').serialize();

        $.ajax({
            type: 'POST',
            url: 'https://localhost:7153/Users/LoginPost',
            data: formData,
            
            success: function (response) {
               

                if (response.success) {

                    console.log(response.token);
                    localStorage.setItem('jwt', response.token);
                    //window.location.href = "https://localhost:7153/Users/DashBoard"
                }

            }, error: function (error) {
                // Handle the error, e.g., display an error message.
                console.error('Error:', error);
            }

        });
    });
});
