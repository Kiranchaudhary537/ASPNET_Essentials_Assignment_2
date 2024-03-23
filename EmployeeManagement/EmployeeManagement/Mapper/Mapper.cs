using AutoMapper;
using EmployeeManagement.Dtos;
using EmployeeManagement.Models;

namespace EmployeeManagement.Mapper
{
    public class Mapper:Profile
    {
        public Mapper()
        {
            CreateMap<Employee, EmployeeDto>();
            CreateMap<Department, DepartmentDto>();
        }
    }
}
