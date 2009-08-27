﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ConsultaRemota._Default" %>

<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<%@ Register Assembly="Korzh.EasyQuery.WebControls.CLR20" Namespace="Korzh.EasyQuery.WebControls"
    TagPrefix="keqwc" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta name="vs_snapToGrid" content="True" />
    <title>Consulta remota.</title>
    <meta content="C#" name="CODE_LANGUAGE" />
    <meta content="JavaScript" name="vs_defaultClientScript" />
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema" />
    <link href="Estilos.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        A:link
        {
            color: #006699;
        }
        A:active
        {
            color: #FF0000;
        }
        A:visited
        {
            color: #006699;
        }
    </style>
</head>
<body>
    <form id="Form1" method="post" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" />
    <table border="0" width="100%" id="table1" cellspacing="0" cellpadding="5">
        <tbody>
            <tr>
                <td style="background-color: #F0F0F0;">
                    <div class="header">
                        <table border="0" width="100%" cellspacing="0" cellpadding="0">
                            <tbody>
                                <tr>
                                    <td>
                                        <img style="border: 0" src="imagenes/logo_ico.jpg" alt="title" />
                                    </td>
                                    <td style="width: 100%">
                                        <table cellspacing="0" cellpadding="0" style="width: 100%; border: 0">
                                            <tr>
                                                <td>
                                                    <div class="title0">
                                                        <asp:Literal ID="txtTitle" runat="server" Text="<%$ Resources:txtTitle%>" />
                                                    </div>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="text-align: left; height: 18px;">
                                                    <div class="subTitle">
                                                        <asp:Literal ID="txtSubTitle" runat="server" Text="<%$ Resources:txtSubTitle%>" />
                                                    </div>
                                                </td>
                                                <td style="text-align: right; height: 18px;">
                                                    <asp:Label ID="LabelVersion" runat="server" Font-Names="Verdana,Arial" Font-Size="Smaller"></asp:Label>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                    </div>
                </td>
            </tr>
        </tbody>
    </table>
    <asp:Label ID="ErrorLabel" runat="server" Text="______" Font-Bold="True" ForeColor="Red"
        Visible="False"></asp:Label>
    <table border="0" cellpadding="0" cellspacing="5" width="100%" id="table17">
        <tbody>
            <tr>
                <td valign="top" style="width: 65%">
                    <table border="0" cellpadding="0" cellspacing="0" width="100%" id="table18">
                        <tbody>
                            <tr>
                                <td style="background-color: #4B9EDC">
                                    <table style="border: 0; width: 100%" cellspacing="0" cellpadding="0">
                                        <tr>
                                            <td class="title1">
                                                <asp:Literal ID="txtQueryDef" runat="server" Text="<%$ Resources:txtQueryDef%>" />
                                            </td>
                                            <td style="background-color: #FFFFFF; text-align: right; vertical-align: top">
                                                <asp:UpdateProgress ID="UpdateProgressColumns" runat="server" AssociatedUpdatePanelID="UpdatePanelColumns">
                                                    <ProgressTemplate>
                                                        <span style="font-weight: bold; font-size: 14px">Procesando... </span>
                                                        <img src="imagenes/progressBar2.gif" alt="Progress Bar" />
                                                    </ProgressTemplate>
                                                </asp:UpdateProgress>
                                                <asp:UpdateProgress ID="UpdateProgressConditions" runat="server" AssociatedUpdatePanelID="UpdatePanelConditions">
                                                    <ProgressTemplate>
                                                        <span style="font-weight: bold; font-size: 14px">Procesando... </span>
                                                        <img src="imagenes/progressBar2.gif" alt="Progress Bar" />
                                                    </ProgressTemplate>
                                                </asp:UpdateProgress>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td style="background-color: #FFFFFF; border: solid 4px #4B9EDC; height: 383px;"
                                    class="back_blue">
                                    <table border="0" width="100%" id="table19" cellspacing="0" cellpadding="0">
                                        <tbody>
                                            <tr>
                                                <td valign="top" style="width: 50%; height: 40px">
                                                    <asp:UpdatePanel ID="UpdatePanelColumns" runat="server">
                                                        <ContentTemplate>
                                                            <table border="0" cellpadding="2" cellspacing="2" width="100%">
                                                                <tr>
                                                                    <td>
                                                                        <div class="title2">
                                                                            <asp:Literal ID="txtResultColumns" runat="server" Text="<%$ Resources:txtResultColumns%>" />
                                                                        </div>
                                                                        <keqwc:QueryColumnsPanel ID="QueryColumnsPanel1" runat="server" Height="150px" Width="100%"
                                                                            BorderStyle="Solid" ShowHeaders="True" CssClass="bodytext" ToolTip="Result Columns">
                                                                        </keqwc:QueryColumnsPanel>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                    <table border="0" width="100%" id="table22" cellspacing="2" cellpadding="2">
                                        <tbody>
                                            <tr>
                                                <td>
                                                    <table style="border: 0; width: 100%" cellspacing="0" cellpadding="0">
                                                        <tr>
                                                            <td class="title2">
                                                                <asp:Literal ID="txtQueryConditions" runat="server" Text="<%$ Resources:txtQueryConditions%>" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                    <asp:UpdatePanel ID="UpdatePanelConditions" runat="server">
                                                        <ContentTemplate>
                                                            <keqwc:QueryPanel ID="QueryPanel1" runat="server" Height="160px" Width="100%" BorderWidth="1px"
                                                                ScrollBars="Auto" CssClass="bodytext" 
                                                                Appearance-ScriptMenuStyle-ItemMinWidth="160"
                                                                Appearance-ScriptMenuStyle-BackColor="#FFE0C0" UseListCache="True">
                                                            </keqwc:QueryPanel>
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                    &nbsp;
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </td>
            </tr>
            <tr>
                <td valign="top">
                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                        <ContentTemplate>
                            <table border="0" cellpadding="0" cellspacing="0" width="100%" id="table29">
                                <tbody>
                                    <tr>
                                        <td>
                                            <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                                <tr>
                                                    <td style="background-color: #00c62c; width: 160px; height: 22px;">
                                                        <div class="title1">
                                                            <asp:Literal ID="txtResult" runat="server" Text="<%$ Resources:txtResult%>" />
                                                        </div>
                                                    </td>
                                                    <td style="height: 22px">
                                                        <asp:Button ID="btnExportExcel" runat="server" OnClick="ExportExcelBtn_Click" Text="Export to Excel"
                                                            Width="112px" Height="20px" CssClass="btn" meta:resourcekey="btnExportExcel" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="background-color: #FFFFFF; border: solid 4px #00c62c; width: 186px;" class="back_blue">
                                            <table border="0" width="100%" id="table30" cellspacing="0" cellpadding="0">
                                                <tbody>
                                                    <tr>
                                                        <td valign="top">
                                                            <asp:Label ID="ResultLabel" runat="server" Text="Label" Visible="False" Font-Bold="True"
                                                                ForeColor="Maroon" Height="4px" Width="15px"></asp:Label>
                                                            <asp:Panel ID="PanelResult" runat="server" Height="200px" Width="100%" ScrollBars="Auto">
                                                                <asp:GridView ID="ResultGrid" runat="server" DataSourceID="ResultDS" Font-Size="XX-Small"
                                                                    ForeColor="Black" CellPadding="4" GridLines="Vertical" BackColor="White" BorderColor="#DEDFDE"
                                                                    BorderStyle="None" BorderWidth="1px">
                                                                    <RowStyle Font-Size="XX-Small" BackColor="#F7F7DE" />
                                                                    <HeaderStyle Font-Size="X-Small" BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
                                                                    <FooterStyle BackColor="#CCCC99" />
                                                                    <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
                                                                    <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                                                                    <AlternatingRowStyle BackColor="White" />
                                                                </asp:GridView>
                                                            </asp:Panel>
                                                        </td>
                                                    </tr>
                                                </tbody>
                                            </table>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </ContentTemplate>
                        <Triggers>
                            <asp:PostBackTrigger ControlID="btnExportExcel" />
                        </Triggers>
                    </asp:UpdatePanel>
                </td>
            </tr>
        </tbody>
    </table>
    <div style="text-align: center; padding: 10 0 30 0;">
        &nbsp;© Copyright 2009. <a href="http://www.bsd.com" target="_blank">BSD.com</a></div>
    <%--<asp:AccessDataSource ID="ResultDS" runat="server" >
    </asp:AccessDataSource>--%>
    <asp:SqlDataSource ID="ResultDS" runat="server" ConnectionString="Data Source=.\SQLEXPRESS;Integrated Security=SSPI; Initial Catalog=SAI_BD" />
    &nbsp; &nbsp;
    </form>
</body>
</html>
