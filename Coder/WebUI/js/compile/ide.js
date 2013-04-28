var editor;
var hlLine;
var langg = "text/x-c++src";
$(document).ready(function () {

    $(document).keyup(function (event) {
        if (event.keyCode == 122) {
            setFullScreen(editor, !isFullScreen(editor));
        }
    });
    CodeMirror.modeURL = "CodeMirror/mode/%N/%N.js";
    CodeMirror.on(window, "resize", function () {
        var showing = $(".CodeMirror-fullscreen")[0];
        if (!showing) return;
        showing.CodeMirror.getWrapperElement().style.height = winHeight() + "px";
    });

    editor = CodeMirror.fromTextArea(document.getElementById("code"), {
        lineNumbers: true,
        matchBrackets: true,
        theme: "solarized",
        
        mode: "text/x-c++src",
        showCursorWhenSelecting: true, tabSize: 4,
        indentUnit: 4,
        indentWithTabs: true,
        gutters: ["CodeMirror-linenumbers", "breakpoints"],
        extraKeys: { "Ctrl-Q": function (cm) { foldFunc(cm, cm.getCursor().line); } }
    });

    hlLine = editor.addLineClass(0, "background", "activeline");
    editor.on("cursorActivity", function () {
        editor.matchHighlight("CodeMirror-matchhighlight");
        var cur = editor.getLineHandle(editor.getCursor().line);
        if (cur != hlLine) {
            editor.removeLineClass(hlLine, "background", "activeline");
            hlLine = editor.addLineClass(cur, "background", "activeline");
        }
    });


    var foldFunc = CodeMirror.newFoldFunction(CodeMirror.braceRangeFinder);
    editor.on("gutterClick", function (cm, n) {

        var info = cm.lineInfo(n);
        cm.setGutterMarker(n, "breakpoints", info.gutterMarkers ? null : makeMarker());

    });




});



function makeMarker() {
    var marker = document.createElement("div");
    marker.style.color = "#822";
    marker.innerHTML = "●";
    return marker;
}

function isFullScreen(cm) {
    return /\bCodeMirror-fullscreen\b/.test(cm.getWrapperElement().className);
}
function winHeight() {
    return window.innerHeight || (document.documentElement || document.body).clientHeight;
}
function setFullScreen(cm, full) {
    var wrap = cm.getWrapperElement();
    var top = document.getElementById("lang");
    var res = document.getElementById("resultouter");
    if (full) {
        wrap.className += " CodeMirror-fullscreen";
        wrap.style.height = winHeight() + "px";
        //top.className += " CodeMirror-fullscreen";
        //top.style.height = winHeight() + "px";
        top.style.display = "none";
        res.style.display = "none";
        document.documentElement.style.overflow = "hidden";
    } else {
        wrap.className = wrap.className.replace(" CodeMirror-fullscreen", "");
        wrap.style.height = "";
        // top.className = wrap.className.replace(" CodeMirror-fullscreen", "");
        //top.style.height = "";
        document.documentElement.style.overflow = "";
        top.style.display = "";
        res.style.display = "";
    }
    cm.refresh();
}


function changeLang(lang) {
    langg = lang;
    editor.setOption("mode", lang);
    CodeMirror.autoLoadMode(editor, lang);
}
var which = "solarized";


var GUID = "";

function changeBack() {
    if (which == "ambiance") {
        which = "solarized";
    } else {
        which = "ambiance";
    }
    editor.setOption("theme", which);

}

function readDataFromChildren(target) {
    var tmp = "";
    for (var i = 0; i < target.length; i++) {
        var lines = target[i].lines;
        for (var j = 0; j < lines.length; j++) {
            tmp += lines[j].text+"\r\n";
        }
    }
    return tmp;
}


function Upload(compile) {

    $("#lang").attr('disabled', true);
    var data = "";
    var node;
    var nodes = editor.view.doc.children;



    for (var j = 0; j < nodes.length; j++) {

        if (nodes[j].children != null) {
            data += readDataFromChildren(nodes[j].children);
        }

        else if (nodes[j].lines != null) {
            node = nodes[j].lines;
            for (var i = 0; i < node.length; i++) {
                data += node[i].text + "\r\n";
            }
        }


       
    }

    $("#code").val(data);
    $("#language").val(langg);
    var PostData = ($("#main_form").serialize());
    function openHTML(url) {
        //window.open(url, "", "toolbar=no,scrollbars=yes,width=600,height=400,left=12,top=30, menubar=no,status=no,resizable=yes");
    }
    
    $.ajax({
        type: "POST", url: "../Ide/compile", data: PostData,
        success: function (msg) {
            var retdata = msg;
            var retdatas = retdata.split('|');
            GUID = retdatas[0];
            if (GUID.indexOf("<") != -1) {

                GUID = GUID.substring(GUID.lastIndexOf(">") + 1);
            }
            var ext = retdatas[1];
            if (ext.indexOf("<") != -1) {
                ext = ext.substring(0, ext.lastIndexOf("<"));
                ext = ext.substring(0, ext.lastIndexOf("<"));
                ext = ext.substring(0, ext.lastIndexOf("<"));
            }
            
            
            $("#result").load("compile.aspx?GUID=" + GUID + "&ext=" + ext, function () {
                $("#lang").attr('disabled', false);
                
            });
        },
        error: function (msg) {
            alert(msg.responseText);
        }
    });
    //window.open("stdin.aspx?guid=" + GUID, "user_login", "width=428,height=296");
}