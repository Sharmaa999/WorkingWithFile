<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ReadEmployee.aspx.cs" Inherits="WebApplication5.ReadEmployee" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Read Employee</title>
    
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
            width: 80%;
            margin: auto;
        }

        /* GridView Styles */
        #GridView1 {
            margin-top: 20px;
            border-collapse: collapse;
            width: 100%;
        }

        #GridView1 th, #GridView1 td {
            border: 1px solid #ddd;
            padding: 8px;
            text-align: left;
        }

        #GridView1 th {
            background-color: #2196f3;
            color: white;
        }

        #GridView1 tr:nth-child(even) {
            background-color: #f2f2f2;
        }

        #GridView1 tr:hover {
            background-color: #ddd;
        }

         #Buttonback {
    background-color: #e74c3c; /* Red */
    color: #fff; /* White */
    padding: 8px;
    text-decoration: none;
    display: inline-block;
    border-radius: 5px;
    margin-right: 5px;
}

#Buttonback:hover {
    background-color: #c0392b; /* Darker Red on Hover */
}
    </style>
</head>
<body>
    <form runat="server">
        <div>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="EmployeeId">
                <Columns>
                    <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
                    <asp:BoundField DataField="Company" HeaderText="Company" SortExpression="Company" />
                    <asp:BoundField DataField="Position" HeaderText="Position" SortExpression="Position" />
                    <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email" />
                </Columns>
            </asp:GridView>
         <asp:Button ID="Buttonback" runat="server" Text="Back" OnClick="btnBack_Click" />
      
        </div>
    </form>
</body>
</html>
