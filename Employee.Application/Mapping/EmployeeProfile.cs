using AutoMapper;
using Employee.Application.Models;
using Employee.Domain.Entities;

namespace Employee.Application.Mapping
{
    public class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        {
            CreateMap<Employees, EmployeeDto>()
                .ForMember(dest => dest.Subordinates, opt => opt.MapFrom(src => src.Subordinates));

        }
    }
}
