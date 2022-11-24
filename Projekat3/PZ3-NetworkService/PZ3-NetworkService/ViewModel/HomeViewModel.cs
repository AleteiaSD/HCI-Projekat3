using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PZ3_NetworkService.ViewModel
{
    public class HomeViewModel:BindableBase
    {
        private string homeViewStartMessage = "Pracenje potrosnje vode!";
        public string HomeViewStartMessage
        {
            get { return homeViewStartMessage; } //return "Hello!";
        }
    }
}
