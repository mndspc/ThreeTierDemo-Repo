using System;
using System.Collections.Generic;
using DEL;
using DAL;

namespace App
{
    class Program
    {
        static void Main(string[] args)
        {
            EmpMasterDAL empMasterDAL = new EmpMasterDAL();
            Console.Write("1.Save Employee 2.Delete Employee 3.Update Employee 4.Select Employee 5.Show all Employees:");
            int response = int.Parse(Console.ReadLine());

            switch (response)
            {
                case 1:
                    EmpMaster empMaster1 = new EmpMaster { EmpCode = 123, EmpName = "Scott", DateOfBirth = DateTime.Parse("1980-02-03"), Email = "scott@gmail.com", DeptCode = 101 };
                    Console.WriteLine(empMasterDAL.Save(empMaster1) ? "Employee Info. Saved" : "Erorr");
                    break;
                case 2:
                    var EmpCode = 3;
                    Console.WriteLine(empMasterDAL.Delete(EmpCode) ? "Employee Info. Deleted" : "Erorr");
                    break;
                case 3:
                    break;
                case 4:
                    var EmpCode1 = 2;
                  
                    break;
                case 5:
                  
                    break;
            }
            
         
            Console.ReadLine();
        }
    }
}
