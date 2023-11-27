using AutoBusAppBLL.DTOModels;
using AutoBusAppBLL.Services.Interfaces;
using AutoBusAppWeb.Models;
using AutoMapper;
using DataAccessLayer.Models;
using DataAccessLayer.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Diagnostics;

namespace AutoBusAppWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUrlModelService _urlModelService;
        private readonly ILogger<HomeController> _logger;
        private readonly IMapper _mapper;

        public HomeController(IUrlModelService urlModelService, ILogger<HomeController> logger,
            IMapper mapper)
        {
            _urlModelService = urlModelService;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet("/")]
        public IActionResult Index()
        {
            return View(_urlModelService.GetAll);
        }

        public IActionResult IncreaseVisitedCount(string id)
        {
            var parseGuid = ParseStringToGuid(id);

            if (parseGuid == null)
                return RedirectToAction("Error");

            var guidId = (Guid)parseGuid;

            _urlModelService.IncreaseVisitedCount(guidId);

            return RedirectToAction("Index");
        }

        [HttpGet("Edit/{id}")]
        public IActionResult EditUrl(string id)
        {
            var parseGuid = ParseStringToGuid(id);

            if (parseGuid == null)
                return RedirectToAction("Error");

            var guidId = (Guid)parseGuid;

            var url = _urlModelService.GetById(guidId);

            var mapperUrl = _mapper.Map<UrlEditDto>(url);

            return View(mapperUrl);
        }

        [HttpPost("Edit/{id}")]
        public IActionResult EditUrl(string id, [FromForm]UrlEditDto urlEdit)
        {
            var parseGuid = ParseStringToGuid(id);

            if (parseGuid == null)
                return RedirectToAction("Error");

            var guidId = (Guid)parseGuid;

            if (_urlModelService.EditUrl(guidId, urlEdit) == null)
                return RedirectToAction("Error");

            return RedirectToAction("Index");
        }

        [HttpPost("Delete/{id}")]
        public IActionResult DeleteUrl(string id)
        {
            var parseGuid = ParseStringToGuid(id);

            if (parseGuid == null)
                return RedirectToAction("Error");

            var guidId = (Guid)parseGuid;

            if (_urlModelService.DeleteUrl(guidId) == null)
                return RedirectToAction("Error");

            return RedirectToAction("Index");
        }

        public string GenerateShortUrl(string longUrl) =>
            _urlModelService.CreateShortUrl(longUrl);

        [HttpGet("Add")]
        public IActionResult AddUrl() => View();

        [HttpPost("Add")]
        public IActionResult AddUrl([FromForm]UrlAddDto urlAddDto) 
        {
            if (_urlModelService.AddUrl(urlAddDto) == null)
                return RedirectToAction("Error");

            return RedirectToAction("Index");
        }
            
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        private Guid? ParseStringToGuid(string id)
        {
            try
            {
                return Guid.Parse(id);
            }
            catch (ArgumentNullException ex)
            {
                _logger.Log(LogLevel.Critical, ex.Message, this);
                return null;
            }
            catch (FormatException ex)
            {
                _logger.Log(LogLevel.Critical, ex.Message, this);
                return null;
            }
        }
    }
}
