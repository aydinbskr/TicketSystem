using TicketSystem.Business.Abstract;
using TicketSystem.Business.Utilities.ValidationRules;
using TicketSystem.Core.Aspects.Autofac;
using TicketSystem.Core.Utilities.Results;
using TicketSystem.DataAccess.Abstract.Dal;
using TicketSystem.Entities.Dtos.MovieDtos;
using TicketSystem.Entities.SystemEntities;

namespace TicketSystem.Business.Concrete
{
    public class MovieManager : IMovieService
    {
        readonly IMovieDal _movieDal;

        public MovieManager(IMovieDal cinemaDal)
        {
            _movieDal = cinemaDal;
        }

        [ValidationAspect(typeof(MovieValidationRules))]
        public async Task<IDataResult<Movie>> CreateAsync(Movie movie)
        {
            var addedMovie = await _movieDal.CreateAsync(movie);
            if (addedMovie != null)
            {
                return new SuccessDataResult<Movie>(addedMovie);
            }
            return new ErrorDataResult<Movie>();
        }

        public async Task<IDataResult<List<Movie>>> GetAllAsync()
        {
            var list = await _movieDal.GetAllAsync();
            if (list != null)
            {
                return new SuccessDataResult<List<Movie>>(list);
            }
            return new ErrorDataResult<List<Movie>>();
        }


        public async Task<IDataResult<Movie>> GetByIdAsync(int id)
        {
            var movie = await _movieDal.GetByFilterAsync(m => m.MovieId == id);
            if (movie != null)
            {
                return new SuccessDataResult<Movie>(movie);
            }
            return new ErrorDataResult<Movie>();
        }

        public async Task<IResult> RemoveAsync(Movie movie)
        {
            _movieDal.Remove(movie);
            return await Task.FromResult(new SuccessResult());
        }

        [ValidationAspect(typeof(MovieValidationRules))]
        public async Task<IDataResult<Movie>> UpdateAsync(Movie movie)
        {
            var updatedMovie = _movieDal.Update(movie);
            return await Task.FromResult(new SuccessDataResult<Movie>(updatedMovie));
        }

        public IDataResult<MovieDetailDto> GetMovieDetailAsync(int id)
        {
            var movie = _movieDal.GetMovieDetail(id);
            if (movie != null)
            {
                return new SuccessDataResult<MovieDetailDto>(movie);
            }
            return new ErrorDataResult<MovieDetailDto>();
        }

        public IDataResult<List<Movie>> GetMovieByFilters(string movieName = null, int? categoyId = null, DateTime? vdate = null)
        {
            var movie = _movieDal.GetMovieByFilters(movieName, categoyId, vdate);
            if (movie != null)
            {
                return new SuccessDataResult<List<Movie>>(movie);
            }
            return new ErrorDataResult<List<Movie>>();
        }
    }
}
