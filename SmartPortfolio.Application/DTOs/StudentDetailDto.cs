namespace SmartPortfolio.Application.DTOs;

public class StudentDetailDto
{
    public string StudentId { get; set; } = null!;
    public string? AcademicYear { get; set; }
    public string? CourseName { get; set; }
    public string? Advisor { get; set; }
    public string? PdfUrl { get; set; }
    public List<string> ImageUrls { get; set; } = new();
}