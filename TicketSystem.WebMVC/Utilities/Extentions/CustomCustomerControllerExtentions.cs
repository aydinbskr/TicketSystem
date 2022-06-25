using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TicketSystem.Business.Abstract;
using TicketSystem.Entities.Dtos;
using TicketSystem.Entities.SystemEntities;

namespace TicketSystem.WebMVC.Utilities.Extentions
{
    public static class CustomCustomerControllerExtentions
    {
        public static async Task<IActionResult> UpdateUserAsync(this ControllerBase controller, ICustomerService customerService, IMapper mapper, CustomerUpdateDto customerUpdateDto, int customerId)
        {
            customerUpdateDto.CustomerId = customerId;
            var customer = mapper.Map<Customer>(customerUpdateDto);
            var result = await customerService.UpdateAsync(customer);
            if (result.Success)
            {
                return controller.RedirectToAction("GetProfile");
            }
            return controller.RedirectToAction("Update");
        }
        public static async Task<IActionResult> BuyTicket(this ControllerBase controllerBase, BuyTicketDto buyTicketDto, int customerId, ITicketService ticketService, ISeatService seatService, ISessionService sessionService)
        {
            var result = await sessionService.CheckSeat(buyTicketDto.SessionId, buyTicketDto.SeatNumber);
            if (!result.Success)
            {
                return controllerBase.RedirectToAction("GetAll", "Movie");
            }
            var session = await sessionService.GetByIdAsync(buyTicketDto.SessionId);
            Seat seat = new Seat { SceneId = session.Data.SceneId, SeatNumber = buyTicketDto.SeatNumber, SessionId = buyTicketDto.SessionId };
            var seatResult = await seatService.CreateAsync(seat);

            if (seatResult.Success)
            {
                Ticket ticket = new Ticket { SessionId = session.Data.SessionId, Price = buyTicketDto.Price, CustomerId = customerId};
                var ticketResult = await ticketService.CreateAsync(ticket);
                if (ticketResult.Success)
                {
                    return controllerBase.RedirectToAction("GetProfile");
                }
            }

            return controllerBase.RedirectToAction("GetAll", "Movie");
        }

    }
}
