$(function () {
    function userViewModel() {
        this.userName = ko.observable("");
        this.passWord = ko.observable("");

        // 点击登录按钮
        this.login = function () {
            $.post(
                    '/Home/DoLogin',
                    { "userName": this.userName(), "passWord": this.passWord() },
                    function (result) { alert(result) }
            );
        };
    }

    // 注册用户模型
    ko.applyBindings(new userViewModel());
});