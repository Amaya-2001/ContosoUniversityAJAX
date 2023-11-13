$(document).ready(function () {
    
    // Call the function when the document is ready
    getStudentDetails();
   
});
function getStudentDetails() {

    var id = $('#ID').val();
    console.log("id:", id);
    var url = 'https://localhost:7153/Students/GetStudentDetails/' + id;

    $.ajax({
        type: 'GET',
        url: url,
        dataType: 'html',
        success: function (data) {

            $('#studentDetailsContainer').html(data);
            console.log("Student details loaded successfully");
        },
        error: function (error) {
            console.error('Error:', error);
        }
    });
}


