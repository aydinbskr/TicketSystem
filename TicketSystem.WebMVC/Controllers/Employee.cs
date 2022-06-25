using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TicketSystem.Business.Abstract;
using TicketSystem.Entities.Dtos;
using TicketSystem.Entities.Dtos.SessionDtos;
using TicketSystem.Entities.SystemEntities;
using TicketSystem.WebMVC.Utilities.Extentions;

namespace TicketSystem.WebMVC.Controllers
{
    [Authorize(Roles = "Employee")]
    public class Employee : Controller
    {
        ISessionService _sessionService;
        IMapper _mapper;
        IMovieService _movieService;
        IEmployeeService _employeeService;
        ISceneService _sceneService;
        ISeatService _seatService;

        public Employee(IMapper mapper, ISessionService sessionService, IMovieService movieService, IEmployeeService employeeService, ISceneService sceneService, ISeatService seatService)
        {
            _mapper = mapper;
            _sessionService = sessionService;
            _movieService = movieService;
            _employeeService = employeeService;
            _sceneService = sceneService;
            _seatService = seatService;
            
        }

        public async Task<IActionResult> GetProfile()
        {
            var employeeId = FindEmployeeId();
            var employeeResult = await _employeeService.GetByIdAsync(employeeId);
            if (employeeResult.Success)
            {
                var employeeListingDto = _mapper.Map<EmployeeListingDto>(employeeResult.Data);
                return View(employeeListingDto);
            }
            return RedirectToAction("GetAll", "Movie");
        }

       
        [HttpGet]
        public async Task<IActionResult> AddSession()
        {

            var list = await _movieService.GetAllAsync();
            var list2 = await _sceneService.GetAllAsync();
            if (list.Success && list2.Success)
            {
                ViewBag.Movies = new SelectList(list.Data, "MovieId", "MovieName");
                ViewBag.Scenes = new SelectList(list2.Data, "SceneId", "SceneType");
            }

            return View(new Session());
        }
        
        [HttpPost]
        public async Task<IActionResult> AddSession(Session session)
        {

            var result = await _sessionService.CreateAsync(session);

            if (result.Success)
            {
                return RedirectToAction("GetListSessions", "Employee");
            }

            return View("AddSession");
        }

        [HttpGet]
        public async Task<IActionResult> AddSeat()
        {
            var sessionResult = await _sessionService.GetAllAsync();
            var sceneResult = await _sceneService.GetAllAsync();
            if (sessionResult.Success && sceneResult.Success)
            {
                ViewBag.Sessions = new SelectList(sessionResult.Data, "SessionId", "SessionTime");
                ViewBag.Scenes = new SelectList(sceneResult.Data, "SceneId", "SceneType");
            }
            return View(new Seat());
        }
        [HttpPost]
        public async Task<IActionResult> AddSeat(Seat seat)
        {
            var result = await _seatService.CreateAsync(seat);
            if (result.Success)
            {
                return RedirectToAction("GetAll", "Movie");
            }
            return View("AddSeat");
        }
        public async Task<IActionResult> Update()
        {

            int employeeId = FindEmployeeId();
            var employeeResult = await _employeeService.GetByIdAsync(employeeId);

            if (employeeResult.Success)
            {
                var employeeUpdateDto = _mapper.Map<EmployeeUpdateDto>(employeeResult.Data);
                return View(employeeUpdateDto);
            }

            return RedirectToAction("GetAll", "Movie");
        }
        [HttpPost]
        public async Task<IActionResult> Update(EmployeeUpdateDto employeeUpdateDto)
        {
            var employeeId = FindEmployeeId();
            return await this.UpdateUserAsync(_employeeService, _mapper, employeeUpdateDto, employeeId);
        }

        private int FindEmployeeId() => Convert.ToInt32(User.FindFirst("Id")!.Value);

        [HttpGet]
        public async Task<IActionResult> GetListSessions()
        {
            var result = _sessionService.GetListSessions();
            return View(result.Data);
        }
        [HttpGet]
        public async Task<IActionResult> UpdateSession(int id)
        {
            if (id == 0)
            {
                return View("GetListSessions");
            }
            var result = await _sessionService.GetByIdAsync(id);
            if (result.Success)
            {
                var list = await _movieService.GetAllAsync();
                var list2 = await _sceneService.GetAllAsync();
                if (list.Success && list2.Success)
                {
                    ViewBag.Movies = new SelectList(list.Data, "MovieId", "MovieName");
                    ViewBag.Scenes = new SelectList(list2.Data, "SceneId", "SceneType");

            
                    return View(result.Data);
                }
            }
            return View("GetListSessions");
        }
        [HttpPost]
        public async Task<IActionResult> UpdateSession(Session session)
        {

            var result = await _sessionService.UpdateAsync(session);
            if (result.Success)
            {
                return RedirectToAction("GetListSessions", "Employee");
            }
            return View("UpdateSession");
        }

        
        [HttpPost]
        public async Task<IActionResult> DeleteSession(int id)
        {
            if (id == 0)
            {
                return RedirectToAction("GetListSessions");
            }

            var result = await _sessionService.GetByIdAsync(id);
            if (result.Success)
            {
                var session = result.Data;
                await _sessionService.RemoveAsync(session);
            }

            return RedirectToAction("GetListSessions");

        }
    }
}
