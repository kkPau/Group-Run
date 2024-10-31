using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using GroupRun.Models;
using GroupRun.Interfaces;
using GroupRun.Helpers;
using GroupRun.ViewModels;
using System.Net;
using Newtonsoft.Json;
using System.Globalization;

namespace GroupRun.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IClubRepository _clubRepository;

    public HomeController(ILogger<HomeController> logger, IClubRepository clubRepository)
    {
        _logger = logger;
        _clubRepository = clubRepository;
    }

    public async Task<IActionResult> Index()
    {
        var ipInfo = new IPInfo();
        var homeViewModel = new HomeViewModel();
        try
        {
            string url = "https://ipinfo.io?token=5f7a21e2ee5cb2";
            var info = new WebClient().DownloadString(url);
            ipInfo = JsonConvert.DeserializeObject<IPInfo>(info);
            RegionInfo myRI = new RegionInfo(ipInfo.Country);
            ipInfo.Country = myRI.EnglishName;
            homeViewModel.City = ipInfo.City;
            homeViewModel.State = ipInfo.Region;
            if(homeViewModel.City != null)
            {
                homeViewModel.Clubs = await _clubRepository.GetClubByCity(homeViewModel.City);
            }
            else
            {
                homeViewModel.Clubs = null;
            }
            return View(homeViewModel);
        }
        catch
        {
            homeViewModel.Clubs = null;
        }
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

