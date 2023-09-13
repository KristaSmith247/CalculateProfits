/* ProfitCalculator.cs
 * Author: Krista Smith
 * Date : 9/11/23
 * Description : The program will calculate the profit from sales given user input for sale price of an item and cases sold.
 * */

using System;
using System.Data;
using static System.Console;

namespace CalculateProfits
{
    class CalculateProfits
    {
        static void Main(string[] args)
        {
            int casesSold, barsSold, BARS_PER_CASE, CASE_PURCHASE_PRICE;

            BARS_PER_CASE = 12;
            CASE_PURCHASE_PRICE = 5;
            double salePrice, wholesaleCost, grossSales, costOfCandy, netSales, fees, profit;
    

            DisplayInstructions();
            salePrice = GetSalePrice();
            casesSold = GetCasesSold();
            barsSold = CalculateBars(casesSold);
            wholesaleCost = (5.00 / 12);
            grossSales = casesSold * BARS_PER_CASE * salePrice;
            costOfCandy = CASE_PURCHASE_PRICE * casesSold;
            netSales = (grossSales - costOfCandy);
            fees = (netSales * 0.1);
            if (fees < 0)
            {
                fees = 0;
            }
            profit = grossSales - costOfCandy - fees;
            DisplayResults(casesSold, barsSold, wholesaleCost, salePrice, grossSales, costOfCandy, netSales, fees, profit);
        }
        static void DisplayInstructions()
        {
            // This method will display the beginning instructions.

            WriteLine("This program will calculate the total profit of sales from granola bars.");
            WriteLine("You will be asked to enter the number of cases sold and the sale price ");
            WriteLine("per item. Hit any key to continue.");
            ReadKey();
            Clear();
        }

        static double GetSalePrice()
        {
            // This method will ask the user to input a sale price per single item.

            string inputValue;
            double salePrice;
            WriteLine("Enter the sale price of an individual item (example: 0.75): ");
            inputValue = ReadLine();
            salePrice = double.Parse(inputValue);
            
            // Checking for invalid input
            if (salePrice < 0)
            {
                WriteLine("Sale price cannot be negative. Enter the sale price of a single item: ");
                inputValue = ReadLine();
                salePrice = double.Parse(inputValue);
            }
            return salePrice;
        }

        static int GetCasesSold()
        {
            /* This method will ask the user to input the number of cases sold
            * and check the user input isn't negative. 
            */

            string inputValue;
            int casesSold;
            WriteLine("Enter the number of cases sold: ");
            inputValue = ReadLine();
            casesSold = int.Parse(inputValue);
            
            // Checking for invalid input
            if (casesSold < 0)
            {
                WriteLine("Cases sold cannot be negative. Enter a positive value: ");
                inputValue = ReadLine();
                casesSold = int.Parse(inputValue);
            }
            return casesSold;
        }
        
        static int CalculateBars(int casesSold)
        {
            // This method will calculate the total number of items sold.
            const int BARS_PER_CASE = 12;
            return casesSold * BARS_PER_CASE;
        }

        static void DisplayResults(int casesSold, int barsSold, double wholesaleCost, double salePrice, double grossSales, double costOfCandy, double netSales, double fees, double profit)
        {
            // This method displays the formatted results of all calculations.
            Clear();
            WriteLine("{0,26}", "Summary of Candy Sales");
            WriteLine();
            WriteLine("Number of Cases Sold: {0,10}", casesSold);
            WriteLine("Number of Bars Per Case: {0,7}", 12);
            WriteLine("Number of Bars Sold: {0,11}", barsSold);
            WriteLine();
            WriteLine("Wholesale Cost Per Bar: {0,8:C}", wholesaleCost);
            WriteLine("Selling Price Per Bar: {0,9:C}", salePrice);
            WriteLine();
            WriteLine("Gross Sales: {0,19:C}", grossSales);
            WriteLine("Cost of Candy: {0,17:C}", costOfCandy);
            WriteLine("Net Sales: {0,21:C}", netSales);
            WriteLine("SGA Fee: {0,23:C}", fees);
            WriteLine();
            WriteLine();
            WriteLine();
            WriteLine("******Profit: {0,18:C}*", profit);
        }
    }
}