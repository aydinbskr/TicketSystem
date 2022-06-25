using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TicketSystem.Business.Abstract;
using TicketSystem.Entities.Dtos;

namespace TicketSystem.WebMVC.Utilities.Extentions
{
    public static class CustomAuthControllerExtentişons
    {
        public static async Task<List<Claim>> CreateUser(this ControllerBase controllerBase, IAuthService authService, IMapper mapper, UserCreateDto userCreateDto, int type)
        {
            var claims = new List<Claim>();
            if (userCreateDto != null)
            {

                switch (type)
                {
                    case 1:
                        var employeeDto = mapper.Map<EmployeeCreateDto>(userCreateDto);
                        claims = (await authService.CreateEmployee(employeeDto)).Data;
                        break;

                    case 2:
                        var customerDto = mapper.Map<CustomerCreateDto>(userCreateDto);
                        claims = (await authService.CreateCustomer(customerDto)).Data;
                        break;
                    default:
                        break;
                }

            }
            return claims;
        }
    }
}
