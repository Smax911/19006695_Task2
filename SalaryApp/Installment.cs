using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;


namespace SalaryApp
{       // https://www.youtube.com/watch?v=4h1eGlB8u_A&list=PL480DYS-b_keHacwHfXhHmHpWSI1n3Ff9&index=16
        // Ebrahim Adams 
        // 2 April 2021
        // Guru Videos
        // You tube 
    public partial class frmCalculator : Form
    {
        private double grosaries;
        private double waterNLight;
        private double travelCost;
        private double cellphone;
        private double otherExpenses;
        private double rent;

        List<double> list;// generic collection for the list box

        public frmCalculator()
        {
            InitializeComponent();

        
        }


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void lblRental_CheckedChanged(object sender, EventArgs e)
        {
            // This will allow the user to be able to choose between the Rental or Property
            // when the user click on rental the rental group box will appear and the property groupbox will be hidden
            if (rdbRental.Checked) {
                gpbBuyAProperty.Visible = false;
                gpbRental.Visible = true;
                btnCurrentBalance.Visible = true;
                btnInstallment.Visible = false;
                btnContinue.Visible = true;

            }


        }

        private void rdbBuyingAProperty_CheckedChanged(object sender, EventArgs e)
        {
            // This will allow the user to be able to choose between the Rental or Property
            // when the user click on rental the rental group box will hidden and the property groupbox will be shown
            if (rdbBuyingAProperty.Checked) {
                gpbRental.Visible = false;
                gpbBuyAProperty.Visible = true;
                btnCurrentBalance.Visible = false;
                btnInstallment.Visible = true;
                btnContinue.Visible = true;
            }
        }

       

        private void btnExpenses_Click(object sender, EventArgs e)
        {
            try
            {
                // declaring the fields and linking the to the form
                double grossIncome = Convert.ToDouble(txbGrossMonthlyIncome.Text);
                double taxDeduction = Convert.ToDouble(txbEstimatedMonthlyTax.Text);
                double groceries = Convert.ToDouble(txbGrossaries.Text);
                double waterNlight = Convert.ToDouble(txbWaterAndLight.Text);
                double travel = Convert.ToDouble(txbTravelCost.Text);
                double cellphone = Convert.ToDouble(txbCellphone.Text);
                double otherExpenses = Convert.ToDouble(txbOtherExpenses.Text);
                double rent = Convert.ToDouble(txbRental.Text);

                //construtor linking the the form with the fields on the GrossTax class
                GrossTax s = new GrossTax(groceries, waterNlight, travel, cellphone, otherExpenses, rent, grossIncome, taxDeduction);
                
                double finalIncome = grossIncome - (s.deductedIncomeTax + s.total_Expenses); // after tax, now we subtract the remaiining gross income with the total expenses
                                                                     // this is the message which tell the user the total monthly expenses, Gross monthly income after tax and Gross monthly income after tax and expenses
                MessageBox.Show("Current Balance : R" + string.Format("{0:0.00}", finalIncome));
                // https://stackoverflow.com/questions/10749506/two-decimal-places-using-c-sharp
                // Stack Overflow
                //Louis Waweru
                // 25 MayTwo
                // Decimal places using c#

            }
            catch (Exception h) {

                MessageBox.Show(h.Message);// show the message of the error 
            }
            lsbExpenses.Visible = true;// makes the Listbox to be seen 


        }

        private void btnInstallment_Click(object sender, EventArgs e)
        {
            try// try catch 
            {
                // declaring the fields and linking the to the form
                double groceries = Convert.ToDouble(txbGrossaries.Text);
                double waterNlight = Convert.ToDouble(txbWaterAndLight.Text);
                double travel = Convert.ToDouble(txbTravelCost.Text);
                double cellphone = Convert.ToDouble(txbCellphone.Text);
                double otherExpenses = Convert.ToDouble(txbOtherExpenses.Text);
                double rent = 0; // declaring rent 0 becuase its not needed in this instance 
                double grossIncome = Convert.ToDouble(txbGrossMonthlyIncome.Text);
                double taxDeduction = Convert.ToDouble(txbEstimatedMonthlyTax.Text);
                double PurchasePrice = Convert.ToDouble(txbPurchasePrice.Text);
                double TotalDeposit = Convert.ToDouble(txbTotalDeposit.Text);
                double InterestRate = Convert.ToDouble(txbInterestRate.Text);
                int MonthNum = Convert.ToInt32(txbRepay.Text);

                // contructor for linking the form to the home loan class 
                Home_Loan a = new Home_Loan(groceries, waterNlight, travel, cellphone, otherExpenses, rent, PurchasePrice, TotalDeposit, InterestRate, MonthNum);
                GrossTax s = new GrossTax(groceries, waterNlight, travel, cellphone, otherExpenses, rent, grossIncome, taxDeduction);

                // calculation for the third of the Gross Monthly Income 
                double third = grossIncome / 3;//this helps to detemine the third of the Gross income 
                double CurrentBalance = grossIncome - (s.total_Expenses + s.taxDeduction);//this will show the balance after expenses and tax 
                double CurrentBalance1 = grossIncome - (s.total_Expenses + s.taxDeduction + a.Monthly_Amount);// this will show balancace after tax, expences and home loan deduction

                if (a.Monthly_Amount > third) // decision for the loan 
                {

                    MessageBox.Show("This your Monthly installment for the loan: R" + string.Format("{0:0.00}", a.Monthly_Amount) +
                        "\nSorry you will not eligible to get the loan" +
                        "\nThis is your Current Balance : R" + CurrentBalance); // when the instalment is more than the third of the gross monthly salary 
                }
                else // decision for the loan 
                {

                    MessageBox.Show("This your Monthly installment for the loan: R" + string.Format("{0:0.00}", a.Monthly_Amount) +
                        "\nCongratulation you are eligible for the loan" +
                        "\nThis is your Current Balance : R" + CurrentBalance1); // if the installment is less than the third of the gross monthly salary
                }

            }
            catch (Exception g) {
                MessageBox.Show(g.Message);// if the user enters a wrong datatype 
            }


        }

        private void txbOtherExpenses_TextChanged(object sender, EventArgs e)
        {

        }

        private void frmCalculator_Load(object sender, EventArgs e)
        {

        }

        private void splitContainer1_Panel1_Paint_2(object sender, PaintEventArgs e)
        {

        }

        private void rdbNo_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbNo.Checked)
            {
                gpbCar.Visible = false;// this will enable the radio button to make the group box for car to no appear 
                BtnCarInstallment.Visible = false; // this will make the car montyhly installment button to not appear
                lsbExpenses.Visible = true; // this will help if the user does not want to but a car this radio button will show the list box
                btnClose1.Visible = true; // this will show the close button
                btnDone.Visible = true;
            }

        }

        private void btnDone_Click(object sender, EventArgs e)
        {
            try
            {
                lsbExpenses.Visible = true;
                double rent = 0;
                double PurchasePrice = 0;
                double TotalDeposit = 0;
                double InterestRate = 0;
                int MonthNum = 0;

                // values from the home loan class, this will enable the software to be able to calculate total expnses
                Double PurchasePrice2 = Convert.ToDouble(txbPurchasePrice2.Text);
                string model_And_make = (txbModelAndMake.Text);
                Double total_Deposit2 = Convert.ToDouble(txbTotalDeposit2.Text);
                Double interestRate2 = Convert.ToDouble(txbInterestRate2.Text);
                Double insurance = Convert.ToDouble(txbInsurance.Text);
                int NumberOfMonths = 60;
                // declaring the fields and linking the to the form
                double grossIncome = Convert.ToDouble(txbGrossMonthlyIncome.Text);
                double taxDeduction = Convert.ToDouble(txbEstimatedMonthlyTax.Text);
                double groceries = Convert.ToDouble(txbGrossaries.Text);
                double waterNlight = Convert.ToDouble(txbWaterAndLight.Text);
                double travel = Convert.ToDouble(txbTravelCost.Text);
                double cellphone = Convert.ToDouble(txbCellphone.Text);
                double otherExpenses = Convert.ToDouble(txbOtherExpenses.Text);
                //double grossIncome = Convert.ToDouble(txbGrossMonthlyIncome.Text);
                //double taxDeduction = Convert.ToDouble(txbEstimatedMonthlyTax.Text);

                if (rdbRental.Checked)
                {

                    rent = Convert.ToDouble(txbRental.Text); // if the user choose the rent

                }
                else
                {
                    rent = 0; // this will be enabled if the user choose property
                }
                if (rdbBuyingAProperty.Checked) // if the user chooses property these fields will be enable to work 
                {
                    PurchasePrice = Convert.ToDouble(txbPurchasePrice.Text);
                    TotalDeposit = Convert.ToDouble(txbTotalDeposit.Text);
                    InterestRate = Convert.ToDouble(txbInterestRate.Text);
                    MonthNum = Convert.ToInt32(txbRepay.Text);


                }
                else
                {
                    // but when the user chooses to the rent radio button this block will be enabled 
                    PurchasePrice = 0;
                    TotalDeposit = 0;
                    InterestRate = 0;
                    MonthNum = 0;

                }


                // contructor for linking the form to the home loan class 
                Home_Loan a = new Home_Loan(groceries, waterNlight, travel, cellphone, otherExpenses, rent, PurchasePrice, TotalDeposit, InterestRate, MonthNum);


                //construtor linking the the form with the fields on the GrossTax class
                GrossTax t = new GrossTax(groceries, waterNlight, travel, cellphone, otherExpenses, rent, grossIncome, taxDeduction);

                //this is the constructor for the vehicles class

                Vehicle s = new Vehicle(grosaries, waterNLight, travelCost, cellphone, otherExpenses, rent, model_And_make, PurchasePrice2, total_Deposit2, interestRate2, insurance, NumberOfMonths);

                // this is generic collection for the list box 
                list = new List<double>();

                // this block code will add the values to the list box 
                list.Add(a.Monthly_Amount);// expense for Home loan installment 
                list.Add(t.total_Expenses);// total for all the expenditures 
                list.Add(t.deductedIncomeTax);// this is the money which is taxed
                list.Add(s.Monthly_Payment);// this is the monthly payment for the car

                list.Sort(); // this will sort the list on the list box
                list.Reverse();

                foreach (double item in list)
                {

                    lsbExpenses.Items.Add(item); //this will add the expenses to the listbox 
                }
            }
            catch(Exception g)
            {

                MessageBox.Show(g.Message);
            }
        }

        private void rdbYes_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbYes.Checked)
            {
                gpbCar.Visible = true;//when the user clicks yes for the car the group box containing car details will be shown
                BtnCarInstallment.Visible = true;// this will show the car installment button which shows the monthly payment for the car
                lsbExpenses.Visible = false;// this will show the list box for the expenses of the user
            }
        }

        private void BtnCarInstallment_Click(object sender, EventArgs e)
        {
            try
            {
                double rent = 0;
                double PurchasePrice = 0;
                double TotalDeposit = 0;
                double InterestRate = 0;
                int MonthNum = 0;
                Double PurchasePrice2 = Convert.ToDouble(txbPurchasePrice2.Text);
                string model_And_make = (txbModelAndMake.Text);
                Double total_Deposit2 = Convert.ToDouble(txbTotalDeposit2.Text);
                Double interestRate2 = Convert.ToDouble(txbInterestRate2.Text);
                Double insurance = Convert.ToDouble(txbInsurance.Text);
                int NumberOfMonths = 60;
                // declaring the fields and linking the to the form
                double grossIncome = Convert.ToDouble(txbGrossMonthlyIncome.Text);
                double taxDeduction = Convert.ToDouble(txbEstimatedMonthlyTax.Text);
                double groceries = Convert.ToDouble(txbGrossaries.Text);
                double waterNlight = Convert.ToDouble(txbWaterAndLight.Text);
                double travel = Convert.ToDouble(txbTravelCost.Text);
                double cellphone = Convert.ToDouble(txbCellphone.Text);
                double otherExpenses = Convert.ToDouble(txbOtherExpenses.Text);
                //double grossIncome = Convert.ToDouble(txbGrossMonthlyIncome.Text);
                //double taxDeduction = Convert.ToDouble(txbEstimatedMonthlyTax.Text);

                if (rdbRental.Checked)
                {

                    rent = Convert.ToDouble(txbRental.Text);// this makes to get the value from the rental amount text box

                }
                else
                {
                    rent = 0;// if the user choosed the property the rent will be equal to zero 
                }
                if (rdbBuyingAProperty.Checked)// if the user choose proprty the will be equal to the values entered from the texxt box 
                {
                    PurchasePrice = Convert.ToDouble(txbPurchasePrice.Text);
                    TotalDeposit = Convert.ToDouble(txbTotalDeposit.Text);
                    InterestRate = Convert.ToDouble(txbInterestRate.Text);
                    MonthNum = Convert.ToInt32(txbRepay.Text);


                }
                else
                { // but if the user choose rental these values of proprty will be equal to zero

                    PurchasePrice = 0;
                    TotalDeposit = 0;
                    InterestRate = 0;
                    MonthNum = 0;

                }


                // contructor for linking the form to the home loan class 
                Home_Loan a = new Home_Loan(groceries, waterNlight, travel, cellphone, otherExpenses, rent, PurchasePrice, TotalDeposit, InterestRate, MonthNum);


                //construtor linking the the form with the fields on the GrossTax class
                GrossTax t = new GrossTax(groceries, waterNlight, travel, cellphone, otherExpenses, rent, grossIncome, taxDeduction);
              // this is the contructor for Gross tax
                // this is a contructor for vehicle 
                Vehicle s = new Vehicle(grosaries, waterNLight, travelCost, cellphone, otherExpenses, rent, model_And_make, PurchasePrice2, total_Deposit2, interestRate2, insurance, NumberOfMonths);

                // this meesage output the car monthly installment 
                MessageBox.Show(model_And_make +
                                "\nMonthly Cost : R" + string.Format("{0:0.00}", a.Monthly_Amount));

                // this will detemine 75% of the users income 
                double income = grossIncome * (75 / 100);

                //add all the expenses of the user 
                double Total_Expenses = s.Monthly_Payment + t.total_Expenses + t.deductedIncomeTax + a.Monthly_Amount;

                if (Total_Expenses >= income) // if the Total expenses have reached 75% of gross income the user will alerted
                {

                    MessageBox.Show("Your expenses are above 75% of your Monthly Income"); // alert for the user 
                }



                btnDone.Visible = true; // this will show the done button 
                btnClose1.Visible = true; // this will show the Close button
               
            }
            catch(Exception m) {

                MessageBox.Show(m.Message); // message if the user a wrong text 
            }
        }

        private void btnContinue_Click(object sender, EventArgs e)
        {
            gpbDoYouWantACar.Visible = true; // the continue button will show the Group box for a Car
        }

        private void btnClose1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
    }

   
    
    
    
    

