using SmartPortfolio.Application.DTOs;
using SmartPortfolio.Domain.Entities;

namespace SmartPortfolio.Application.Abstractions.Services;

public interface IPortfolioService
{
    Task<IEnumerable<StudentDetailDto>> GetFilteredPortfoliosAsync(PortfolioSearchRequest request);
}