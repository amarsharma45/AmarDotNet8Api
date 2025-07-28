﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmarDotNet8Api_Core.Entities
{
    public class Employee
    {
        public int EmployeeID { get; set; }               
        public string? FirstName { get; set; }            
        public string? LastName { get; set; }             
        public string? Email { get; set; }                
        public string? Department { get; set; }           
        public decimal? Salary { get; set; }              
        public DateTime? JoiningDate { get; set; }       
    }
}
