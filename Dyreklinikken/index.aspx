<%@ Page Title="" Language="C#" MasterPageFile="~/DyreklinikLayout.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="Dyreklinikken.index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" type="text/css" href="Styles/GeneralStyles.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="PrimaryContent" runat="server">
    Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's 
    standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a
    type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining
    essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages,
    and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="SideContent" runat="server">
    <div id="LoginFormWrapper">
        <Header id="LoginHeader">
            Login her
        </Header>
        <Section id="LoginTxtFields">
            <asp:TextBox ID="BrugernavnTxt" Text="Brugernavn" runat="server"></asp:TextBox>
            <asp:TextBox ID="PasswordTxt" Text="Password" runat="server"></asp:TextBox>
        </Section>
        <Footer id="LoginFooter">
            <asp:Button ID="LoginBtn" Width="75px" runat="server" Text="Login" OnClick="LoginBtn_Click" />
        </Footer>
    </div>
    <asp:Label ID="loginErrorLabel" runat="server" Text="Label"></asp:Label>
</asp:Content>