using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_sandbox.mvc.Models
{
    public class MainPageViewModel
    {
        public List<ListItemViewModel> FirstPartialModel { get; set; }
        public List<OtherItemViewModel> SecondPartialModel { get; set; }


        public string MainPageName { get; set; }

    }
}
