using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeTracking.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeId {get; set;}

        [Required]
        public string FirstName {get; set;}
        
        [Required]
        public string LastName {get; set;}

        public DateTime CreatedAt {get; set;} = DateTime.Now;

        public DateTime UpdatedAt {get; set;} = DateTime.Now;

        [Required]
        public int DepartmentId {get; set;}
        // Add navigation property for which department the Employee is under

        public Department Department {get; set;}
    }
}