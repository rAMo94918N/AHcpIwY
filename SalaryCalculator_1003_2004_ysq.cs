// 代码生成时间: 2025-10-03 20:04:43
 * It includes error handling and follows C# best practices for code maintainability and scalability.
 */

using System;

namespace SalaryCalculatorApp
{
    public class SalaryCalculator
    {
        // Calculates the gross salary based on hours worked and hourly rate
        public double CalculateGrossSalary(int hoursWorked, double hourlyRate)
        {
            // Validate the inputs
            if (hoursWorked < 0 || hourlyRate < 0)
            {
                throw new ArgumentException("Hours worked and hourly rate must be non-negative.");
            }

            return hoursWorked * hourlyRate;
        }
    }

    // The Program class is the entry point of the application
    public class Program
    {
        public static void Main(string[] args)
        {
            // Create an instance of the SalaryCalculator
            SalaryCalculator calculator = new SalaryCalculator();

            try
            {
                // Example usage: Calculate the salary for an employee who worked 40 hours at a rate of $20 per hour
                int hoursWorked = 40;
                double hourlyRate = 20.00;

                // Calculate the gross salary
                double grossSalary = calculator.CalculateGrossSalary(hoursWorked, hourlyRate);

                // Output the result
                Console.WriteLine($"Gross Salary: ${grossSalary:F2}");
            }
            catch (ArgumentException ex)
            {
                // Handle the case where the input is invalid
                Console.WriteLine($"Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                // Handle any other exceptions
                Console.WriteLine($"An unexpected error occurred: {ex.Message}");
            }
        }
    }
}
