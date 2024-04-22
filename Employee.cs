//
//I, XUAN HUY PHAM, 000899551 certify that this material is my original work.  No other person's work has been used without due acknowledgement.
//
using System;
namespace Lab1
{
    /// <summary>
    /// this class represents an employee's info (name, number, payrate, hours and gross)
    /// </summary>
    public class Employee
    {
        private String name;
        private int number;
        private Decimal rate;
        private Double hours;
        private Decimal gross;

        /// <summary>
        /// this initializes employee construction
        /// </summary>
        /// <param name="name">name of the employee</param>
        /// <param name="number">their number id</param>
        /// <param name="rate">their pay rate</param>
        /// <param name="hours">their working hours</param>
        /// this constuctor is also used to calculate their gross
        public Employee(String name, int number, Decimal rate, Double hours)
        {
            this.name = name;
            this.number = number;
            this.rate = rate;
            this.hours = hours;
            CalculateGross();
        }

        /// <summary>
        /// to calculate the pay gross of ther employee
        /// </summary>
        /// <returns></returns>
        public Decimal GetGross()
        {
            return gross;
        }

        /// <summary>
        /// to get the hours that the employee worked
        /// </summary>
        /// <returns></returns>
        public Double GetHours()
        {
            return hours;
        }

        /// <summary>
        /// to get employee's name
        /// </summary>
        /// <returns></returns>
        public String GetName()
        {
            return name;
        }

        /// <summary>
        /// to get employee's number id
        /// </summary>
        /// <returns></returns>
        public int GetNumber()
        {
            return number;
        }

        /// <summary>
        /// to get employee's pay rate
        /// </summary>
        /// <returns></returns>
        public Decimal GetRate()
        {
            return rate;
        }

        /// <summary>
        /// overrides the ToString to display employee's info
        /// </summary>
        /// <returns> formatted information of the employee</returns>
        public override string ToString()
        {
            return $"{name,-25} {number,-15} {rate,-10:F2} {hours,-10:F2} {gross,-10:F2}";
        }

        /// <summary>
        /// to set the hours that the employee worked and also to calculate the gross pay
        /// </summary>
        /// <param name="hours"></param>
        public void SetHours(Double hours)
        {
            this.hours = hours;
            CalculateGross();
        }

        /// <summary>
        /// to set name of the employee
        /// </summary>
        /// <param name="name"></param>
        public void SetName(String name)
        {
            this.name = name;
        }

        /// <summary>
        /// to set the number id of the employee
        /// </summary>
        /// <param name="number"></param>
        public void SetNumber(int number)
        {
            this.number = number;
        }

        /// <summary>
        /// to set the pay rate of the employee and calculate the gross pay
        /// </summary>
        /// <param name="rate"></param>
        public void SetRate(Decimal rate)
        {
            this.rate = rate;
            CalculateGross();
        }

        /// <summary>
        /// to calculate the gross pay based on the formula rate*hours 
        /// and at time and a half for whoever worked more than 40 hours
        /// </summary>
        private void CalculateGross()
        {
            Decimal overtimeRate = rate * 1.5m;
            if (hours <= 40)
                gross = rate * (Decimal)hours;
            else
                gross = rate * 40 + overtimeRate * (Decimal)(hours - 40);
        }
    }
}
