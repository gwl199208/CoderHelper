<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <title>Question</title>
    <link rel="stylesheet" type="text/css" href="../../Content/css/index.css" />
    <!-- js 请往后添加 -->
</head>
<body>
    <div id="all">
    	<div id="banner">
        	<div id="banner_logo"></div>
            
            <div id="banner_btn01">
            	<div id="banner_btn01_register">注册</div>
            	<div id="banner_btn01_login">登陆</div>
            </div>
            
            <div id="banner_btn02">
                <div id="banner_btn02_code">代码库
                </div>
                <div id="banner_btn02_oj">OJ
                </div>
                <div id="banner_btn02_search">
                	<input type="text" />
                </div>
            </div>
        </div>
        
        <div id="nav">
        	<div class="nav">
            	<a href="#">FAQ</a>
            </div>
            <div class="nav_fgx"></div>
            <div class="nav_selected">
            	<a href="#">排行榜</a>
            </div>
            <div class="nav_fgx"></div>
            <div class="nav">
            	<a href="#">比赛</a>
            </div>
            <div class="nav_fgx"></div>
            <div class="nav">
            	<a href="#">题目</a>
            </div>
            <div class="nav_fgx"></div>
            <div class="nav">
            	<a href="#">首页</a>
            </div>
        </div>
        
        <div id="main">
        	<div id="question_view">
            	<div id="question_tit">这里是题目内容，你觉得这是什么呢
                </div>
                <div id="question_info">
                	<span>时间:
                    	<span>2013/3/29-2013/5/23</span>
                    </span>
                    <span>已参与：
                    	<span>25人</span>
                    </span>
                    <span>已提交：
                    	<span>13人</span>
                    </span>
                </div>
                
                <div id="question_cont">呵呵呵呵呵，这里是题目内容，你觉得这是什么呢？</div>
                
                <div id="question_answer">
                	<div id="question_language">
                    	<input type="radio" />C#
                        <input type="radio" />JAVA
                        <input type="radio" />PHP
                        <input type="radio" />JSP
                        <input type="radio" />C++
                    </div>
                    <div id="question_input">
                    	<textarea id="question_input_cont"></textarea>
                    </div>
                </div>
                
                <div id="question_btn">
                	<div id="question_submit">提交</div>
                    <div id="question_reset">重做</div>
                </div>
            </div>
        </div>
    </div>
</body>
</html>
