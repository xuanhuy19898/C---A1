//
//I, XUAN HUY PHAM, 000899551 certify that this material is my original work.  No other person's work has been used without due acknowledgement.
//
using System;
using System.IO;
using System.Collections.Generic;

namespace Lab1
{
    /// <summary>
    /// the main program
    /// </summary>
    class Program
    {
        /// <summary>
        /// main method
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            //read the data of employees from employees.csv file
            Employee[] employees = Read("employees.csv");

            //initialize choices
            String choice;
            //cases for all options based on Menu() and exit the program when input is "6"
            while ((choice = Menu()) != "6")
            {
                Console.WriteLine();
                switch (choice)
                {
                    //when input is 1 and it prints out the sorted array of employee's name in ascending order
                    case "1":
                        Sort(employees, new EmployeeNameComparer());
                        TableFormat();//format the table of data
                        foreach (Employee e in employees)
                            EmployeeInfo(e);
                        break;
                    //when input is 2 and it prints out the sorted array of employee's id in ascending order
                    case "2":
                        Sort(employees, new EmployeeNumberComparer());
                        TableFormat();
                        foreach (Employee e in employees)
                            EmployeeInfo(e);
                        break;
                    //when input is 3 and it prints out a sorted array of employee's pay rate in descending order
                    case "3":
                        Sort(employees, new EmployeeRateComparer());
                        TableFormat();
                        foreach (Employee e in employees)
                            EmployeeInfo(e);
                        break;
                    //input is "4" and it prints out a sorted array of employee's working hours in descending order
                    case "4":
                        Sort(employees, new EmployeeHoursComparer());
                        TableFormat();
                        foreach (Employee e in employees)
                            EmployeeInfo(e);
                        break;
                    //input is "5" and it prints out a sorted array of employee's gross pay in descending order
                    case "5":
                        Sort(employees, new EmployeeGrossPayComparer());
                        TableFormat();
                        foreach (Employee e in employees)
                            EmployeeInfo(e);
                        break;
                    //when user types in an invalid input (not from 1 to 6)
                    default:
                        Console.WriteLine("Invalid option. Choose option 1 to 6");
                        break;
                }
            }
            Console.WriteLine("Press Enter one more time to exit!");
            Console.ReadLine();
        }

        /// <summary>
        /// display the table of data in a format
        /// </summary>
        private static void TableFormat()
        {
            Console.WriteLine("----------------------------------------------------------------------------");
            Console.WriteLine("|  Employee Name  |  Employee Number  |  Pay Rate  |  Hours  |  Gross Pay  |");
            Console.WriteLine("----------------------------------------------------------------------------");
        }

        /// <summary>
        /// display employee's info in a formatted table using ToString
        /// </summary>
        /// <param name="employee"></param>
        private static void EmployeeInfo(Employee employee)
        {
            Console.WriteLine(employee.ToString());
        }

        /// <summary>
        /// to sort an array of employees using Insertion Sort algorithm
        /// this algorithm sorts a list of elements by taking each elemtn and adding
        /// it to the correct position in the list
        /// the algorithm iterates through the list until the array is fully sorted
        /// reference: https://code-maze.com/insertion-sort-csharp/
        /// </summary>
        /// <param name="employees">the array of employee</param>
        /// <param name="comparer">the comparer to use for sorting</param>
        static void Sort(Employee[] employees, IComparer<Employee> comparer)
        {
            for (int i = 1; i < employees.Length; i++)
            {
                Employee key = employees[i];
                int j = i - 1;

                while (j >= 0 && comparer.Compare(employees[j], key) > 0)
                {
                    employees[j + 1] = employees[j];
                    j = j - 1;
                }
                employees[j + 1] = key;
            }
        }
        /// <summary>
        /// BY NAME
        /// compares two employee objects by their names in ascending order
        /// </summary>
        public class EmployeeNameComparer : IComparer<Employee>
        {
            /// <summary>
            /// compare 2 employeees'name
            /// </summary>
            /// <param name="x">the 1st employee</param>
            /// <param name="y">the 2nd employee</param>
            /// <returns>a negative int if x is less than y
            /// a 0 value if they are equal
            /// a positive int if x is greater than y
            /// </returns>
            public int Compare(Employee x, Employee y)
            {
                return string.Compare(x.GetName(), y.GetName());
            }
        }
        /// <summary>
        /// BY NUMBER ID
        /// compares 2 employees by their number id in ascending order
        /// </summary>
        public class EmployeeNumberComparer : IComparer<Employee>
        {
            /// <summary>
            /// compare 2 employees by their id number
            /// </summary>
            /// <param name="x">the 1st employee's id number</param>
            /// <param name="y">the 2nd employee's id number</param>
            /// <returns>a negative value if x < y, 0 if x = y amd positive if x > y</returns>
            public int Compare(Employee x, Employee y)
            {
                return x.GetNumber().CompareTo(y.GetNumber());
            }
        }
        /// <summary>
        /// PAY RATE
        /// compares 2 employees by their pay rate  in descending order
        /// </summary>
        public class EmployeeRateComparer : IComparer<Employee>
        {
            /// <summary>
            ///  compares 2 employees by their pay rate  in descending order
            /// </summary>
            /// <param name="x">the 1st employee's pay rate</param>
            /// <param name="y">the 2nd employee's pay rate</param>
            /// <returns>a negative value if x < y, 0 if x = y amd positive if x > y</returns>
            public int Compare(Employee x, Employee y)
            {
                return y.GetRate().CompareTo(x.GetRate());
            }
        }
        /// <summary>
        /// BY HOURS
        /// compares 2 employees by their worked hours in descending order
        /// </summary>
        public class EmployeeHoursComparer : IComparer<Employee>
        {
            /// <summary>
            /// compares 2 employees by their worked hours in descending order
            /// </summary>
            /// <param name="x">the 1st employee's hours</param>
            /// <param name="y">the 2nd employee's hours</param>
            /// <returns>a negative value if x < y, 0 if x = y amd positive if x > y</returns>
            public int Compare(Employee x, Employee y)
            {
                // Compare in descending order
                return y.GetHours().CompareTo(x.GetHours());
            }
        }
        /// <summary>
        /// BY GROSS
        /// compare 2 employees by their gross pay
        /// </summary>
        public class EmployeeGrossPayComparer : IComparer<Employee>
        {
            /// <summary>
            /// compares 2 employees by their gross pay in descending order
            /// </summary>
            /// <param name="x">the 1st employee's gross</param>
            /// <param name="y">the 2nd employee's gross</param>
            /// <returns>a negative value if x < y, 0 if x = y amd positive if x > y</returns>
            public int Compare(Employee x, Employee y)
            {
                return y.GetGross().CompareTo(x.GetGross());
            }
        }

        /// <summary>
        /// display a menu of options and then returns the user's choice as output
        /// </summary>
        /// <returns>user's choice in a formatted table of data</returns>
        private static String Menu()
        {
            Console.WriteLine("\n===================================");
            Console.WriteLine("\nMENU OPTIONS:");
            Console.WriteLine("1. Sort by Employee Name (ascending)");
            Console.WriteLine("2. Sort by Employee Number (ascending)");
            Console.WriteLine("3. Sort by Employee Pay Rate (descending)");
            Console.WriteLine("4. Sort by Employee Hours (descending)");
            Console.WriteLine("5. Sort by Employee Gross Pay (descending)");
            Console.WriteLine("6. Exit");
            Console.Write("\nEnter your choice (1-6): ");

            return Console.ReadLine();
        }


        /// <summary>
        /// to read the employee's data from the employee.csv file and then return an array of objects
        /// </summary>
        /// <param name="filename">name of the csv file</param>
        /// <returns>an array of employee objects</returns>
        public static Employee[] Read(string filename)
        {
            List<Employee> employeeList = new List<Employee>();

            try
            {
                //to read the content of the file (filename)
                StreamReader reader = new StreamReader(filename);
                while (!reader.EndOfStream)//read until the end of the file
                {
                    //read the next line from the file and store it in the line var
                    string line = reader.ReadLine();
                    //split the line vars into an array by using ',' then store it in 'parts'
                    string[] parts = line.Split(',');

                    //check if the parts array has 4 elements (name, number, pay rate, hours)
                    if (parts.Length == 4)
                    {
                        //trim the white space from the employee's name
                        string name = parts[0].Trim();
                        //parse the employee's number as an integer
                        int number = int.Parse(parts[1].Trim());
                        //parse the employee's pay rate as a decimal
                        decimal rate = decimal.Parse(parts[2].Trim());
                        //parse the employee's hours as a double value
                        double hours = double.Parse(parts[3].Trim());

                        Employee employee = new Employee(name, number, rate, hours);
                        employeeList.Add(employee);
                    }
                }
            }
            //catch the exception if there's one thrown
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            //convert the employeeList to an array of Employee object and return it
            return employeeList.ToArray();
        }
    }
}
