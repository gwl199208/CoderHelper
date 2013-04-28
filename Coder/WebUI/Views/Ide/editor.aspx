<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <link rel="stylesheet" href="../../CodeMirror/lib/CodeMirror.css" />
    <link rel="stylesheet" href="../../CodeMirror/theme/ambiance.css" />
    <link rel="stylesheet" href="../../CodeMirror/theme/solarized.css" />
    <link rel="stylesheet" href="../../CodeMirror/addon/dialog/dialog.css" />
    <link rel="stylesheet" href="../../Content/css/compile/ide.css" />
    <title>编辑器</title>

</head>
<body>
    <div id="lang">
        <span>语言(语法高亮)：</span>
        <select onchange="changeLang(this.value)">
            <option value="text/x-c++src">C/C++</option>
            <option value="text/x-java">Java</option>
            <option value="text/x-csharp">C#</option>
            <option value="php">PHP</option>
            <option value="ruby">Ruby</option>
            <option value="python">Python</option>
            <option value="perl">Perl</option>
            <option value="pascal">Pascal</option>
        </select>
        <button onclick="changeBack()" value="切换背景">切换背景</button>
        <button onclick="Upload()">提交代码</button>
        <button onclick="TEST()">测试</button>
    </div>

    <div class="outer">
        <div class="main">

            <form id="main_form">
                <textarea id="code" name="code"></textarea>
                <input id="language" name="lang" type="hidden" value="" />
            </form>
        </div>
        
        <div id="resultouter">
            <h4><span>编译及输出</span></h4>
            <div id="result">
                <div id="err"></div>
                <div id="out">.</div>
            </div>
        </div>

    </div>
    <script>
        function TEST() {
            var datas = $("pre");
            var data = "";
            for (var i = 1; i < datas.length; i++) {
                data += datas[i].innerText + "\r\n";
            }

            // var data = data.replace(/(\r\n){2,}/g, "\r\n");
            alert(data);
        }
    </script>
    <script type="text/javascript" src="../../Scripts/jquery-1.7.1.js"></script>
    <script type="text/javascript" src="../../js/compile/ide.js"></script>
    <script src="../../CodeMirror/lib/CodeMirror.js"></script>
    <script src="../../CodeMirror/addon/search/searchcursor.js"></script>
    <script src="../../CodeMirror/addon/search/match-highlighter.js"></script>
    <script src="../../CodeMirror/addon/mode/loadmode.js"></script>
    <script src="../../CodeMirror/addon/edit/matchbrackets.js"></script>
    <script src="../../CodeMirror/addon/fold/foldcode.js"></script>
    <script src="../../CodeMirror/addon/dialog/dialog.js"></script>
    <script src="../../CodeMirror/addon/search/searchcursor.js"></script>
    <script src="../../CodeMirror/addon/search/search.js"></script>
    <script src="../../CodeMirror/mode/clike/clike.js"></script>
</body>
</html>
