using System;
using System.Collections.Generic;
using System.Text;

namespace SalaryApp
{
    class Vehicle : Expenses // the vehicle class 
    {
        public Vehicle(double grosaries, double waterNLight, double travelCost, double cellphone, double otherExpenses, double rent, string Model_And_Make, double PurchasePrice2, double Total_Deposit, double InterestRate2, double Insurance, int NumberOfMonths) 
            : base(grosaries, waterNLight, travelCost, cellphone, otherExpenses, rent)
        {
            this.PurchasePrice2 = PurchasePrice2;
            this.Model_And_Make = Model_And_Make;
            this.Total_Deposit = Total_Deposit;
            this.InterestRate2 = InterestRate2;
            this.Insurance = Insurance;
            this.NumberOfMonths = 60; // the number of months is constant
            this.Monthly_Payment = Monthly_Installment();
        }

        //these are the getters of the vehicle class 
        public double PurchasePrice2 { get; set; }
        public string Model_And_Make { get; set; }
        public double Total_Deposit { get; set; }
        public double InterestRate2 { get; set; }
        public double  Insurance { get; set; }
        public int NumberOfMonths { get; set; }
        public double Monthly_Payment { get; }

        public  double Monthly_Installment()
        {

            double i = InterestRate2 / 100; // this takes the interest rate fro the user and divide it by 100 to get the correct decimal percentage 
            double P = PurchasePrice2;// making this to be P so my calculation will be neater
            double n = NumberOfMonths / 12;// multipliying the number of months with 12
            double A = P * (1 + (i * n)); // putting the values on the calculations 
            double Payment = A / NumberOfMonths;// dividing the answer with the number of months
            double Monthly_Payment = Payment + Insurance;// adding the monthly installment with the insurance of the car

            return Monthly_Payment; //returns the monthly amount of the car 

            

        }

    }

}
