using System;

namespace StudentEnrollment.API.Models
{
    public class Student
    {
    public Guid Id { get; set; } // ID como chave primária
    public string Name { get; set; } = string.Empty; // Inicializar com valor padrão
    public string Email { get; set; } = string.Empty;
    public string RA { get; set; } = string.Empty;
    public string CPF { get; set; } = string.Empty;
    public DateTime EnrollmentDate { get; set; } = DateTime.Now;
    }
}
