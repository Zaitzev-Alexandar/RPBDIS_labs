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
    public partial class CarModels : System.Web.UI.Page
    {
        private CarSharingContext db = new CarSharingContext();
        private string strFindCarModel = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                strFindCarModel = TextBoxFindCarModel.Text;
                ShowData(strFindCarModel);
            }
        }

        protected void ButtonFindCarModel_Click(object sender, EventArgs e)
        {
            strFindCarModel = TextBoxFindCarModel.Text;
            ShowData(strFindCarModel);
        }
        protected void ShowData(string strFindCarModel = "")
        {

            List<CarModel> carModels = db.CarModels.Where(s => s.Name.Contains(strFindCarModel)).ToList();
            GridViewCarModel.DataSource = carModels;
            GridViewCarModel.DataBind();
        }

        protected void ButtonAddCarModel_Click(object sender, EventArgs e)
        {
            string carModelName = TextBoxCarModelName.Text ?? "";
            string carModelDescription = TextBoxCarModelDescription.Text ?? "";
            if (carModelName != "" && carModelDescription != "")
            {
                CarModel carModel = new CarModel
                {
                    Name = carModelName,
                    Description = carModelDescription
                };

                db.CarModels.Add(carModel);
                db.SaveChanges();
                TextBoxCarModelName.Text = "";
                TextBoxCarModelDescription.Text = "";
                ShowData(strFindCarModel);

            }
        }
        protected void GridViewCarModel_RowEditing(object sender, GridViewEditEventArgs e)
        {
            //Set the edit index.
            GridViewCarModel.EditIndex = e.NewEditIndex;
            //Bind data to the GridView control.
            ShowData(strFindCarModel);
        }
            protected void GridViewCarModel_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            //Reset the edit index.
            GridViewCarModel.EditIndex = 1;
            //Bind data to the GridView control.
            ShowData(strFindCarModel);
        }
        protected void GridViewCarModel_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            //Update the values.
            GridViewRow row = GridViewCarModel.Rows[e.RowIndex];
            int id = Convert.ToInt32(row.Cells[1].Text);
            CarModel carModel = db.CarModels.Where(f => f.CarModelId == id).FirstOrDefault();
            db.CarModels.Remove(carModel);

            //db.Entry(fuel).State = EntityState.Modified;
            db.SaveChanges();
            //Reset the edit index.
            GridViewCarModel.EditIndex = -1;

            //Bind data to the GridView control.
            ShowData(strFindCarModel);

        }
        protected void GridViewCarModel_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {

            //Update the values.
            GridViewRow row = GridViewCarModel.Rows[e.RowIndex];
            int id = Convert.ToInt32(((TextBox)(row.Cells[1].Controls[0])).Text);
            CarModel carModel = db.CarModels.Where(f => f.CarModelId == id).FirstOrDefault();
            carModel.Name = ((TextBox)(row.Cells[2].Controls[0])).Text;
            carModel.Description = ((TextBox)(row.Cells[2].Controls[0])).Text;

            db.SaveChanges();
            //Reset the edit index.
            GridViewCarModel.EditIndex = -1;

            //Bind data to the GridView control.
            ShowData(strFindCarModel);
        }
        protected void GridViewCarModel_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridViewCarModel.PageIndex = e.NewPageIndex;
            ShowData(strFindCarModel);

        }
    }
}