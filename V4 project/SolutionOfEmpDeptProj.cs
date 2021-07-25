using System;
using System.IO;
using System.Text.RegularExpressions;
namespace LoanAgainstGold
{
    class SolutionOfEmpDeptProj
    {
        static void Main(string[] args)
        {
            while (true)
            {
                try
                {
                    Console.WriteLine("1.Insert Employee Info\n2.Insert Department Info\n3.Insert Project Info\n4.Search All Employees by using " +
                        "Department Name\n5.Search All Projects by Employee ID and display\n6.Display Projects based on Department Name\n7.Exit\nEnter Your Choice");
                    int opt = int.Parse(Console.ReadLine());
                    Employee e = new Employee();
                    Department d = new Department();
                    Project p = new Project();
                    string f1 = @"N:\DOTNET_Programming\LoanAgainstGold\LoanAgainstGold\EmployeeInfo.txt";
                    string f2 = @"N:\DOTNET_Programming\LoanAgainstGold\LoanAgainstGold\DeptInfo.txt";
                    string f3 = @"N:\DOTNET_Programming\LoanAgainstGold\LoanAgainstGold\ProjectInfo.txt";
                    if (opt >= 7)
                        System.Environment.Exit(0);
                    switch (opt)
                    {
                        case 1:
                            Console.WriteLine("Enter Employee Details");                                                        
                            var info = new FileInfo(f1);
                            info = new FileInfo(f1);                            
                            if(!info.Exists||info.Length==0)
                            {                                
                                e.setEmployeeData();
                                using (StreamWriter sw = new StreamWriter(f1, true))
                                {
                                    sw.Write(e.ToString() + "\n");
                                    Console.WriteLine("Data is Stored Successfully");
                                    sw.Close();
                                }
                            }
                            else
                            {
                                e.setEmployeeData();
                                bool flag = false;
                                using (var sr = new StreamReader(f1))
                                {
                                    string line = null;
                                    while ((line = sr.ReadLine()) != null)
                                    {
                                        if (line.Contains(e.empid.ToString()))
                                        {
                                            var data = Regex.Match(line, @"\d+").Value;
                                            if (int.Parse(data) == e.empid)
                                            {
                                                flag = true;
                                                Console.WriteLine("You can not store Duplicate Employee ID");
                                                break;
                                            }
                                        }
                                    }
                                }
                                if (flag == false)
                                {                                  
                                    using (StreamWriter sw = new StreamWriter(f1, true))
                                    {
                                        sw.Write(e.ToString() + "\n");
                                        Console.WriteLine("Data is Stored Successfully");
                                        sw.Close();
                                    }
                                }
                            }
                            
                            break;

                        case 2:
                            Console.WriteLine("Enter Department Details");
                            var info1 = new FileInfo(f2);
                            info1 = new FileInfo(f2);                            
                            if(!info1.Exists||info1.Length==3)
                            {                               
                                d.setDepartmentInfo();
                                using (StreamWriter sw1 = new StreamWriter(f2, true))
                                {
                                    sw1.Write(d.ToString() + "\n");
                                    Console.WriteLine("Data is Stored Successfully");
                                    sw1.Close();
                                }
                            }
                            else
                            {                                
                                d.setDepartmentInfo();
                                bool flag = false;
                                using (var sr1 = new StreamReader(f2))
                                {
                                    string line = null;
                                    while ((line = sr1.ReadLine()) != null)
                                    {
                                        if (line.Contains(Department.getDepartmentID().ToString()))
                                        {                                           
                                            var data = Regex.Match(line, @"\d+").Value;
                                            if (int.Parse(data) == Department.getDepartmentID())
                                            {                                                
                                                flag = true;
                                                Console.WriteLine("You can not store Duplicate Department ID");
                                                break;
                                            }
                                        }
                                    }
                                }
                                if (flag == false)
                                {                                  
                                    using (StreamWriter sw1 = new StreamWriter(f2, true))
                                    {
                                        sw1.Write(d.ToString() + "\n");
                                        Console.WriteLine("Data is Stored Successfully");
                                        sw1.Close();
                                    }
                                }
                            }
                            break;

                        case 3:
                            Console.WriteLine("Enter Department Details");
                            var info2 = new FileInfo(f3);
                            info2 = new FileInfo(f3);                            
                            if (!info2.Exists || info2.Length == 3)
                            {
                                p.setProjectData();
                                using (StreamWriter sw2 = new StreamWriter(f3, true))
                                {
                                    sw2.Write(p.ToString() + "\n");
                                    Console.WriteLine("Data is Stored Successfully");
                                    sw2.Close();
                                }
                                using (StreamWriter sw3 = new StreamWriter(@"N:\DOTNET_Programming\LoanAgainstGold\LoanAgainstGold\ProjectCopy.txt", true))
                                {
                                    sw3.Write(p.getData() + "\n");
                                    sw3.Close();
                                }
                            }
                            else
                            {
                                p.setProjectData();
                                bool flag = false;
                                using (var sr2 = new StreamReader(f3))
                                {
                                    string line = null;
                                    while ((line = sr2.ReadLine()) != null)
                                    {                                        
                                        if (line.Contains(p.pid.ToString()))
                                        {
                                            var data = Regex.Match(line, @"\d+").Value;                                            
                                            if (int.Parse(data) == p.pid || int.Parse(data) == p.empid|| int.Parse(data) == p.deptid)
                                            {
                                                flag = true;
                                                Console.WriteLine("You can not store Duplicate");
                                                break;
                                            }
                                        }
                                    }
                                }
                                using (StreamWriter sw3 = new StreamWriter(@"N:\DOTNET_Programming\LoanAgainstGold\LoanAgainstGold\ProjectCopy.txt", true))
                                {
                                    sw3.Write(p.getData() + "\n");
                                    sw3.Close();
                                }
                                if (flag == false)
                                {
                                    using (StreamWriter sw2 = new StreamWriter(f3, true))
                                    {
                                        sw2.Write(p.ToString() + "\n");
                                        Console.WriteLine("Data is Stored Successfully");
                                        sw2.Close();
                                    }
                                }
                            }
                            break;
                        case 4:
                            int id=0;
                            Console.WriteLine("Enter Department Name:");
                            string name = Console.ReadLine();
                            if (f2.Length != 3)
                            {
                                using (var sr2 = new StreamReader(f2))
                                {
                                    string line = null;
                                    while ((line = sr2.ReadLine()) != null)
                                    {
                                        if (line.Contains(name)) { 
                                            var data = Regex.Match(sr2.ReadLine(), @"\d+").Value;
                                            id = int.Parse(data);
                                        }
                                    }
                                }
                                using(var sr=new StreamReader(f1))
                                {
                                    string line = null;
                                    while ((line = sr.ReadLine()) != null)
                                    {
                                        if (line.Contains(id.ToString()))
                                        {                                         
                                                for (int i = 0; i < 4; i++)
                                                    Console.WriteLine(line=sr.ReadLine());
                                                Console.WriteLine();                                                                                      
                                        }
                                    }
                                }
                            }
                            else
                                Console.WriteLine("File Is Empty");
                            break;

                        case 5:
                            Console.WriteLine("Enter Manager ID");
                            int mid = int.Parse(Console.ReadLine());
                            int newd = 0;
                            if (f3.Length != -3)
                            {                                
                                using (var sr2 = new StreamReader(f3))
                                {                                   
                                    string line = null;
                                    while ((line = sr2.ReadLine()) != null)
                                    {
                                        
                                        if (line.Contains(mid.ToString())) { 
                                            var data = Regex.Match(sr2.ReadLine(), @"\d+").Value;
                                            newd = int.Parse(data);
                                        }
                                    }
                                }
                                using(var sr2=new StreamReader(f2))
                                {                                    
                                    string line = null;
                                    while ((line = sr2.ReadLine()) != null)
                                    {                                        
                                        if (line.Contains(newd.ToString()))                                                                                 
                                            Console.WriteLine("This Manager Is Working on this "+sr2.ReadLine()+"\n");                                                                                   
                                    }
                                }
                                using (var sr2 = new StreamReader(f1))
                                {                                   
                                    string line = null;
                                    while ((line = sr2.ReadLine()) != null)
                                    {
                                        if (line.Contains(newd.ToString()))
                                        {
                                            for (int i = 0; i < 4; i++)
                                                Console.WriteLine(line = sr2.ReadLine());
                                            Console.WriteLine();
                                        }
                                    }
                                }
                            }
                            else
                                Console.WriteLine("File Is Empty");
                            break;

                        case 6:
                            Console.WriteLine("Enter Department Name:");
                            string dname = Console.ReadLine();
                            int count = 0;
                            int ddata=0;
                            if (f2.Length != 3)
                            {
                                
                                
                                using (var sr2 = new StreamReader(f2))
                                {
                                    string line = null;
                                    while ((line = sr2.ReadLine()) != null)
                                    {
                                        if (line.Contains(dname))
                                        {
                                            var data = Regex.Match(sr2.ReadLine(), @"\d+").Value;
                                            ddata = int.Parse(data);                                            
                                        }
                                    }
                                }
                                using(var sr2=new StreamReader(@"N:\DOTNET_Programming\LoanAgainstGold\LoanAgainstGold\ProjectCopy.txt"))
                                {
                                    
                                    string line = null;
                                    
                                    while ((line = sr2.ReadLine()) != null)
                                    {
                                         if (line.Contains(ddata.ToString()))
                                        {
                                            Console.WriteLine(line);
                                            for (int i = 0; i < 3; i++)
                                                Console.WriteLine(sr2.ReadLine());
                                        }
                                            
                                    }                                    
                                }
                            }
                            else
                                Console.WriteLine("File Is Empty");
                            break;
                    }    
                }
                catch (Exception e) { }
            }
        }
    }
}
