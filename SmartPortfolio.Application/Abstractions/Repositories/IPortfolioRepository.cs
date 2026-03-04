using SmartPortfolio.Application.DTOs;
using SmartPortfolio.Domain.Entities;

namespace SmartPortfolio.Application.Abstractions.Repositories;

public interface IPortfolioRepository
{
    Task<IEnumerable<Student>> SearchPortfoliosAsync(PortfolioSearchRequest request);
}