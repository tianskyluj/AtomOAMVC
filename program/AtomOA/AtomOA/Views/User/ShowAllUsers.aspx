
<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    ShowAllUsers
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>ShowAllUsers</h2>
    <table>
            <tr>
                <td>用户名</td><td>密码</td>
            </tr>
            
        <%IList<AtomOA.Model.SystemUser> userList = ViewData["Users"] as List<AtomOA.Model.SystemUser>; %>
        <%for (int i = 0; i < userList.Count; i++) %>
        <%{  %>
            <tr>
            <td> <%=userList[i].Name%></td>   
            <td><%=userList[i].PassWord %></td>
            </tr>
        <%} %>
        </table>

</asp:Content>
