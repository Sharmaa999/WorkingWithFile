// AddEmployee.aspx.cs

using System;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Web.UI;

namespace WebApplication5
{
    public partial class AddEmployee : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                
                if (string.IsNullOrEmpty(txtName.Text) || string.IsNullOrEmpty(txtCompany.Text) || string.IsNullOrEmpty(txtPosition.Text) || string.IsNullOrEmpty(txtEmail.Text))
                {
                    
                    ScriptManager.RegisterClientScriptBlock(this, GetType(), "alertMessage", "alert('Please fill in all the required fields.')", true);
                    return; 
                }

                string connectionString = "Data Source=MUM-LAP-700373\\SQLEXPRESS01;Initial Catalog=P1;Integrated Security=True";

                
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string insertQuery = "INSERT INTO Employee (Name, Company, Position, Email) VALUES (@Name, @Company, @Position, @Email)";
                    using (SqlCommand command = new SqlCommand(insertQuery, connection))
                    {
                        command.Parameters.AddWithValue("@Name", txtName.Text);
                        command.Parameters.AddWithValue("@Company", txtCompany.Text);
                        command.Parameters.AddWithValue("@Position", txtPosition.Text);
                        command.Parameters.AddWithValue("@Email", txtEmail.Text);

                        command.ExecuteNonQuery();
                    }
                }

                
                string localFilePath = @"C:\Files\EmployeeDetails.txt";
                using (StreamWriter writer = new StreamWriter(localFilePath, true))
                {
                    writer.WriteLine($"Name: {txtName.Text}");
                    writer.WriteLine($"Company: {txtCompany.Text}");
                    writer.WriteLine($"Position: {txtPosition.Text}");
                    writer.WriteLine($"Email: {txtEmail.Text}");
                    writer.WriteLine("====================================");
                }

                
                ScriptManager.RegisterClientScriptBlock(this, GetType(), "alertMessage", "alert('Employee details saved successfully!')", true);
            }
            catch (Exception ex)
            {
                
                ScriptManager.RegisterClientScriptBlock(this, GetType(), "alertMessage", $"alert('Error: {ex.Message}')", true);
            }
        }

        protected void btnread_Click(object sender, EventArgs e)
        {
            Response.Redirect("ReadEmployee.aspx");
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            Response.Redirect("EditEmployee.aspx");
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            Response.Redirect("DeleteEmployee.aspx");
        }
    }
}
