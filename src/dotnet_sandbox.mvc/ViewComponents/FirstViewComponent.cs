using dotnet_sandbox.mvc.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_sandbox.mvc.ViewComponents
{
    public class FirstViewComponent : ViewComponent
    {

        /// <summary>
        /// This method is called from the main view
        /// </summary>
        /// <returns></returns>
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var items = await GetItems();
            return View(items);
        }

        /// <summary>
        /// Generating some data using the same data classes as in another example
        /// </summary>
        /// <returns></returns>
        private Task<List<ListItemViewModel>> GetItems()
        {
            return Task.Run(() =>
            {
                Task.Delay(1000);
                return new List<ListItemViewModel>()
                {
                    new ListItemViewModel()
                    {
                        Index=1,
                        Name = "Another first item",
                        Time= DateTime.Now.AddHours(-5).AddYears(5)
                    },
                     new ListItemViewModel()
                    {
                        Index=2,
                        Name = "Another second item",
                        Time= DateTime.Now.AddHours(-3).AddDays(3)
                    }
                     ,
                     new ListItemViewModel()
                    {
                        Index=2,
                        Name = "Another third item",
                        Time= DateTime.Now.AddHours(7).AddDays(222)
                    }
                };
            });

        }
    }
}
