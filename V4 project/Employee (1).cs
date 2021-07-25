using System;
using System.IO;
namespace LoanAgainstGold
{
    class Employee
    {
        public int empid;
        public static int  deptid;
        public string empname, empemail;
        public long empphoneno;
        public int getDeptID()
        {
            return deptid;
        }
        public void setEmployeeData()
        {
            Console.WriteLine("Enter ID :");
            empid = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Name :");
            empname=Console.ReadLine();
            Console.WriteLine("Enter Email :");
            empemail = Console.ReadLine();
            Console.WriteLine("Enter Phone No :");
            empphoneno = long.Parse(Console.ReadLine());
            Console.WriteLine("Enter Department ID :");
            deptid = int.Parse(Console.ReadLine());
        }
        public override string ToString()
        {
            string s ="Department No:" + deptid + "\nName:" + empname + "\nEmail:" + empemail + "\nPhone No:" + empphoneno + "\nEmp ID:"+empid;
            return s;
        }
    }
}
