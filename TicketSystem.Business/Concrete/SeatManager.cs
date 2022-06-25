using TicketSystem.Business.Abstract;
using TicketSystem.Business.Utilities.ValidationRules;
using TicketSystem.Core.Aspects.Autofac;
using TicketSystem.Core.Utilities.Results;
using TicketSystem.DataAccess.Abstract.Dal;
using TicketSystem.Entities.SystemEntities;

namespace TicketSystem.Business.Concrete
{
    public class SeatManager : ISeatService
    {
        readonly ISeatDal _seatDal;

        public SeatManager(ISeatDal seatDal)
        {
            _seatDal = seatDal;
        }

        [ValidationAspect(typeof(SeatValidationRules))]
        public async Task<IDataResult<Seat>> CreateAsync(Seat seat)
        {
            var addedSeat = await _seatDal.CreateAsync(seat);
            if (addedSeat != null)
            {
                return new SuccessDataResult<Seat>(addedSeat);
            }
            return new ErrorDataResult<Seat>();
        }

        public async Task<IDataResult<List<Seat>>> GetAllAsync()
        {
            var list = await _seatDal.GetAllAsync();
            if (list != null)
            {
                return new SuccessDataResult<List<Seat>>(list);
            }
            return new ErrorDataResult<List<Seat>>();

        }

        public async Task<IDataResult<Seat>> GetByIdAsync(int id)
        {
            var seat = await _seatDal.GetByFilterAsync(s => s.SeatId == id);
            if (seat != null)
            {
                return new SuccessDataResult<Seat>(seat);
            }
            return new ErrorDataResult<Seat>();
        }
        public async Task<IDataResult<List<Seat>>> GetBySceneIdAsync(int id)
        {
            var seats = await _seatDal.GetAllAsync(s => s.SceneId == id);
            if (seats != null)
            {
                return new SuccessDataResult<List<Seat>>(seats);
            }
            return new ErrorDataResult<List<Seat>>();
        }
        public async Task<IResult> RemoveAsync(Seat seat)
        {
            _seatDal.Remove(seat);
            return await Task.FromResult(new SuccessResult());
        }

        [ValidationAspect(typeof(SeatValidationRules))]
        public async Task<IDataResult<Seat>> UpdateAsync(Seat seat)
        {
            var updatedSeat = _seatDal.Update(seat);
            return await Task.FromResult(new SuccessDataResult<Seat>(updatedSeat));
        }
    }
}
