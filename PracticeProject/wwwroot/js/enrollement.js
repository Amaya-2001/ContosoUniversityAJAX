$(document).ready(function () {

    var courseId = $('.course').val();
    console.log('course id: ', courseId);

    $(document).on('change', '.course', function () {
        console.log($(this).val());
    });

    $(document).on('click', '#btnUpdate', function (e) {
      

        var id = $('#EnrollmentID').val();
        console.log(id);
        var url = 'https://localhost:44309/Enrollments/Edit/' + id;
        var formData = $('#frmEnrollement').serialize();

        $.ajax({
            type: 'POST',
            url: url, // Replace 'ControllerName' with your actual controller name            
            data: formData,
            success: function (response) {
                console.log(response);
                if (response.success) {

                }

            }, error: function (error) {
                // Handle the error, e.g., display an error message.               
                console.error('Error:', error);
            }
        });       
    });

});