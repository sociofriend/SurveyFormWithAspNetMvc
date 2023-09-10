using Microsoft.AspNetCore.Mvc;
using SurveyFormProject.DbContexts;
using SurveyFormProject.Models;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using AutoMapper;
using SurveyFormProject.Repositories;

namespace SurveyFormProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IRepository _repository;
        private readonly IMapper _mapper;

        public HomeController(ILogger<HomeController> logger,
            IRepository repository, IMapper mapper)
        {
            _logger = logger ?? 
                throw new ArgumentNullException(nameof(logger));
            _repository = repository ?? 
                throw new ArgumentNullException(nameof(repository));
            _mapper = mapper ?? 
                throw new ArgumentNullException(nameof(mapper));
        }

        public ViewResult Index()
        {
            int hour = DateTime.Now.Hour;

            //ViewBag is a lightweight way to send data to the view without
            //requiring a strongly typed model.
            ViewBag.Greeting = hour < 12 ?
                "Good morning" : "Good afternoon";

            return View("ViewPage1");
        }

        [HttpGet]
        public ViewResult RsvpForm()
        {
            return View();
        }

        [HttpPost]
        public ViewResult RsvpForm(GuestResponseDto guestResponse)
        {
            if (ModelState.IsValid)
            {
                //store response from guest
                _repository.AddResponse(guestResponse);
                
                return View("Thanks", guestResponse);
            }
            else
            {
                return View();
            }
        }

        public ViewResult ListResponses()
        {
            IEnumerable<GuestResponseDto> result = _repository.GetResponsesWillAttend();

            return View(result);
        }
    }
}