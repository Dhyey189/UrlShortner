<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="UrlShortener.index" %>

    <!DOCTYPE html>



    <html xmlns="http://www.w3.org/1999/xhtml">

    <head runat="server">
        <title>Teeny | Shorten your url</title>
        <link rel="stylesheet" href="~/css/style.css" runat="server" type="text/css" />
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

                <asp:TextBox ID="Texturl" runat="server" OnTextChanged="Texturl_TextChanged" class="url"
                    placeholder="Enter your url here"></asp:TextBox>
                <asp:Button ID="Button" runat="server" Text="Shorten" OnClick="Button_Click" class="btn" />
                <div class="result-area">
                    <asp:Label ID="Label1" runat="server" Text="" class="short-url"></asp:Label>
                    <asp:Button ID="Copy" class="copy btn" runat="server" Text="copy" OnClientClick="return copyUrl();"  />
                </div>
            </div>

        </form>

        <script>
            function copyUrl() {
                event.preventDefault();
                var copyText = document.getElementById("Label1");
                navigator.clipboard.writeText(copyText.innerText);
            }
        </script>
    </body>

    </html>