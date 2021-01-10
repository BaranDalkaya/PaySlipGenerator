using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CSProject
{
    class PaySlip
    {
        private int month;
        private int year;

        enum MonthsOfYear
        {
            JAN = 1, FEB, MAR, APR, MAY, JUN, JUL, AUG, SEPT, OCT, NOV, DEC
        }

        public PaySlip(int payMonth, int payYear)
        {
            month = payMonth;
            year = payYear;
        }

        public void GeneratePaySlip(List<Staff> myStaff)
        {
            string path;

            foreach (Staff f in myStaff)
            {
                path = f.NameOfStaff + ".txt";
                StreamWriter sw = new StreamWriter(path);
                sw.WriteLine("PAYSLIP FOR {0} {1}", (MonthsOfYear)month, year);
                sw.WriteLine("================================");
                sw.WriteLine("Name of Staff: {0}", f.NameOfStaff);
                sw.WriteLine("Hours Worked: {0}", f.HoursWorked);
                sw.WriteLine("");
                sw.WriteLine("Basic Pay: {0:C}", f.BasicPay);
                if (f.GetType() == typeof(Manager))
                    sw.WriteLine("Allowance: {0:C}", ((Manager)f).Allowance);
                else
                    sw.WriteLine("Overtime Pay: {0:C}", ((Admin)f).Overtime);
                sw.WriteLine("");
                sw.WriteLine("================================");
                sw.WriteLine("Total Pay: {0:C}", f.TotalPay);
                sw.WriteLine("================================");
                sw.Close();
            }

        }

        public void GenerateSummary(List<Staff> myStaff)
        {
            var result =
            from staffMem in myStaff
            where staffMem.HoursWorked < 10
            orderby staffMem.HoursWorked ascending
            select new { staffMem.NameOfStaff, staffMem.HoursWorked };

            string path = "summary.txt";
            StreamWriter sw = new StreamWriter(path);
            sw.WriteLine("Staff with less than 10 working hours");
            foreach (var staffMem in result)
            {
                sw.WriteLine("");
                sw.WriteLine("Name of Staff: {0}, Hours Worked: {1}",
                    staffMem.NameOfStaff, staffMem.HoursWorked);
            }
            sw.Close();
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}