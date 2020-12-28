using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using lab7.Data;
using lab7.Models;
using System.Data.Entity;

namespace lab7
{
    public partial class Cars : System.Web.UI.Page
    {
        private CarSharingContext db = new CarSharingContext();
        private string strFindCar = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                strFindCar = TextBoxFindCar.Text;
                ShowData(strFindCar);
            }
        }

        protected void ButtonFindCar_Click(object sender, EventArgs e)
        {
            strFindCar = TextBoxFindCar.Text;
            ShowData(strFindCar);
        }
        protected void ShowData(string strFindCar = "")
        {

            List<Car> Cars = db.Cars.Include(s => s.CarModel).Include(s => s.Employee).Where(s => s.VINcode.Contains(strFindCar)).ToList();
            GridViewCar.DataSource = Cars;
            GridViewCar.DataBind();
        }

        protected void ButtonAddCar_Click(object sender, EventArgs e)
        {
            string CarEngineNum = TextBoxCarEngineNum.Text ?? "";
            string CarVINCode = TextBoxCarVINCode.Text ?? "";
            string CarRegNum = TextBoxCarRegNum.Text ?? "";
            string CarPrice = TextBoxCarPrice.Text ?? "";
            string CarRentalPrice = TextBoxCarRentalPrice.Text ?? "";
            string CarIssueDate = TextBoxCarIssueDate.Text ?? "";
            string CarSpecs = TextBoxCarSpecs.Text ?? "";
            string CarTechnicalMaintenanceDate = TextBoxCarTechnicalMaintenanceDate.Text ?? "";
            string CarSpecMark = TextBoxCarSpecMark.Text ?? "";
            string CarReturnMark = TextBoxCarReturnMark.Text ?? "";
            Car Car = new Car
            {
                EngineNum = Convert.ToInt32(CarEngineNum),
                VINcode = CarVINCode,
                RegNum = Convert.ToInt32(CarRegNum),
                Price = Convert.ToDecimal(CarPrice),
                RentalPrice = Convert.ToDecimal(CarRentalPrice),
                IssueDate = Convert.ToDateTime(CarIssueDate),
                Specs = CarSpecs,
                TechnicalMaintenanceDate = Convert.ToDateTime(CarTechnicalMaintenanceDate),
                SpecMark = Convert.ToBoolean(CarSpecMark),
                ReturnMark = Convert.ToBoolean(CarReturnMark),
                CarModelId = int.Parse(CarModelDropDownList.SelectedValue),
                EmployeeId = int.Parse(EmployeeDropDownList.SelectedValue)

            };

            db.Cars.Add(Car);
            db.SaveChanges();
            ShowData(strFindCar);

            
        }
        protected void GridViewCar_RowEditing(object sender, GridViewEditEventArgs e)
        {
            //Set the edit index.
            GridViewCar.EditIndex = e.NewEditIndex;
            //Bind data to the GridView control.
            ShowData(strFindCar);
        }
            protected void GridViewCar_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            //Reset the edit index.
            GridViewCar.EditIndex = 1;
            //Bind data to the GridView control.
            ShowData(strFindCar);
        }
        protected void GridViewCar_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            //Update the values.
            GridViewRow row = GridViewCar.Rows[e.RowIndex];
            int id = Convert.ToInt32(row.Cells[1].Text);
            Car Car = db.Cars.Where(f => f.CarId == id).FirstOrDefault();
            db.Cars.Remove(Car);

            //db.Entry(fuel).State = EntityState.Modified;
            db.SaveChanges();
            //Reset the edit index.
            GridViewCar.EditIndex = -1;

            //Bind data to the GridView control.
            ShowData(strFindCar);

        }
        protected void GridViewCar_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {

            //Update the values.
            GridViewRow row = GridViewCar.Rows[e.RowIndex];
            int id = Convert.ToInt32(((TextBox)(row.Cells[1].Controls[0])).Text);
            Car Car = db.Cars.Where(f => f.CarId == id).FirstOrDefault();


            Car.RegNum = Convert.ToInt32(((TextBox)(row.Cells[2].Controls[0])).Text);
            Car.VINcode = ((TextBox)(row.Cells[3].Controls[0])).Text;
            Car.EngineNum = Convert.ToInt32(((TextBox)(row.Cells[4].Controls[0])).Text);


            Car.Price = Convert.ToDecimal(((TextBox)(row.Cells[5].Controls[0])).Text);
            Car.RentalPrice = Convert.ToDecimal(((TextBox)(row.Cells[6].Controls[0])).Text);
            Car.IssueDate = Convert.ToDateTime(((TextBox)(row.Cells[7].Controls[0])).Text);
            Car.Specs = ((TextBox)(row.Cells[8].Controls[0])).Text;
            Car.TechnicalMaintenanceDate = Convert.ToDateTime(((TextBox)(row.Cells[9].Controls[0])).Text);
            Car.SpecMark = Convert.ToBoolean(((TextBox)(row.Cells[10].Controls[0])).Text);
            Car.ReturnMark = Convert.ToBoolean(((TextBox)(row.Cells[11].Controls[0])).Text);

            Car.CarModelId = int.Parse(e.NewValues["CarModelId"].ToString());
            Car.EmployeeId = int.Parse(e.NewValues["EmployeeId"].ToString());

            db.SaveChanges();
            //Reset the edit index.
            GridViewCar.EditIndex = -1;

            //Bind data to the GridView control.
            ShowData(strFindCar);
        }
        protected void GridViewCar_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridViewCar.PageIndex = e.NewPageIndex;
            ShowData(strFindCar);

        }
    }
}