using AutoMapper;
using MetroChefApp.API.Models;
using MetroChefApp.API.DTOs;

namespace MetroChefApp.API.Helpers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {

            CreateMap<User, UserDto>()
                .ForMember(dest => dest.Roles, opt => opt.MapFrom(src => src.UserRoles.Select(ur => ur.Role)));

            CreateMap<Role, RoleDto>();

            CreateMap<Category, CategoryDto>();
            CreateMap<CategoryCreateDto, Category>();
            CreateMap<FoodItemCreateDto, FoodItem>();
            CreateMap<FoodItem, FoodItemDto>();

            CreateMap<Order, OrderDto>();
            CreateMap<OrderItem, OrderItemDto>();
            CreateMap<OrderStatusHistory, OrderStatusDto>();

            CreateMap<Employee, EmployeeDto>();
            CreateMap<WorkRoster, WorkRosterDto>();
            CreateMap<Salary, SalaryDto>();

            CreateMap<Delivery, DeliveryDto>();
        }
    }
}
