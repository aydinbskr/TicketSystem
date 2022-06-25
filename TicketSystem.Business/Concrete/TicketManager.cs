using TicketSystem.Business.Abstract;
using TicketSystem.Business.Utilities.ValidationRules;
using TicketSystem.Core.Aspects.Autofac;
using TicketSystem.Core.Utilities.Results;
using TicketSystem.DataAccess.Abstract.Dal;
using TicketSystem.Entities.SystemEntities;

namespace TicketSystem.Business.Concrete
{
    public class TicketManager : ITicketService
    {
        readonly ITicketDal _ticketDal;

        public TicketManager(ITicketDal ticketDal)
        {
            _ticketDal = ticketDal;
        }

        [ValidationAspect(typeof(TicketValidationRules))]
        public async Task<IDataResult<Ticket>> CreateAsync(Ticket ticket)
        {
            var addedTicket = await _ticketDal.CreateAsync(ticket);
            if (addedTicket != null)
            {
                return new SuccessDataResult<Ticket>(addedTicket);
            }
            return new ErrorDataResult<Ticket>();
        }

        public async Task<IDataResult<List<Ticket>>> GetAllAsync()
        {
            var list = await _ticketDal.GetAllAsync();
            if (list != null)
            {
                return new SuccessDataResult<List<Ticket>>(list);
            }
            return new ErrorDataResult<List<Ticket>>();
        }

        public async Task<IDataResult<List<Ticket>>> GetAllTicketOfUser(int id)
        {
            var list = await _ticketDal.GetAllTicketsOfUser(id);
            if (list != null)
            {
                return new SuccessDataResult<List<Ticket>>(list);
            }
            return new ErrorDataResult<List<Ticket>>();
        }

        public async Task<IDataResult<Ticket>> GetByIdAsync(int id)
        {
            var ticket = await _ticketDal.GetByFilterAsync(t => t.TicketId == id);
            if (ticket != null)
            {
                return new SuccessDataResult<Ticket>(ticket);
            }
            return new ErrorDataResult<Ticket>();
        }

        public async Task<IResult> RemoveAsync(Ticket ticket)
        {
            _ticketDal.Remove(ticket);
            return await Task.FromResult(new SuccessResult());
        }

        [ValidationAspect(typeof(TicketValidationRules))]
        public async Task<IDataResult<Ticket>> UpdateAsync(Ticket ticket)
        {
            var updatedTicket = _ticketDal.Update(ticket);
            return await Task.FromResult(new SuccessDataResult<Ticket>(updatedTicket));
        }
    }
}
