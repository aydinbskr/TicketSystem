using Microsoft.AspNetCore.Mvc;
using TicketSystem.Business.Abstract;
using TicketSystem.Entities.SystemEntities;

namespace TicketSystem.WebMVC.ViewComponents
{
    public class RecentMovies : ViewComponent
    {
        IMovieService _movieService;

        public RecentMovies(IMovieService movieService)
        {
            _movieService = movieService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var result = _movieService.GetMovieByFilters();
            List<Movie> movies = result.Data.OrderByDescending(x => x.MovieId).Take(3).ToList();
            return View("RecentMovies", movies);
        }
    }
}
