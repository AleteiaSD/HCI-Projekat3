using PZ3_NetworkService.Model;
using PZ3_NetworkService.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PZ3_NetworkService
{
    public class MainWindowViewModel : BindableBase
    {
        public MyICommand<string> NavCommand { get; private set; }
        private HomeViewModel homeModelView = new HomeViewModel();
        private UredjajViewModel uredjajModelView = new UredjajViewModel();
        private ReportViewModel reportModelView = new ReportViewModel();
        private DDViewModel networkModelView = new DDViewModel();
        private GrafViewModel grafModelView = new GrafViewModel();
        private BindableBase currentViewModel;


        public static ObservableCollection<Uredjaj> Referenca { get; set; }


        public MainWindowViewModel()
        {
           
            NavCommand = new MyICommand<String>(OnNav);

            CurrentViewModel = uredjajModelView;
        }
        public BindableBase CurrentViewModel
        {
            get { return currentViewModel; }
            set
            {
                SetProperty(ref currentViewModel, value);
            }
        }

        private void OnNav(string destination)
        {
            switch (destination)
            {
                case "Pocetak":
                    CurrentViewModel = homeModelView;
                    break;
                case "Tabela":
                    CurrentViewModel = uredjajModelView;
                    break;
                case "Vizuelni prikaz":
                    CurrentViewModel = networkModelView;
                    break;
                case "Report":
                    CurrentViewModel = reportModelView;
                    break;
                case "Graf":
                    CurrentViewModel = grafModelView;
                    break;


            }
        }
    }
}
