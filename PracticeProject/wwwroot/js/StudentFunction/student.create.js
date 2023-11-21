$(document).ready(function () {
    console.log("Hi");
    $(document).on('click', '#btnCreate', function (e) {
        console.log("Button clicked");
        
        var formData = $('#formCreate').serialize();
        console.log("formData");
        //alert("loading");
        
        $.ajax({
            type: 'POST',
            url: 'https://localhost:7153/Students/Create',
            data: formData,
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

