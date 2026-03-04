using SmartPortfolio.Application.Abstractions.Repositories;
using SmartPortfolio.Application.Abstractions.Services;
using SmartPortfolio.Application.DTOs;
using SmartPortfolio.Domain.Entities;

namespace SmartPortfolio.Persistance.Implementations.Services;

public class PortfolioService:IPortfolioService
{
    private readonly IPortfolioRepository _repository;

    public PortfolioService(IPortfolioRepository repository)
    {
        _repository = repository;
    }


    public async Task<IEnumerable<StudentDetailDto>> GetFilteredPortfoliosAsync(PortfolioSearchRequest request)
    {
        var students = await _repository.SearchPortfoliosAsync(request);

        return students.Select(s => new StudentDetailDto
        {
            StudentId = s.StudentId,
            Advisor = s.Advisor,
            CourseName = s.CourseName,
            AcademicYear = s.AcademicYear,
            ImageUrls = s.VisualAssets.Select(v => v.ImageCloudUrl ?? "").ToList(),
            PdfUrl = s.PdfUrl
            
        });
    }
}