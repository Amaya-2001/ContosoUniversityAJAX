$(document).ready(function () {
    console.log("Hi");
    $(document).on('click', '#btnCreate', function (e) {
       
        var formData = $('#formCreate').serialize();
        var jwtToken = localStorage.getItem("token");
        var headers = { Authorization: `Bearer ${jwtToken}` };
        console.log("jwtToken", jwtToken);
        console.log("headers", headers);
       
        
        $.ajax({
            type: 'POST',
            url: 'https://localhost:7153/Students/Create',
            data: formData,
            headers: headers,
            success: function (response) {
                console.log(response);
                if (response.success) {
                    window.location.href = 'https://localhost:7153/Students/Index';

                }

            }, error: function (error) {
                // Handle the error, e.g., display an error message.               
                console.error('Error:', error);
            }

            });
});

});

