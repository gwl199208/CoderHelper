<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <title>Login</title>
    <link rel="stylesheet" type="text/css" href="../../Content/css/login.css" />
</head>
<body>
    <div id="all">
    	<div id="banner_view">
        </div>
        
        <div id="login_view">
        	<div id="login_view_left">
            	<div><input type="text" id="username"/>
                </div>
                <div><input type="password" id="password" />
                </div>
                <div>
                	<div id="login_view_left_login_btn">登陆
                    </div>
                    <div id="login_view_left_register_btn">注册
                    </div>
                </div>
            </div>
            
            <div id="login_view_right">
            	<div id="login_view_right_question">题目
                </div>
                <div id="login_view_right_code">代码库
                </div>
                <div id="login_view_right_math">比赛
                </div>
                <div id="login_view_right_problem">问题区
                </div>
            </div>
        </div>
    </div>
    <script type="text/javascript" src="../../Scripts/jquery-1.7.1.js"></script>
    <script type="text/javascript" src="../../js/user.js"></script>
</body>
</html>
