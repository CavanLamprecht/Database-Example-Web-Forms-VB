<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Default.aspx.vb" Inherits="Example._Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:DropDownList ID="ddlUsers" runat="server"></asp:DropDownList><br />
            <asp:Button ID="BtAge" runat="server" Text="Get Age" /><br />
            <asp:TextBox ID="txtAge" runat="server" ReadOnly="True"></asp:TextBox>
        </div>

        <div style="margin-top:200px; border:1px solid #808080; padding:30px">
            Name<asp:TextBox ID="txtSaveName" runat="server"></asp:TextBox>
            Surname<asp:TextBox ID="txtSaveSurname" runat="server"></asp:TextBox>
            Age<asp:TextBox ID="txtSaveAge" runat="server"></asp:TextBox><br />
            <asp:Button ID="btSave" runat="server" Text="Save" /><br />
            <asp:Label ID="lblSaveMessage" runat="server" Text="" Style="color:red;"></asp:Label>
        </div>

    </form>
</body>
</html>
