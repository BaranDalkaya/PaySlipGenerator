using System;

namespace CSProject
{
    class Staff
    {
        private float hourlyRate;
        private int hWorked;
        public int HoursWorked
        {
            get
            {
                return hWorked;
            }
            set
            {
                if (value > 0)
                    hWorked = value;
                else
                    hWorked = 0;
            }
        }


        public float TotalPay { get; protected set; }
        public float BasicPay { get; private set; }
        public string NameOfStaff { get; private set; }

        public Staff(string name, float rate)
        {
            this.NameOfStaff = name;
            this.hourlyRate = rate;
        }

        public virtual void CalculatePay()
        {
            Console.WriteLine("Calculating Pay...");
            BasicPay = hWorked * hourlyRate;
            TotalPay = BasicPay;
        }

        public override string ToString()
        {
            return "Hourly Rate = " + hourlyRate + "\nhWorked = " + hWorked +
                "\nTotal Pay = " + TotalPay + "\nBasic Pay = " + BasicPay +
                "\nName of Staff = " + NameOfStaff;
        }
    }
}