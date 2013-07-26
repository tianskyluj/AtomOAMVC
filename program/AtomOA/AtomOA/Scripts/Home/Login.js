$(function () {
    function userViewModel() {
        this.userName = ko.observable("");
        this.passWord = ko.observable("");

        // 点击登录按钮
        this.login = function () {
            $.ajax({
                url: '/Home/DoLogin', 
                data: ko.toJSON({ userName: this.userName(),passWord:this.passWord() }),
                type: "post", contentType: "application/json",
                success: function (result) { alert(result) },
                error: function (error) { alert("调用出错" + error.responseText); }
            });
        };
    }

    // 注册用户模型
    ko.applyBindings(new userViewModel());
});