using TicketSystem.Core.Utilities.Results;
using TicketSystem.Entities.Dtos.MovieDtos;
using TicketSystem.Entities.SystemEntities;

namespace TicketSystem.Business.Abstract
{
    public interface IMovieService : IGenericService<Movie>
    {
        IDataResult<MovieDetailDto> GetMovieDetailAsync(int id);
        IDataResult<List<Movie>> GetMovieByFilters(string movieName = null, int? categoyId = null, DateTime? vdate = null);
    }
}
