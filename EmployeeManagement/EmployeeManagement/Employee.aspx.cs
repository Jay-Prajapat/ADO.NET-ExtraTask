using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace EmployeeManagement
{
    public partial class Employee : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGrid();
            }
        }

        private void BindGrid()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["EmployeeDatabase"].ConnectionString;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "select * from tblEmployee";
                SqlDataAdapter da = new SqlDataAdapter(query, con);
                DataSet ds = new DataSet();
                da.Fill(ds, "employee");
                ViewState["dataset"] = ds;
                GridView1.DataSource = ds;
                GridView1.DataBind();

            }
        }

        

        protected void Update_Click(object sender, EventArgs e)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["EmployeeDatabase"].ConnectionString;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("insert into tblEmployee values (@empName,@empSalary,@empDesignation)",con);
                cmd.Parameters.Add("@empName", txtName.Text);
                cmd.Parameters.Add("@empSalary", txtSalary.Text);
                cmd.Parameters.Add("@empDesignation", txtDesignation.Text);
                con.Open();
               int rowUpdated = cmd.ExecuteNonQuery();


                if (rowUpdated > 0)
                {
                    lblStatus.ForeColor = System.Drawing.Color.Green;
                    lblStatus.Text = rowUpdated.ToString() + "row(s) affected";
                }
                else
                {
                    lblStatus.ForeColor = System.Drawing.Color.Red;
                    lblStatus.Text = "No row affected";
                }
                txtName.Text = "";
                txtSalary.Text = "";
                txtDesignation.Text = "";
                BindGrid();
            }
        }
        protected void GridView1_RowEditing(object sender, System.Web.UI.WebControls.GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            BindGrid();
        }
        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["EmployeeDatabase"].ConnectionString;
            
            int empid = Convert.ToInt32(e.NewValues["EmployeeId"]);
            string empname = e.NewValues["EmployeeName"].ToString();
            decimal salary = Convert.ToDecimal(e.NewValues["Salary"]);
            string designation = e.NewValues["Designation"].ToString();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string updateQuery = "UPDATE tblEmployee SET EmployeeName = @empname, Salary = @salary, Designation = @designation WHERE EmployeeId = @empid";

                SqlCommand command = new SqlCommand(updateQuery, connection);
                command.Parameters.AddWithValue("@empid", empid);
                command.Parameters.AddWithValue("@empname", empname);
                command.Parameters.AddWithValue("@salary", salary);
                command.Parameters.AddWithValue("@designation", designation);

                connection.Open();
                command.ExecuteNonQuery();
               
            }

            GridView1.EditIndex = -1;
            BindGrid();
        }

       
        
    }
}