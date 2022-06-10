﻿namespace MVCWebApp.Models
{
    // mvc model class
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }
        public int? Age { get; set; }
        public int? Salary { get; set; }
    }
}
