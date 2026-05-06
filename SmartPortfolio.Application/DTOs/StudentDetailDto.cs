namespace SmartPortfolio.Application.DTOs;

public class StudentDetailDto
{
    public int StudentId { get; set; }
    public string? AcademicYear { get; set; }
    public string? CourseName { get; set; }
    public string? Advisor { get; set; }
    public string? PdfUrl { get; set; }
    public List<string> ImageUrls { get; set; } = new();
}