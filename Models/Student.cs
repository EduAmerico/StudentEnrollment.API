using System;

namespace StudentEnrollment.API.Models
{
    public class Student
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public string Email { get; set; }
        public string RA { get; set; }
        public string CPF { get; set; }
        public DateTime EnrollmentDate { get; set; } = DateTime.Now;
    }
}
