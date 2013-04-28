<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <title>ContestList</title>
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
            <div class="nav">
            	<a href="#">排行榜</a>
            </div>
            <div class="nav_fgx"></div>
            <div class="nav_selected">
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
        	<div id="math_list_view">
            	<div id="math_list_nav">
                	<span>筛选：</span>
                    <span class="math_list_nav02" id="math_list_nav_all">全部</span>
                    <span class="math_list_nav" id="matn_list_nav_new">最新</span>
                    <span class="math_list_nav" id="math_list_nav_over">已参加</span>
                    <span class="math_list_nav" id="math_list_nav_notdo">未参加</span>
                    <span class="math_list_nav" id="math_list_nav_ing">正在进行</span>
                    <span class="math_list_nav" id="math_list_nav_wait">即将开始</span>
                    
                    <div id="math_list_orderby">
                    	<select>
                        	<option>默认顺序</option>
                            <option>时间</option>
                            <option>人数</option>
                            <option>随便</option>
                            <option>不知道</option>
                        </select>
                    </div>
                </div>
                
                
                <div id="math_list_question">
                	
                   
                                       
                </div>
            </div>
        </div>
    </div>
    <script type="text/javascript" src="../../Scripts/jquery-1.7.1.js"></script>
    <script type="text/javascript" src="../../js/contest/ContestList.js"></script>
</body>
</html>
