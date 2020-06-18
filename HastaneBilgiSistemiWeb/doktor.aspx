<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="doktor.aspx.cs" Inherits="HastaneBilgiSistemiWeb.doktor" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        #form1 {
            height: 1234px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div style="height: 1027px; width: 831px;">
    
    &nbsp;<br />
        <asp:Label ID="Label3" runat="server" Text="HASTANE BİLGİ SİSTEMİ - DOKTOR MODÜLÜ"></asp:Label>
        <br />
        <br />
        <asp:Label ID="Label1" runat="server" Text="Kullanıcı Adı:"></asp:Label>
&nbsp;&nbsp;
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <br />
        <br />
        <asp:Label ID="Label2" runat="server" Text="Şifre :"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="TextBox2" runat="server" TextMode="Password"></asp:TextBox>
        <br />
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button1" runat="server" Height="38px" OnClick="Button1_Click" Text="GİRİŞ" Width="98px" />
        <br />
        <br />
        <asp:Panel ID="Panel1" runat="server" Enabled="False" Height="812px">
            <asp:GridView ID="GridView1" runat="server" Width="569px" style="margin-top: 0px">
            </asp:GridView>
            <br />
            <asp:ListBox ID="ListBox1" runat="server" Height="164px" Width="186px"></asp:ListBox>
            <br />
            <br />
            <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Seçili Hastaya tahlilleri yaz" Width="184px" />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="Seçili Hastaya Hastalıkları ata" Width="207px" />
            <br />
            <br />
            <asp:CheckBoxList ID="CheckBoxList1" runat="server" Height="67px" RepeatLayout="Flow" Width="183px">
            </asp:CheckBoxList>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:CheckBoxList ID="CheckBoxList2" runat="server" Height="67px" RepeatLayout="Flow" Width="183px">
            </asp:CheckBoxList>
            <br />
            <br />
            <br />
            <asp:ListBox ID="ListBox2" runat="server" Height="93px" Width="111px"></asp:ListBox>
&nbsp;
            <asp:Button ID="Button5" runat="server" Height="28px" OnClick="Button5_Click" Text="Seçili hastalığın ilaçlarını getir" Width="197px" />
            &nbsp;&nbsp;
            <asp:DropDownList ID="DropDownList1" runat="server" Height="17px" Width="85px">
            </asp:DropDownList>
            &nbsp;&nbsp; Doz miktarı (adet) :&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="TextBox3" runat="server" Width="33px"></asp:TextBox>
            &nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button6" runat="server" OnClick="Button6_Click" Text="Listeye Ekle" Width="118px" />
            <br />
            <br />
            <asp:ListBox ID="ListBox3" runat="server" Height="89px" Width="177px"></asp:ListBox>
            <asp:ListBox ID="ListBox4" runat="server" Height="89px" Width="158px"></asp:ListBox>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button4" runat="server" Height="49px" OnClick="Button4_Click" Text="Reçete Yaz" Width="204px" />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            &nbsp;&nbsp;&nbsp;
            <br />
            <br />
            <br />
            <br />
            <br />
        </asp:Panel>
        <br />
        <br />
        <br />
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />
        <br />
        <br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    
        <br />
        <br />
        <br />
    
        &nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;<br />
        <br />
        <br />
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <br />
        <br />
        <br />
        <br />
    
    </div>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    </form>
</body>
</html>
