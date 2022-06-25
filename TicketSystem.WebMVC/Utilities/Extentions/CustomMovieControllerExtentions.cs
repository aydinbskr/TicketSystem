using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TicketSystem.Business.Abstract;
using TicketSystem.Entities.Dtos;
using TicketSystem.Entities.SystemEntities;

namespace TicketSystem.WebMVC.Utilities.Extentions
{
    public static class CustomMovieControllerExtentions
    {
        public static async Task<IActionResult> CreateMovie(this Controller controller, MovieCreateDto movieCreateDto, IMapper mapper, IFormFile formFile, IMovieService movieService)
        {
            if (movieCreateDto != null)
            {
                movieCreateDto.MovieBanner = await formFile.GetBytes();
                var movie = mapper.Map<Movie>(movieCreateDto);
                var addedMovie = await movieService.CreateAsync(movie);

                return addedMovie == null ? controller.RedirectToAction("Add", "Movie") :
                    controller.RedirectToAction("GetAll", "Movie");

            }
            return controller.RedirectToAction("Add", "Movie");
        }
        public static async Task<IActionResult> UpdateMovie(this Controller controller, MovieUpdateDto movieUpdateDto, IMapper mapper, IFormFile formFile, IMovieService movieService)
        {
            if (movieUpdateDto != null)
            {
                movieUpdateDto.MovieBanner = await formFile.GetBytes();
                var movie = mapper.Map<Movie>(movieUpdateDto);
                var addedMovie = await movieService.UpdateAsync(movie);

                return addedMovie == null ? controller.View("Update", movieUpdateDto) :
                    controller.RedirectToAction("GetAll", "Movie");

            }
            return controller.View("Update", movieUpdateDto);
        }
    }
}
