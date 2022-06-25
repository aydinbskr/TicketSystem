using TicketSystem.Core.Abstract.Dal;
using TicketSystem.Entities.Dtos.MovieDtos;
using TicketSystem.Entities.SystemEntities;

namespace TicketSystem.DataAccess.Abstract.Dal
{
    public interface IMovieDal : IRepositoryDal<Movie>
    {
        MovieDetailDto GetMovieDetail(int id);
        List<Movie> GetMovieByFilters(string movieName = null, int? categoyId = null, DateTime? vdate = null);
    }
}
