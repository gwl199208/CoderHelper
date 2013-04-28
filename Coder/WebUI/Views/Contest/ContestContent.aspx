<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <title>ContestContent</title>
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
            	<div id="question_tit">这种奇葩的问题我怎么知道是什么啊？
                	<div id="math_btn">√ 已参加
                    </div>
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
                
                <div id="question_cont">
                	<div>呵呵呵呵呵，这里是题目内容，你觉得这是什么呢？</div>
                    
                    <div id="math_introduce">
                		<div class="math_introduce">问题1：
                    		<span>这种奇葩的问题我怎么知道是什么啊？题目呢？说好的题目呢？说好的妹纸呢？说好的请吃饭呢？坑爹啊！</span>
                    	</div>
                    	<div class="math_introduce">问题2：
                    		<span>这种奇葩的问题我怎么知道是什么啊？题目呢？说好的题目呢？说好的妹纸呢？说好的请吃饭呢？坑爹啊！</span>
                    	</div>
                    	<div class="math_introduce">问题3：
                    		<span>这种奇葩的问题我怎么知道是什么啊？题目呢？说好的题目呢？说好的妹纸呢？说好的请吃饭呢？坑爹啊！</span>
                    	</div>
                    	<div class="math_introduce">问题4：
                    		<span>这种奇葩的问题我怎么知道是什么啊？题目呢？说好的题目呢？说好的妹纸呢？说好的请吃饭呢？坑爹啊！</span>
                    	</div>
                	</div>
                    
                </div>
                
                
                
                <div id="math_introduce_question">
                	<div>问题1：
                    	<span>这种奇葩的问题我怎么知道是什么啊？题目呢？说好的题目呢？说好的妹纸呢？说好的请吃饭呢？坑爹啊！</span>
                    </div>
                    <div id="math_introduce_question_command">要求:
                    	<div>内容不限，题材不限，风格不限，字数不限，时间不限，语言不限，内容积极向上，发自肺腑。爱怎么写就怎么写。</div>
                    </div>
                </div>
                
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
                    <div id="question_back">返回题目表</div>
                </div>
            </div>
        </div>
    </div>
</body>
</html>
