using System;
using System.Collections.Generic;
using System.IO;

namespace CSProject
{
    class FileReader
    {
        public List<Staff> ReadFile()
        {
            List<Staff> myStaff = new List<Staff>();
            string[] result = new string[2];
            string path = "Staff.txt";
            string[] separator = { ", " };

            if (File.Exists(path))
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    while (!sr.EndOfStream)
                    {
                        string line = sr.ReadLine();
                        result = line.Split(separator, StringSplitOptions.None);

                        string name = result[0];
                        string staffType = result[1];

                        if (staffType == "Manager")
                            myStaff.Add(new Manager(name));
                        else if (staffType == "Admin")
                            myStaff.Add(new Admin(name));
                    }
                    sr.Close();
                }
            }
            else
                Console.WriteLine("File does not exist");

            return myStaff;
        }
    }
}