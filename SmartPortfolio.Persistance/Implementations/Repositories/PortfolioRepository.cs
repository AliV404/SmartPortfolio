using Microsoft.EntityFrameworkCore;
using SmartPortfolio.Application.Abstractions.Repositories;
using SmartPortfolio.Application.DTOs;
using SmartPortfolio.Domain.Entities;
using SmartPortfolio.Persistance.Data;

namespace SmartPortfolio.Persistance.Implementations.Repositories;

public class PortfolioRepository:IPortfolioRepository
{
    private readonly AppDbContext _context;

    public PortfolioRepository(AppDbContext context)
    {
        _context = context;
    }
    public async Task<IEnumerable<Student>> SearchPortfoliosAsync(PortfolioSearchRequest request)
    {
        // 1. including the images
        var query = _context.Students
            .Include(s => s.VisualAssets)
            .AsQueryable();
        
        if (!string.IsNullOrWhiteSpace(request.StudentId))
        {
            query = query.Where(s => s.StudentId == request.StudentId);
        }
        // 2. Apply filters dynamically
        if (!string.IsNullOrWhiteSpace(request.AdvisorName))
        {
            query = query.Where(s => s.Advisor == request.AdvisorName);
        }

        if (!string.IsNullOrWhiteSpace(request.CourseName))
        {
            query = query.Where(s => s.CourseName == request.CourseName);
        }

        if (!string.IsNullOrWhiteSpace(request.AcademicYear))
        {
            query = query.Where(s => s.AcademicYear == request.AcademicYear);
        }
    
        // Filtering by image type (joined table)
        if (!string.IsNullOrWhiteSpace(request.VisualType))
        {
            query = query.Where(s => s.VisualAssets.Any(v => v.VisualType == request.VisualType));
        }

        // 3. Execute the query and return results
        return await query.ToListAsync();
    }
}