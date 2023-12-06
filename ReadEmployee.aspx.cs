using System;
using System.Data;
using System.Data.SqlClient;

namespace WebApplication5
{
    public partial class ReadEmployee : System.Web.UI.Page
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
            DataTable dataTable = GetEmployees();
            GridView1.DataSource = dataTable;
            GridView1.DataBind();
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

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddEmployee.aspx");
        }
    }
}
