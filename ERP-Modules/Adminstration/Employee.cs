using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Adminstration
{
    internal class Employee:EmployeeGrade
    {
        public int EmployeeId { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string BloodGroup { get; set; }
        public string ContactNo { get; set; }
        public DateTime DateofJoining { get; set; }

       

        internal Employee(int employeeId):base()
        {
            this.EmployeeId = employeeId;
        }



        // with object
        Department department = new Department();
        EmployementType employementType = new EmployementType();
        //EmployeeType employeeType = new EmployeeType();

        
        internal void EmployeeDetails(EmployeeType employeeType, EmployementType employementType,Department department)
        {
            
            Console.WriteLine("     Name               ID          Age      B-Group        DateofJoin               ContactInfo             EmployeeType            EmployementType                 Department");
            Console.WriteLine($"{Name}      {EmployeeId}      {Age}         {BloodGroup}       {DateofJoining}        {ContactNo}            {employeeType.Type}        {employementType}      ");
        }

    }
}

