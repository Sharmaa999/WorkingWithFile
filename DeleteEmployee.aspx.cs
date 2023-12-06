// DeleteEmployee.aspx.cs

using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace WebApplication5
{
    public partial class DeleteEmployee : System.Web.UI.Page
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

            GridView1.DataSource = dataTable;
            GridView1.DataBind();
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                int employeeId = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value);

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string deleteQuery = "DELETE FROM Employee WHERE EmployeeId = @EmployeeId";
                    using (SqlCommand deleteCommand = new SqlCommand(deleteQuery, connection))
                    {
                        deleteCommand.Parameters.AddWithValue("@EmployeeId", employeeId);
                        deleteCommand.ExecuteNonQuery();
                    }
                }

                BindGrid();

                // Show success message
                ClientScript.RegisterStartupScript(GetType(), "alertMessage", "alert('Employee deleted successfully!');", true);
            }
            catch (Exception ex)
            {
                // Show error message
                ClientScript.RegisterStartupScript(GetType(), "alertMessage", $"alert('Error: {ex.Message}');", true);
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddEmployee.aspx");
        }

        protected void btnRead_Click(object sender, EventArgs e)
        {
            Response.Redirect("ReadEmployee.aspx");
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            Response.Redirect("EditEmployee.aspx");
        }
    }
}
