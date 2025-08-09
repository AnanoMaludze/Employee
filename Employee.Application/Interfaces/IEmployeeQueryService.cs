using Employee.Application.Models;

namespace Employee.Application.Interfaces
{
    public interface IEmployeeQueryService
    {
        Task<EmployeeDto?> GetEmployeeHierarchyAsync(int rootId);
    }
}
