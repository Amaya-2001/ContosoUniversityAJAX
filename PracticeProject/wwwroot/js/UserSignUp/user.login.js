$(document).ready(function () {

    setupLogInForm();
});

function setupLogInForm() {
   $('#formLogin').submit(function (e) {
        e.preventDefault();
        
        var formData = $(this).serialize();
        console.log(formData);
        $.ajax({
            type: 'POST',
            url: 'https://localhost:7153/Users/LoginPost',
            data: formData,
            success: function (response) {
                if (response.success) {
                    console.log(response.token);
                    localStorage.setItem('token', response.token);
                    
                    setTimeout(function () {
                        window.location.href = 'https://localhost:7153/Students/';
                    }, 2000);
                }
                else {
                    
                    console.error('Error:', response.error);

                }
            },
            error: function (error) {
                
                console.error('Error:', error);
            }
        });
    });
}
