
using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using System.Web.UI;

namespace WebApplication5
{
    public partial class EditEmployee : System.Web.UI.Page
    {
        private readonly string connectionString = "Data Source=MUM-LAP-700373\\SQLEXPRESS01;Initial Catalog=P1;Integrated Security=True";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGrid();
            }
        }

        private void BindGrid()
        {
            try
            {
                DataTable dataTable = GetEmployees();
                GridView1.DataSource = dataTable;
                GridView1.DataBind();
            }
            catch (Exception ex)
            {
                ShowErrorMessage("Error retrieving employee data. " + ex.Message);
            }
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            BindGrid();
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                int employeeId = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value);

                TextBox txtEditName = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtEditName");
                TextBox txtEditCompany = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtEditCompany");
                TextBox txtEditPosition = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtEditPosition");
                TextBox txtEditEmail = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtEditEmail");

                
                if (txtEditName == null)
                {
                    txtEditName = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtEditName");
                }
                if (txtEditCompany == null)
                {
                    txtEditCompany = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtEditCompany");
                }
                if (txtEditPosition == null)
                {
                    txtEditPosition = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtEditPosition");
                }
                if (txtEditEmail == null)
                {
                    txtEditEmail = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtEditEmail");
                }

                if (txtEditName != null && txtEditCompany != null && txtEditPosition != null && txtEditEmail != null)
                {
                    string name = txtEditName.Text;
                    string company = txtEditCompany.Text;
                    string position = txtEditPosition.Text;
                    string email = txtEditEmail.Text;

                    UpdateEmployee(employeeId, name, company, position, email);

                    GridView1.EditIndex = -1;
                    BindGrid(); 
                    ShowSuccessMessage("Employee updated successfully!");
                }
                else
                {
                    ShowErrorMessage("One or more textboxes not found in GridView row.");
                }
            }
            catch (Exception ex)
            {
                ShowErrorMessage("Error updating employee. " + ex.Message);
            }
        }


        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            BindGrid();
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                int employeeId = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value);

                
                DeleteEmployee(employeeId);

                BindGrid();

                ShowSuccessMessage("Employee deleted successfully!");
            }
            catch (Exception ex)
            {
                ShowErrorMessage("Error deleting employee. " + ex.Message);
            }
        }

        private DataTable GetEmployees()
        {
            DataTable dataTable = new DataTable();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT EmployeeId, Name, Company, Position, Email FROM Employee";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(dataTable);
                    }
                }
            }

            return dataTable;
        }

        private void UpdateEmployee(int employeeId, string name, string company, string position, string email)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "UPDATE Employee SET Name = @Name, Company = @Company, Position = @Position, Email = @Email WHERE EmployeeId = @EmployeeId";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@EmployeeId", employeeId);
                        command.Parameters.AddWithValue("@Name", name);
                        command.Parameters.AddWithValue("@Company", company);
                        command.Parameters.AddWithValue("@Position", position);
                        command.Parameters.AddWithValue("@Email", email);

                        command.ExecuteNonQuery();
                    }
                }

                
            }
            catch (Exception ex)
            {
                ShowErrorMessage("Error updating employee. " + ex.Message);
            }
        }



        private void DeleteEmployee(int employeeId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "DELETE FROM Employee WHERE EmployeeId = @EmployeeId";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@EmployeeId", employeeId);

                    command.ExecuteNonQuery();
                }
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            // Redirect to the DeleteEmployee.aspx page
            Response.Redirect("DeleteEmployee.aspx");
        }

        private void ShowSuccessMessage(string message)
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "showSuccess", $"alert('{message}');", true);
        }

        private void ShowErrorMessage(string message)
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "showError", $"alert('{message}');", true);
        }
    }
}
