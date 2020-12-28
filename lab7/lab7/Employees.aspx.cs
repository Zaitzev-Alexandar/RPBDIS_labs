using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using lab7.Data;
using lab7.Models;


namespace lab7
{
    public partial class Employees : System.Web.UI.Page
    {
        private CarSharingContext db = new CarSharingContext();
        private string strFindEmployee = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                strFindEmployee = TextBoxFindEmployee.Text;
                ShowData(strFindEmployee);
            }
        }

        protected void ButtonFindEmployee_Click(object sender, EventArgs e)
        {
            strFindEmployee = TextBoxFindEmployee.Text;
            ShowData(strFindEmployee);
        }
        protected void ShowData(string strFindEmployee = "")
        {

            List<Employee> Employees = db.Employees.Where(s => s.Name.Contains(strFindEmployee)).ToList();
            GridViewEmployee.DataSource = Employees;
            GridViewEmployee.DataBind();
        }

        protected void ButtonAddEmployee_Click(object sender, EventArgs e)
        {
            string EmployeeName = TextBoxEmployeeName.Text ?? "";
            string EmployeeSurname = TextBoxEmployeeSurname.Text ?? "";
            string EmployeePatronymic = TextBoxEmployeePatronymic.Text ?? "";
            string EmployeePost = TextBoxEmployeePost.Text ?? "";
            string EmployeeEmploymentDate = TextBoxEmployeeEmploymentDate.Text ?? "";
            if (EmployeeName != "" && EmployeeEmploymentDate != "")
            {
                Employee Employee = new Employee
                {
                    Surname = EmployeeSurname,
                    Patronymic = EmployeePatronymic,
                    Name = EmployeeName,
                    Post = EmployeePost,
                    EmploymentDate = Convert.ToDateTime(EmployeeEmploymentDate)
                };

                db.Employees.Add(Employee);
                db.SaveChanges();
                TextBoxEmployeeName.Text = "";
                TextBoxEmployeeEmploymentDate.Text = "";
                ShowData(strFindEmployee);

            }
        }
        protected void GridViewEmployee_RowEditing(object sender, GridViewEditEventArgs e)
        {
            //Set the edit index.
            GridViewEmployee.EditIndex = e.NewEditIndex;
            //Bind data to the GridView control.
            ShowData(strFindEmployee);
        }
            protected void GridViewEmployee_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            //Reset the edit index.
            GridViewEmployee.EditIndex = 1;
            //Bind data to the GridView control.
            ShowData(strFindEmployee);
        }
        protected void GridViewEmployee_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            //Update the values.
            GridViewRow row = GridViewEmployee.Rows[e.RowIndex];
            int id = Convert.ToInt32(row.Cells[1].Text);
            Employee Employee = db.Employees.Where(f => f.EmployeeId == id).FirstOrDefault();
            db.Employees.Remove(Employee);

            //db.Entry(fuel).State = EntityState.Modified;
            db.SaveChanges();
            //Reset the edit index.
            GridViewEmployee.EditIndex = -1;

            //Bind data to the GridView control.
            ShowData(strFindEmployee);

        }
        protected void GridViewEmployee_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {

            //Update the values.
            GridViewRow row = GridViewEmployee.Rows[e.RowIndex];
            int id = Convert.ToInt32(((TextBox)(row.Cells[1].Controls[0])).Text);
            Employee Employee = db.Employees.Where(f => f.EmployeeId == id).FirstOrDefault();
            Employee.Surname = ((TextBox)(row.Cells[2].Controls[0])).Text;
            Employee.Name = ((TextBox)(row.Cells[3].Controls[0])).Text;

            Employee.Patronymic = ((TextBox)(row.Cells[4].Controls[0])).Text;
            Employee.Post = ((TextBox)(row.Cells[5].Controls[0])).Text;
            Employee.EmploymentDate = Convert.ToDateTime(((TextBox)(row.Cells[6].Controls[0])).Text);

            db.SaveChanges();
            //Reset the edit index.
            GridViewEmployee.EditIndex = -1;

            //Bind data to the GridView control.
            ShowData(strFindEmployee);
        }
        protected void GridViewEmployee_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridViewEmployee.PageIndex = e.NewPageIndex;
            ShowData(strFindEmployee);

        }
    }
}