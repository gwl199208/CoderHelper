<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <title>Rank</title>
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
        	<div class="rank_column" id="rank_column01">
            	<div class="rank_column_tit">答题最多TOP10
                </div>
                <div class="rank_column_list">
                	<div class="rank_column_list_cont">
                    	<div class="rank_column_list_cont_num01">01</div>
                        <div class="rank_column_list_cont_name">大玉米大人</div>
                        <div class="rank_column_list_cont_num">999</div>
                    </div>
                    <div class="rank_column_list_cont">
                    	<div class="rank_column_list_cont_num02">04</div>
                        <div class="rank_column_list_cont_name">大玉米大人</div>
                        <div class="rank_column_list_cont_num">119</div>
                    </div>
                </div>
            </div>
            <div class="rank_column" id="rank_column02">
            	<div class="rank_column_tit">答题最多TOP10
                </div>
                <div class="rank_column_list">
                	<div class="rank_column_list_cont">
                    	<div class="rank_column_list_cont_num01">01</div>
                        <div class="rank_column_list_cont_name">大玉米大人</div>
                        <div class="rank_column_list_cont_num">999</div>
                    </div>
                    <div class="rank_column_list_cont">
                    	<div class="rank_column_list_cont_num02">04</div>
                        <div class="rank_column_list_cont_name">大玉米大人</div>
                        <div class="rank_column_list_cont_num">119</div>
                    </div>
                </div>
            </div>
            <div class="rank_column" id="rank_column03">
            	<div class="rank_column_tit">答题最多TOP10
                </div>
                <div class="rank_column_list">
                	<div class="rank_column_list_cont">
                    	<div class="rank_column_list_cont_num01">01</div>
                        <div class="rank_column_list_cont_name">大玉米大人</div>
                        <div class="rank_column_list_cont_num">999</div>
                    </div>
                    <div class="rank_column_list_cont">
                    	<div class="rank_column_list_cont_num02">04</div>
                        <div class="rank_column_list_cont_name">大玉米大人</div>
                        <div class="rank_column_list_cont_num">119</div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</body>
</html>
