using AutoMapper;
using TicketSystem.Entities.Dtos;
using TicketSystem.Entities.SystemEntities;

namespace TicketSystem.Business.Utilities.Profiles
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<Customer, CustomerCreateDto>().ReverseMap();
            CreateMap<Customer, CustomerListingDto>().ReverseMap();
            CreateMap<Customer, CustomerUpdateDto>().ReverseMap();

            CreateMap<Employee, EmployeeCreateDto>().ReverseMap();
            CreateMap<Employee, EmployeeListingDto>().ReverseMap();
            CreateMap<Employee, EmployeeUpdateDto>().ReverseMap();

            CreateMap<Movie, MovieCreateDto>().ReverseMap();
            CreateMap<Movie, MovieListingDto>().ReverseMap();
            CreateMap<Movie, MovieUpdateDto>().ReverseMap();
            CreateMap<MovieListingDto, MovieUpdateDto>().ReverseMap();

            CreateMap<Scene, SceneCreateDto>().ReverseMap();
            CreateMap<Scene, SceneListingDto>().ReverseMap();
            CreateMap<Scene, SceneUpdateDto>().ReverseMap();

            CreateMap<Seat, SeatCreateDto>().ReverseMap();
            CreateMap<Seat, SeatListingDto>().ReverseMap();
            CreateMap<Seat, SeatUpdateDto>().ReverseMap();

            CreateMap<Session, SessionCreateDto>().ReverseMap();
            CreateMap<Session, SessionListingDto>().ReverseMap();
            CreateMap<Session, SeatUpdateDto>().ReverseMap();

            CreateMap<Ticket, TicketCreateDto>().ReverseMap();
            CreateMap<Ticket, TicketListingDto>().ReverseMap();
            CreateMap<Ticket, TicketUpdateDto>().ReverseMap();

            CreateMap<UserCreateDto, EmployeeCreateDto>().ReverseMap();
            CreateMap<UserCreateDto, CustomerCreateDto>().ReverseMap();

        }
    }
}
