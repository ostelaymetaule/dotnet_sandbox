using dotnet_sandbox.mvc.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_sandbox.mvc.Controllers
{
    /// <summary>
    /// Main page controller
    /// TODO: validate the modelbinding functions in both ways and the updatet values are correctly propagated back to this controller
    /// </summary>
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            //creating a simple model and populating it with sample data:

            MainPageViewModel myModel = CreateSampleModel();

            return View(myModel);
        }

        /// <summary>
        /// Dummy model creation. Can be replaced to quering from DB or similliar
        /// </summary>
        /// <returns>An Viewmodel object containing both information for the main page as also the data needed to populate the partial views.
        /// BEWARE, the dualway modelbinding might not function in this way - this needs testing</returns>
        private static MainPageViewModel CreateSampleModel()
        {
            return new MainPageViewModel()
            {
                //Field shown on the main page
                MainPageName = "my page model with a list",

                //first collection rendered with the partial view
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
                //another collection rendered with the partial view on the same page
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
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
