using AutoMapper;
using Employee.Application.Interfaces;
using Employee.Application.Models;
using Employee.Domain.Entities;
using Employee.Infrastructure;
using Microsoft.EntityFrameworkCore;


namespace Employee.Application.Services
{
    public class EmployeeQueryService : IEmployeeQueryService
    {
        private readonly EmployeeDbContext _context;
        private readonly IMapper _mapper;

        public EmployeeQueryService(EmployeeDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<EmployeeDto?> GetEmployeeHierarchyAsync(int rootId)
        {
            var employee = await _context.Employees
                .Include(e => e.Subordinates)
                .FirstOrDefaultAsync(e => e.Id == rootId);

            if (employee == null)
                return null;

            return await BuildHierarchyAsync(employee);
        }

        private async Task<EmployeeDto> BuildHierarchyAsync(Employees employee)
        {
            var dto = _mapper.Map<EmployeeDto>(employee);

            // Recursively fetch subordinates
            dto.Subordinates = new List<EmployeeDto>();
            foreach (var sub in employee.Subordinates)
            {
                var subWithChildren = await _context.Employees
                    .Include(e => e.Subordinates)
                    .FirstOrDefaultAsync(e => e.Id == sub.Id);

                if (subWithChildren != null)
                {
                    dto.Subordinates.Add(await BuildHierarchyAsync(subWithChildren));
                }
            }

            return dto;
        }
    }
}
