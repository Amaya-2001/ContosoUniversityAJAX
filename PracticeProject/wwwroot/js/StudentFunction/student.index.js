$(document).ready(function () {
    

    // Call the function when the document is ready
    loadStudentList();
    


});

function loadStudentList() {
    var url = 'https://localhost:7153/Students/GetStudentList';

    $.ajax({
        type: 'GET',
        url: url,
        dataType: 'html',
        success: function (data) {

            $('#studentList').html(data);
            
        },
        error: function (error) {
            console.error('Error:', error);
        }
    });
}    