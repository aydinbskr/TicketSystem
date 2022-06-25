using Castle.DynamicProxy;
using FluentValidation;
using TicketSystem.Core.CrossCuttingConcerns.Validation;
using TicketSystem.Core.Utilities.Interceptors;

namespace TicketSystem.Core.Aspects.Autofac
{
    public class ValidationAspect : MethodInterception
    {
        private Type _validatorType;
        public ValidationAspect(Type validatorType)
        {
            if (!typeof(IValidator).IsAssignableFrom(validatorType))//It is only for FluentValidation Profiles
            {
                throw new System.Exception();
            }

            _validatorType = validatorType;
        }
        protected override void OnBefore(IInvocation invocation)
        {
            var validator = (IValidator)Activator.CreateInstance(_validatorType)!;
            var entityType = _validatorType.BaseType!.GetGenericArguments()[0];
            var entities = invocation.Arguments.Where(t => t.GetType() == entityType);
            foreach (var entity in entities)
            {
                ValidationTool.Validate(validator, entity);
            }
        }
    }
}
