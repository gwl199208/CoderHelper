$(function () {
    $.post("../SingleContest/showSCList", {}, function (Result) {
        if (Result == "") {
            alert(Result);
        }
        else {
            showSingleContestList(Result);
        }

    });

});

function showSingleContestList(list)
{
    var contestListHtml = "";

    /*
        分页
    */
    //////////////////
    /*
        当前页显示比赛场数
    */
    var curPageNum = list.length;

    for (var i = 0 ; i < curPageNum ; i++)
    {
        contestListHtml += 
        "<div class=\"math_list_question\">\
            <div class=\"math_list_ques_state01\">ING!!</div>\
            <div class=\"math_list_ques_view\">\
                <div class=\"math_list_ques_row01\">\
                    <div class=\"math_list_ques_cont\">eeee</div>\
                    <div class=\"math_list_ques_time\">2013/03/28--2013/05/03</div>\
                    <div class=\"math_list_ques_num\">24组</div>\
                    <div class=\"math_list_ques_btn\">\
                        <div class=\"math_list_ques_join\">+ 加入</div>\
                    </div>\
                </div>\
                <div class=\"math_list_ques_row02\">\
                    <div>aass</div>\
                    <div>dsfssdsdafas</div>\
                    <div>caca</div>\
                </div>\
            </div>\
           </div>" ;
    }
    $("#math_list_question").html(contestListHtml);
    
}