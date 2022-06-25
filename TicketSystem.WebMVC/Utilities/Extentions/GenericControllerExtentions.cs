using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TicketSystem.Core.Abstract.Entities;
using TicketSystem.Core.Utilities.Results;

namespace TicketSystem.WebMVC.Utilities.Extentions
{
    public static class GenericControllerExtentions
    {
        public static IActionResult List<TListDto, TEntity>(this Controller controller, IDataResult<List<TEntity>> dataResult, IMapper mapper)
            where TListDto : class, IDto
            where TEntity : class, IEntity
        {
            if (dataResult.Success)
            {
                var movieListDto = mapper.Map<List<TListDto>>(dataResult.Data);
                return controller.View(movieListDto);
            }
            return controller.Content(dataResult.Message);
        }

        

    }
}
