using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanAgainstGold
{
    class Department
    {
        public static int deptid;
        public int noOfProjects;
        public string deptname;
        Employee e=new Employee();
        public void setDepartmentInfo()
        {
            Console.WriteLine("Enter Department ID:");
            deptid = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Department Name:");
            deptname = Console.ReadLine();
            Console.WriteLine("Enter Number of Project:");
            noOfProjects = int.Parse(Console.ReadLine());
            
            
        }
        public static int getDepartmentID()
        {
            return deptid;
        }
        public override string ToString()
        {
            string s="Dept Name:"+deptname+"\nDept ID:"+deptid+"\nNumber of Projects:"+noOfProjects;
            return s;
        }
    }
}
