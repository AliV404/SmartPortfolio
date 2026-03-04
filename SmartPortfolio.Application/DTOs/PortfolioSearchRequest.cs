namespace SmartPortfolio.Application.DTOs;

public class PortfolioSearchRequest
{
    public string? StudentId { get; set; }
    public string? AdvisorName { get; set; }
    public string? CourseName { get; set; }
    public string? AcademicYear { get; set; }
    public string? VisualType { get; set; }
}