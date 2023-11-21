$(document).ready(function () {
$(document).on('click', '#btnSignUp', function (e) {
        console.log("Button clicked");

        var formData = $('#signUpForm').serialize();
        console.log("formData");
        //alert("loading");

        $.ajax({
            type: 'POST',
            url: 'https://localhost:7153/Users/SignUpPost',
            data: formData,
            success: function (response) {
                console.log(response);
                if (response.success) {
                    console.log("user saved sucussFully!");
                    window.location.href = "https://localhost:7153/Users/Login"

                }

            }, error: function (error) {
                // Handle the error, e.g., display an error message.               
                console.error('Error:', error);
            }

        });
    });

});

