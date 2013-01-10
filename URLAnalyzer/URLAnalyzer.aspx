<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="URLAnalyzer.aspx.cs" Inherits="URLAnalyzer.URLAnalyzer" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Label ID="lblUrl" runat="server" Text="Ingrese las URL a analizar"></asp:Label>
        <br />
        <asp:TextBox TextMode="MultiLine" Rows="20" Columns="120" runat="server" ID="txtUrl"></asp:TextBox>
        <br />
        <asp:Button id="btnAnalyzer" runat="server" Text="Analyze" OnClick="btnAnalyzer_Click" />
        <br />
        <asp:GridView ID="gvUrlTable" runat="server"></asp:GridView>
    </div>
    </form>
</body>
</html>
