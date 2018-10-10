using dotnet_sandbox.mvc.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_sandbox.mvc.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var myModel = new MainPageViewModel()
            {
                MainPageName = "my page model with a list",
                FirstPartialModel = new List<ListItemViewModel>()
                {
                    new ListItemViewModel()
                    {
                        Index=1,
                        Name = "first item",
                        Time= DateTime.Now.AddHours(-1).AddYears(2)
                    },
                     new ListItemViewModel()
                    {
                        Index=2,
                        Name = "second item",
                        Time= DateTime.Now.AddHours(-2).AddDays(1)
                    }
                },
                SecondPartialModel = new List<OtherItemViewModel>
                {
                    new OtherItemViewModel
                    {
                        Guid = Guid.NewGuid(),
                        Value = 2.123123
                    },
                    new OtherItemViewModel
                    {
                        Guid = Guid.NewGuid(),
                        Value = 3454
                    },
                    new OtherItemViewModel
                    {
                        Guid = Guid.NewGuid(),
                        Value = 1231241.12313
                    }
                }
            };

            return View(myModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
