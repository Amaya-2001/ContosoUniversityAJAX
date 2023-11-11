$(document).ready(function () {
    

    // Call the function when the document is ready
    loadStudentList();

    //$(document).on('click', '#btnCreate', function (e) {
    //    e.preventDefault();
    //    var url = 'https://localhost:7153/Students/Create';
    //    loadStudentForm(url, null); 
    //});


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