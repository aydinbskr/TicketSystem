using TicketSystem.Business.Abstract;
using TicketSystem.Business.Utilities.ValidationRules;
using TicketSystem.Core.Aspects.Autofac;
using TicketSystem.Core.Utilities.Results;
using TicketSystem.DataAccess.Abstract.Dal;
using TicketSystem.Entities.SystemEntities;

namespace TicketSystem.Business.Concrete
{
    public class CostumerManager : ICustomerService
    {
        readonly ICustomerDal _customerDal;

        public CostumerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }

        [ValidationAspect(typeof(CustomerValidationRules))]
        public async Task<IDataResult<Customer>> CreateAsync(Customer customer)
        {
            var addedCustomer = await _customerDal.CreateAsync(customer);
            if (addedCustomer != null)
            {
                return new SuccessDataResult<Customer>(customer);
            }
            return new ErrorDataResult<Customer>();
        }

        public async Task<IDataResult<List<Customer>>> GetAllAsync()
        {
            var list = await _customerDal.GetAllAsync();
            if (list != null)
            {
                return new SuccessDataResult<List<Customer>>(list);
            }
            return new ErrorDataResult<List<Customer>>();
        }

        public async Task<IDataResult<Customer>> GetByIdAsync(int id)
        {
            var customer = await _customerDal.GetByFilterAsync(c => c.CustomerId == id);
            if (customer != null)
            {
                return new SuccessDataResult<Customer>(customer);
            }
            return new ErrorDataResult<Customer>();
        }

        public async Task<IDataResult<Customer>> GetUserByEMailAsync(string mail)
        {
            var result = await _customerDal.GetUserByEMailAsync(mail);
            if (result != null)
            {
                return new SuccessDataResult<Customer>(result);
            }
            return new ErrorDataResult<Customer>();
        }

        public async Task<IResult> RemoveAsync(Customer customer)
        {
            _customerDal.Remove(customer);
            return await Task.FromResult(new SuccessResult());
        }

        [ValidationAspect(typeof(CustomerValidationRules))]
        public async Task<IDataResult<Customer>> UpdateAsync(Customer customer)
        {
            var updatedCustomer = _customerDal.Update(customer);
            return await Task.FromResult(new SuccessDataResult<Customer>(updatedCustomer));
        }
    }
}
