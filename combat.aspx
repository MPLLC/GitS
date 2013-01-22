<%@ Page Language="C#" MasterPageFile="~/GitS.master" AutoEventWireup="true" CodeFile="combat.aspx.cs" Inherits="combat" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>

<asp:Content ContentPlaceHolderID="mainContentPane" ID="mainContent" runat="server">
    <div class="left" id="left" runat="server">
        Left-hand stuff
    </div>
    <div class="content" id="content" runat="server">
      <asp:ScriptManagerProxy ID="ScriptManagerProxy1" runat="server">
        </asp:ScriptManagerProxy>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
           <ContentTemplate>
                <div id="combatScreen" runat="server"></div>
                <div runat="server" id="attackGrid" Visible="false">
                    <asp:Button runat="server" ID="Button1" Visible="false" /><asp:Button runat="server" ID="Button2" Visible="false" /><asp:Button runat="server" ID="Button3" Visible="false" /><br />
                    <asp:Button runat="server" ID="Button4" Visible="false" /><asp:Button runat="server" ID="Button5" Visible="false" /><asp:Button runat="server" ID="Button6" Visible="false" /><br />
                    <asp:Button runat="server" ID="Button7" Visible="false" /><asp:Button runat="server" ID="Button8" Visible="false" /><asp:Button runat="server" ID="Button9" Visible="false" />
                </div>
           </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>