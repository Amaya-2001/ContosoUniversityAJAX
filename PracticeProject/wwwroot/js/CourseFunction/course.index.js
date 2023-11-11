$(document).ready(function () {
    function loadCourseList() {
        var url = 'https://localhost:7153/Courses/Index';

        $.ajax({
            type: 'GET',
            url: url,
            dataType: 'html',
            success: function (data) {

                $('#courseTable tbody').replaceWith($(data).find('#courseTable tbody'));
            },
            error: function (error) {
                console.error('Error:', error);
            }
        });
    }

    // Call the function when the document is ready
    loadCourseList();
    $(document).on('click', '#btnCreate', function (e) {
        e.preventDefault();
        var url = 'https://localhost:7153/Courses/Create';
        loadCourseForm(url, null);
    });


});

