$(document).ready(function () {
    console.log("hi");
    function getStudentDetails() {

        var id = $('#StudentID').val();
        console.log("id:", id);
        var url = 'https://localhost:7153/Students/Details/' + id;

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

    // Call the function when the document is ready
    getStudentDetails();
    $(document).on('click', '#btnEdit', function (e) {
        e.preventDefault();
        var id = $('#StudentID').val();
        var url = 'https://localhost:7153/Students/Edit/' + id;
        window.location.href = url;
    });

});

