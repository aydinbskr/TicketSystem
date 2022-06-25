using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TicketSystem.Business.Abstract;
using TicketSystem.Entities.Dtos;

namespace TicketSystem.WebMVC.ViewComponents
{
    public class LastAddedMoviesComponent : ViewComponent
    {
        IMovieService _movieService;
        IMapper _mapper;

        public LastAddedMoviesComponent(IMovieService movieService, IMapper mapper)
        {
            _movieService = movieService;
            _mapper = mapper;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var movieResult = await _movieService.GetAllAsync();
            if (movieResult.Success)
            {
                var movies = _mapper.Map<List<MovieListingDto>>(movieResult.Data);
                return View("LastAddedMoviesComponent", movies);
            }
            return View("LastAddedMoviesComponent", new List<MovieListingDto>());
        }
    }
}
