using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab5_WebApp.ViewModels
{
    public enum SortState
    {
        No, 
        //CarMark
        CarMarkNameAsc,
        CarMarkNameDesc,
        //Employees
        EmployeesPostAsc,
        EmployeesNameAsc,
        EmployeesSurnameAsc,
        EmployeesPatronymicAsc,
        EmployeesEmploymentDateAsc,
        EmployeesPostDesc,
        EmployeesNameDesc,
        EmployeesSurnameDesc,
        EmployeesPatronymicDesc,
        EmployeesEmploymentDateDesc,
        //CarModels
        CarModelsNameAsc,
        CarModelsDescriptionAsc,
        CarModelsNameDesc,
        CarModelsDescriptionDesc,
        //Cars
        RegNumAsc,
        VINcodeAsc,
        EngineNumAsc,
        PriceAsc,
        RentalPriceAsc,
        IssueDateAsc,
        SpecsAsc,
        TechnicalMaintenanceDateAsc,
        SpecMarkAsc,
        ReturnMarkAsc,

        RegNumDesc,
        VINcodeDesc,
        EngineNumDesc,
        PriceDesc,
        RentalPriceDesc,
        IssueDateDesc,
        SpecsDesc,
        TechnicalMaintenanceDateDesc,
        SpecMarkDesc,
        ReturnMarkDesc
    }

    public class SortViewModel
    {
        //CarMark
        public SortState CarMarkNameSort { get; set; }
        //Employees
        public SortState EmployeesPostSort { get; set; }
        public SortState EmployeesNameSort { get; set; }
        public SortState EmployeesSurnameSort { get; set; }
        public SortState EmployeesPatronymicSort { get; set; }
        public SortState EmployeesEmploymentDateSort { get; set; }
        //CarModels
        public SortState CarModelsNameSort { get; set; }
        public SortState CarModelsDescriptionSort { get; set; }
        //Cars
        public SortState CarsRegNum { get; set; }
        public SortState CarsVINcode { get; set; }
        public SortState CarsEngineNum { get; set; }
        public SortState CarsPrice { get; set; }
        public SortState CarsRentalPrice { get; set; }
        public SortState CarsIssueDate { get; set; }
        public SortState CarsSpecs { get; set; }
        public SortState CarsTechnicalMaintenanceDate { get; set; }
        public SortState CarsSpecMark { get; set; }
        public SortState CarsReturnMark { get; set; }


        public SortState CurrentState { get; set; }
        public SortViewModel(SortState state)
        {
            //CarMark
            CarMarkNameSort = state == SortState.CarMarkNameAsc ? SortState.CarMarkNameDesc : SortState.CarMarkNameAsc;
            CurrentState = state;
            //Employees
            EmployeesPostSort = state == SortState.EmployeesPostAsc ? SortState.EmployeesPostDesc : SortState.EmployeesPostAsc;
            CurrentState = state;

            EmployeesNameSort = state == SortState.EmployeesNameAsc ? SortState.EmployeesNameDesc : SortState.EmployeesNameAsc;
            CurrentState = state;

            EmployeesSurnameSort = state == SortState.EmployeesSurnameAsc ? SortState.EmployeesSurnameDesc : SortState.EmployeesSurnameAsc;
            CurrentState = state;

            EmployeesPatronymicSort = state == SortState.EmployeesPatronymicAsc ? SortState.EmployeesPatronymicDesc : SortState.EmployeesPatronymicAsc;
            CurrentState = state;

            EmployeesEmploymentDateSort = state == SortState.EmployeesEmploymentDateAsc ? SortState.EmployeesEmploymentDateDesc : SortState.EmployeesEmploymentDateAsc;
            CurrentState = state;
            //CarModels
            CarModelsNameSort = state == SortState.CarModelsNameAsc ? SortState.CarModelsNameDesc : SortState.CarModelsNameAsc;
            CurrentState = state;

            CarModelsDescriptionSort = state == SortState.CarModelsDescriptionAsc ? SortState.CarModelsDescriptionDesc : SortState.CarModelsDescriptionAsc;
            CurrentState = state;
            //Cars

            CarsRegNum = state == SortState.RegNumAsc ? SortState.RegNumDesc : SortState.RegNumAsc;
            CurrentState = state;

            CarsVINcode = state == SortState.VINcodeAsc ? SortState.VINcodeDesc : SortState.VINcodeAsc;
            CurrentState = state;

            CarsEngineNum = state == SortState.EngineNumAsc ? SortState.EngineNumDesc : SortState.EngineNumAsc;
            CurrentState = state;

            CarsPrice = state == SortState.PriceAsc ? SortState.PriceDesc : SortState.PriceAsc;
            CurrentState = state;

            CarsRentalPrice = state == SortState.RentalPriceAsc ? SortState.RentalPriceDesc : SortState.RentalPriceAsc;
            CurrentState = state;
            /*
              RegNumAsc,
            VINcodeAsc,
            EngineNumAsc,
            PriceAsc,
            RentalPriceAsc,
            IssueDateAsc,
            SpecsAsc,
            TechnicalMaintenanceDateAsc,
            SpecMarkAsc,
            ReturnMarkAsc,

            RegNumDesc,
            VINcodeDesc,
            EngineNumDesc,
            PriceDesc,
            RentalPriceDesc,
            IssueDateDesc,
            SpecsDesc,
            TechnicalMaintenanceDateDesc,
            SpecMarkDesc,
            ReturnMarkDesc
            */
            CarsIssueDate = state == SortState.IssueDateAsc ? SortState.IssueDateDesc : SortState.IssueDateAsc;
            CurrentState = state;

            CarsSpecs = state == SortState.SpecsAsc ? SortState.SpecsDesc : SortState.SpecsAsc;
            CurrentState = state;

            CarsTechnicalMaintenanceDate = state == SortState.TechnicalMaintenanceDateAsc ? SortState.TechnicalMaintenanceDateDesc : SortState.TechnicalMaintenanceDateAsc;
            CurrentState = state;

            CarsSpecMark = state == SortState.SpecMarkAsc ? SortState.SpecMarkDesc : SortState.SpecMarkAsc;
            CurrentState = state;

            CarsReturnMark = state == SortState.ReturnMarkAsc ? SortState.ReturnMarkDesc : SortState.ReturnMarkAsc;
            CurrentState = state;
        }
    }
}
