<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddEmployee.aspx.cs" Inherits="WebApplication5.AddEmployee" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Add Employee</title>
    
    <style>
        body {
            font-family: Arial, sans-serif;
            background-color: #f4f4f4;
            margin: 20px;
        }

        form {
            background-color: #fff;
            padding: 20px;
            border-radius: 5px;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
            width: 300px;
            margin: auto;
        }

        label {
            display: block;
            margin-bottom: 5px;
            font-weight: bold;
        }

        input[type="text"] {
            width: 100%;
            padding: 8px;
            margin-bottom: 10px;
            box-sizing: border-box;
        }

        button {
            background-color: #3498db;
            color: #fff;
            padding: 10px;
            border: none;
            border-radius: 5px;
            cursor: pointer;
            margin-right: 5px;
        }

        button:hover {
            background-color: #45a049;
        }

        #btnSave {
            background-color: #2ecc71;
        }

        #ButtonRead {
            background-color: #e74c3c;
        }

        #ButtonEdit {
            background-color: #f39c12;
        }
    </style>
</head>
<body>
    <form runat="server">
        <div>
            <label>Name:</label>
            <asp:TextBox ID="txtName" runat="server"></asp:TextBox><br />
            <label>Company:</label>
            <asp:TextBox ID="txtCompany" runat="server"></asp:TextBox><br />
            <label>Position:</label>
            <asp:TextBox ID="txtPosition" runat="server"></asp:TextBox><br />
            <label>Email:</label>
            <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox><br />
            <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" />
            <asp:Button ID="ButtonRead" runat="server" Text="Read" OnClick="btnread_Click" />
            <asp:Button ID="ButtonEdit" runat="server" Text="Edit" OnClick="btnEdit_Click" />
        </div>
    </form>
</body>
</html>
