using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TicketSystem.Business.Abstract;
using TicketSystem.Entities.Dtos;
using TicketSystem.Entities.SystemEntities;

namespace TicketSystem.WebMVC.Utilities.Extentions
{
    public static class CustomEmployeeControllerExtentions
    {
        public static async Task<IActionResult> UpdateUserAsync(this ControllerBase controller, IEmployeeService employeeService, IMapper mapper, EmployeeUpdateDto employeeUpdateDto, int employeeId)
        {
            employeeUpdateDto.EmpoyeeId = employeeId;
            var employee = mapper.Map<Employee>(employeeUpdateDto);
            var result = await employeeService.UpdateAsync(employee);
            if (result.Success)
            {
                return controller.RedirectToAction("GetProfile");
            }
            return controller.RedirectToAction("Update");
        }

    }
}
