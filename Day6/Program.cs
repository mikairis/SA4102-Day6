using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day6
{
    class Program
    {
        static int[] minIncomeArray = new int[]
        { 20000, 30000, 40000, 80000, 120000, 160000, 200000, 320000 };
        static double[] taxRateArray = new double[]
        { 0.02, 0.035, 0.07, 0.115, 0.15, 0.17, 0.18, 0.20 };
        static int[] basePayableAmountArray = new int[]
        { 0, 200, 550, 3350, 7950, 13950, 20750, 42350 };

        static void Main(string[] args)
        {
            Console.WriteLine("**********Day 6 Quiz**********");

            int annualIncome = AskForIncome();
            int taxBracket = GetTaxBracket(annualIncome);
            double taxPayable = CalculateIncomeTax(annualIncome, taxBracket);
            PrintResult(annualIncome, taxPayable);
        }
        static int AskForIncome()
        {
            Console.WriteLine("Please enter your annual taxable income: ");
            return Convert.ToInt32(Console.ReadLine());
        }
        static int GetTaxBracket(int annualIncome)
        {
            for (int i = minIncomeArray.Length - 1; i >= 0; i--)
            {
                int taxBracketChecker = minIncomeArray[i];
                
                if (annualIncome > taxBracketChecker)
                {
                    return i;
                }
            }
            return -1;
        }
        static double CalculateIncomeTax(int annualIncome, int taxBracket)
        {
            double tax = 0;
            double minimumIncome = minIncomeArray[taxBracket];
            double taxRate = taxRateArray[taxBracket];
            double basePayableAmount = basePayableAmountArray[taxBracket];

            if (taxBracket == -1)
            {
                tax = 0;
            }
            else
            {
                tax = annualIncome - minimumIncome * taxRate + basePayableAmount;
            }

            return tax;
        }
        static void PrintResult(int annualIncome, double taxPayable)
        {
            Console.WriteLine("For taxable annual income of $" + annualIncome  + ", the taxable amount is $" + taxPayable);
            Console.ReadKey();
        }
    }
}