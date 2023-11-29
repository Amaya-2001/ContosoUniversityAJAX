//$(document).ready(function () {
//    console.log("loading the dashboard");

//    // Call the function when the document is ready
//    loaddashBoard();



//});

//function loaddashBoard() {
//    var url = 'https://localhost:7153/Users/DashBoard';
//    var jwtToken = localStorage.getItem("token");
    
//    var headers = { Authorization: `Bearer ${jwtToken}` };
   
//    $.ajax({
//        type: 'GET',
//        url: url,
//        dataType: 'html',
//        headers: headers,
//        success: function (data) {

//            $('#dashboard').html(data);

//        },
//        error: function (error) {
//            console.error('Error:', error);
//        }
//    });
//}    