<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Eczane.aspx.cs" Inherits="HastaneBilgiSistemiWeb.Eczane" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div style="height: 997px">
    
        <br />
        <asp:Label ID="Label3" runat="server" Text="HASTANE BİLGİ SİSTEMİ - ECZANE MODÜLÜ"></asp:Label>
        <br />
        <br />
        <asp:Label ID="Label1" runat="server" Text="Kullanıcı Adı:"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
&nbsp;<br />
        <br />
        <asp:Label ID="Label2" runat="server" Text="Şifre :"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="TextBox2" runat="server" TextMode="Password"></asp:TextBox>
        <br />
&nbsp;<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button1" runat="server" Height="38px" OnClick="Button1_Click" Text="GİRİŞ" Width="98px" />
        <br />
        <br />
        <asp:Panel ID="Panel1" runat="server" Enabled="False" Height="660px">
            <br />
            &nbsp; Hasta TC :&nbsp;&nbsp;
            <asp:TextBox ID="TextBox3" runat="server" Font-Size="13pt" Height="25px" MaxLength="11" Width="119px"></asp:TextBox>
            &nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Hastaya Ait Reçeteleri getir" Width="206px" />
            <br />
            <br />
            <br />
&nbsp;
            <asp:ListBox ID="ListBox1" runat="server" Height="79px" Width="192px"></asp:ListBox>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button3" runat="server" Height="42px" OnClick="Button3_Click" Text="Seçili Tarihdeki Reçeteyi Göster" Width="199px" />
            <br />
        </asp:Panel>
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
    
    </div>
    </form>
</body>
</html>
