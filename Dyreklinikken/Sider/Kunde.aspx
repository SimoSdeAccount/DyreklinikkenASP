<%@ Page Title="" Language="C#" MasterPageFile="~/LoggedIn.master" AutoEventWireup="true" CodeBehind="Kunde.aspx.cs" Inherits="Dyreklinikken.Kunde" %>
<asp:Content ID="Content2" ContentPlaceHolderID="pageSpecificStyles" runat="server">
    <style>
        #KundeInputContent {
            text-align:center;
            background-color:aquamarine;
            width:40%;
            float:left;
        }
        #KundeListContent {
            display:flex;
            justify-content:center;
            background-color:aqua;
            width:60%;
            float:left;
        }
        #VaelgSubmit {
            display:flex;
            justify-content:center;
        }
        #formHeader {
            font-size:30px;
            margin:auto;
        }
        #formTable {
            margin:auto;
            width:75%;
            text-align:center;
        }
        .formFields {
            width:50%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="LoggedInPrimaryContent" runat="server">
    <div id="LoggedInContentWrapper">
        <div id="KundeInputContent">
            <h1 id="formHeader">Form</h1>
            <div id="VaelgSubmit">
                <asp:RadioButtonList ID="SubmitList" runat="server" AutoPostBack="True" OnSelectedIndexChanged="SubmitList_SelectedIndexChanged" RepeatDirection="Horizontal">
                    <asp:ListItem>Opret</asp:ListItem>
                    <asp:ListItem>Rediger</asp:ListItem>
                    <asp:ListItem>Slet</asp:ListItem>
                </asp:RadioButtonList>
            </div>
             <table id="formTable">
                <tr>
                    <td>
                        <asp:TextBox ID="navnTxt" class="formFields" Visible="false" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox ID="alderTxt" class="formFields" Visible="false" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox ID="vejTxt" class="formFields" Visible="false" runat="server"></asp:TextBox>
                    </td>
                </tr>
                 <tr>
                    <td>
                        <asp:TextBox ID="telefonTxt" class="formFields" Visible="false" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox ID="emailTxt" class="formFields" Visible="false" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:DropDownList ID="Postnumre" class="formFields" Visible="false" runat="server">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="opretBtn" class="formFields" runat="server" Text="Opret" OnClick="opretBtn_Click" Visible="false" />
                        <asp:Button ID="OpdaterBtn" class="formFields" runat="server" Text="Opdater" OnClick="opdaterBtn_Click" Visible="false" />
                        <asp:Button ID="SletBtn" class="formFields" runat="server" Text="Slet" OnClick="sletBtn_Click" Visible="false" />
                    </td>
                </tr>
            </table>
        </div>
        <div id="KundeListContent">
            <asp:GridView ID="Kundeliste" runat="server" AutoGenerateSelectButton="true" OnSelectedIndexChanged="Kundeliste_SelectedIndexChanged" Visible="false">
            </asp:GridView>
        </div>
        
        <br />
    </div>
</asp:Content>
