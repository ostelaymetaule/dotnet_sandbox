using dotnet_sandbox.mvc.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_sandbox.mvc.ViewComponents
{
    public class SecondViewComponent : ViewComponent
    {
        /// <summary>
        /// This method is called from the main view
        /// </summary>
        /// <param name="elementCount">Number of the data entries should be generated for the test</param>
        /// <returns></returns>
        public async Task<IViewComponentResult> InvokeAsync(int elementCount)
        {
            //Use non standard view name. You can define multiple views and choise one of them this way
            string viewName = "SecondNotDefaultView";
            //pass the parameter via temp data to the view
            this.TempData.Add("myparameter", elementCount);

            var items = await GetItems(elementCount);
            return View(viewName, items);
        }

        /// <summary>
        /// generating the dataset
        /// </summary>
        /// <param name="elementCount">Number of the data entries should be generated for the test</param>
        /// <returns></returns>
        private Task<List<OtherItemViewModel>> GetItems(int elementCount)
        {
            return Task.Run(() =>
            {
                Task.Delay(1000);
                var list = new List<OtherItemViewModel>();
                for (int i = 1; i < elementCount + 1; i++)
                {
                    Task.Delay(100);

                    list.Add(new OtherItemViewModel()
                    {
                        Guid = Guid.NewGuid(),
                        //create some double values
                        Value = (double)i + (double)i / 7.1
                    });

                }
                return list;
            }
            );
        }






    }
}
