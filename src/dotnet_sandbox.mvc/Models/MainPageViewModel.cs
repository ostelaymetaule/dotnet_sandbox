using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_sandbox.mvc.Models
{
    public class MainPageViewModel
    {
        /// <summary>
        /// first sub model for the partial view
        /// </summary>
        public List<ListItemViewModel> FirstPartialModel { get; set; }
        /// <summary>
        /// second sub model for the partial view
        /// </summary>
        public List<OtherItemViewModel> SecondPartialModel { get; set; }

        /// <summary>
        /// Field shown and edited on the main page view
        /// </summary>
        public string MainPageName { get; set; }

    }
}
