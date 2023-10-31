﻿using System.Diagnostics;

namespace EFCoreSample
{
    public class Student
    {
        public int StudentId { get; set; }
        public required string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public byte[] Photo { get; set; }
        public decimal Height { get; set; }

        public int GradeId { get; set; }
        public Grade Grade { get; set; }
    }
}
