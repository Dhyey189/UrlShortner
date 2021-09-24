<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="UrlShortener.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
    <title>teeny | Shorten your url</title>
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
            <input id="url" type="text" />
            <asp:Button ID="Button1" runat="server" Text="Shorten" />
        </div>

    </form>
</body>

</html>
