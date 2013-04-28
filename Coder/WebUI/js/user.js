$(function () {
    $("#login_view_left_login_btn").click(function () { login($("#username").val(), $("#password").val()); });
});

function login(name, password) {
    /*$.post("User/login", { 'username': name, 'password': password }, function (Result) {
        if (Result == "null") {
            alert("no user");
        }
        else {
            alert(Result.Uid);
        }
        
    });*/
}