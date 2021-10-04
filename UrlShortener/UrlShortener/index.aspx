<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="UrlShortener.index" %>

<!DOCTYPE html>



<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
    <title>Teeny | Shorten your url</title>
    <link rel="stylesheet" href="css/style.css" />
</head>

<body>
    <form id="form1" runat="server">

        <header>
            <div class="container">
                <asp:HyperLink ID="HyperLink1" runat="server" class="sitename" NavigateUrl="~/index.aspx">Teeny
                </asp:HyperLink>
            </div>
        </header>

        <div id="url-area">
            <p>Enter your URL here to retrieve the shorten version</p>
            
            <asp:TextBox ID="Texturl" runat="server" OnTextChanged="Texturl_TextChanged"></asp:TextBox>
            <asp:Button ID="Button" runat="server" Text="Shorten" OnClick="Button_Click" />
            <asp:Label ID="Label1" runat="server" Text="Label1" ></asp:Label>
       
        </div>

    </form>
</body>

</html>
