<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="CPGR214Lab3.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="styling/style.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Incident Report</h1>
            <h2>Select Technician:</h2><br />

            <asp:DropDownList ID="ddlTechnicians" class="ddl" runat="server" AutoPostBack="True" DataSourceID="ObjectDataSource1" DataTextField="Name" DataValueField="TechID">
            </asp:DropDownList>
            <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetAllTechnicians" TypeName="CPGR214Lab3.App_Code.TechnicianDB"></asp:ObjectDataSource>
            <br /><br /><br />

            <h2>Open Incidents for Selected Technician:</h2><br />
            <asp:GridView ID="gvIncidents" class="gv" runat="server" AutoGenerateColumns="False" DataSourceID="ObjectDataSource2">
                <Columns>
                    <asp:BoundField DataField="IncidentID" HeaderText="Incident ID" SortExpression="IncidentID" />
                    <asp:BoundField DataField="Name" HeaderText="Customer Name" SortExpression="Name" />
                    <asp:BoundField DataField="ProductCode" HeaderText="Product Code" SortExpression="ProductCode" />
                    <asp:BoundField DataField="DateOpened" HeaderText="Date Opened" SortExpression="DateOpened" DataFormatString="{0:d}" />
                    <asp:BoundField DataField="DateClosed" HeaderText="Date Closed" SortExpression="DateClosed" DataFormatString="{0:d}" />
                    <asp:BoundField DataField="Title" HeaderText="Title" SortExpression="Title" />
                    <asp:BoundField DataField="Description" HeaderText="Description" SortExpression="Description" />
                </Columns>
            </asp:GridView>
            <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetOpenTechIncidents" TypeName="CPGR214Lab3.App_Code.IncidentDB">
                <SelectParameters>
                    <asp:ControlParameter ControlID="ddlTechnicians" Name="techID" PropertyName="SelectedValue" Type="Int32" />
                </SelectParameters>
            </asp:ObjectDataSource>
        </div>
    </form>
</body>
</html>
