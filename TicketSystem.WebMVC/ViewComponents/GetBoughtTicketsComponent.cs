using Microsoft.AspNetCore.Mvc;
using TicketSystem.Business.Abstract;

namespace TicketSystem.WebMVC.ViewComponents
{
    public class GetBoughtTicketsComponent : ViewComponent
    {
        ITicketService _ticketService;

        public GetBoughtTicketsComponent(ITicketService ticketService)
        {
            _ticketService = ticketService;
        }

        public async Task<IViewComponentResult> InvokeAsync(int CustomerId)
        {
            var result = await _ticketService.GetAllTicketOfUser(CustomerId);
            return View("GetBoughtTicketsComponent", result);
        }
    }
}
