namespace FastFood.Core.MappingConfiguration;

using AutoMapper;

using Models;
using ViewModels.Categories;
using ViewModels.Employees;
using ViewModels.Items;
using ViewModels.Orders;
using ViewModels.Positions;

public class FastFoodProfile : Profile
{
    public FastFoodProfile()
    {
        //Positions
        CreateMap<CreatePositionInputModel, Position>()
            .ForMember(x => x.Name, y => y.MapFrom(s => s.PositionName));

        CreateMap<Position, PositionsAllViewModel>();

        //Categories
        CreateMap<CreateCategoryInputModel, Category>()
            .ForMember(c => c.Name, opt => opt.MapFrom(vm => vm.CategoryName));

        CreateMap<Category, CategoryAllViewModel>();

        //Employees
        CreateMap<Position, RegisterEmployeeViewModel>()
            .ForMember(vm => vm.PositionId, opt => opt.MapFrom(p => p.Id));

        CreateMap<RegisterEmployeeInputModel, Employee>();
        CreateMap<Employee, EmployeesAllViewModel>();

        //Items
        CreateMap<Category, CreateItemViewModel>()
            .ForMember(m => m.CategoryId, opt => opt.MapFrom(c => c.Id));

        CreateMap<CreateItemInputModel, Item>();
        CreateMap<Item, ItemsAllViewModels>();

        //Orders
        CreateMap<CreateOrderInputModel, Order>();

        CreateMap<Order, OrderAllViewModel>()
            .ForMember(m => m.OrderId, opt => opt.MapFrom(o => o.Id));
    }
}