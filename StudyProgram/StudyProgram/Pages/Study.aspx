<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Study.aspx.cs" Inherits="StudyProgram.Pages.Study" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:DataGrid runat="server" ID="dataGrid" AutoGenerateColumns="False" AutoGenerateEditButton="true"
            ShowFooter="true" OnEditCommand="dataGrid_EditCommand" OnCancelCommand="dataGrid_CancelCommand"
            OnUpdateCommand="dataGrid_UpdateCommand">
            <%--AutoGenerateColumns自动生成列，否--%>
            <%--  ShowFooter 是否显示脚部--%>
            <Columns>
                <asp:TemplateColumn HeaderText="Id" Visible="false">
                    <ItemTemplate>
                        <asp:Label ID="lblId" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Id") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateColumn>
                <asp:TemplateColumn HeaderText="姓名">
                    <ItemTemplate>
                        <asp:Label ID="lblName" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Name") %>'> </asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtName" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Name") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <FooterTemplate>
                        <asp:TextBox ID="txtFootName" runat="server"></asp:TextBox>
                    </FooterTemplate>
                </asp:TemplateColumn>
                <asp:TemplateColumn HeaderText="性别">
                    <ItemTemplate>
                        <asp:Label ID="lblSex" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Sex") %>'> </asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtSex" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Sex") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <FooterTemplate>
                        <%--<asp:TextBox ID="txtFootSex" runat="server"></asp:TextBox>--%>
                        <asp:DropDownList ID="dropSex" runat="server">
                        <asp:ListItem Value="">请选择</asp:ListItem>
                         <asp:ListItem Value="男">男</asp:ListItem>
                          <asp:ListItem Value="女">女</asp:ListItem>
                        </asp:DropDownList>
                    </FooterTemplate>
                </asp:TemplateColumn>
                <asp:TemplateColumn HeaderText="年龄">
                    <ItemTemplate>
                        <asp:Label ID="lblAge" runat="server"><%# DataBinder.Eval(Container, "DataItem.Age")%></asp:Label>
                    </ItemTemplate>
                    <FooterTemplate>
                        <asp:TextBox ID="txtFootAge" runat="server"></asp:TextBox>
                    </FooterTemplate>
                </asp:TemplateColumn>
                <asp:TemplateColumn HeaderText="操作">
                    <ItemTemplate>
                        <asp:Button ID="btn_edit" runat="server" Text="修改" CommandName="Edit"></asp:Button>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:Button ID="btn_Save" runat="server" Text="保存" CommandName="Update"></asp:Button>
                        <asp:Button ID="btn_cancel" runat="server" Text="取消" CommandName="Cancel"></asp:Button>
                    </EditItemTemplate>
                    <FooterTemplate>
                        <asp:Button ID="btn_add" runat="server" Text="新增" CommandName="Update"></asp:Button>
                    </FooterTemplate>
                </asp:TemplateColumn>
            </Columns>
        </asp:DataGrid>
    </div>
    </form>
</body>
</html>
