<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Employee.aspx.cs" Inherits="EmployeeManagement.Employee" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table>
                <tr>
                    <td>
                        Name
                    </td>
                    <td>
                        <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        Salary
                    </td>
                    <td>
                        <asp:TextBox ID="txtSalary" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        Designation
                    </td>
                    <td>
                        <asp:TextBox ID="txtDesignation" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:Button ID="Update" runat="server" Text="Save" OnClick="Update_Click" />
                        <asp:Label ID="lblStatus" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
            </table>
            <br />
            
            <br />

            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating" ShowFooter ="true">
    <Columns>
        <asp:BoundField DataField="EmployeeId" HeaderText="Employee ID" />
        <asp:BoundField DataField="EmployeeName" HeaderText="Employee Name" />
        <asp:BoundField DataField="Salary" HeaderText="Salary" />
        <asp:BoundField DataField="Designation" HeaderText="Designation" />
        <asp:CommandField ShowEditButton="True" />
    </Columns>
</asp:GridView>
        </div>
    </form>
</body>
</html>
