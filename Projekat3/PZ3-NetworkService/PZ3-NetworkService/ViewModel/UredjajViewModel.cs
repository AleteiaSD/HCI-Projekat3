using PZ3_NetworkService.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PZ3_NetworkService.ViewModel
{
    public class UredjajViewModel : BindableBase
    {
        public static List<string> UredjajTypes { get; set; } = new List<string> { "Badger25", "Nik7001", "Turbo975" };//lista uredjaja
        public static ObservableCollection<Uredjaj> Uredjaji { get; set; } = new ObservableCollection<Uredjaj>();
        public static ObservableCollection<Uredjaj> UredjajiCopy { get; set; } = new ObservableCollection<Uredjaj>();
        
        
        //putanja do slike //"name.jpg"
        private string pathFirst = @"C:\Users\TheMachine\Desktop\gajic\SelenicPz3\PZ3-NetworkService\PZ3-NetworkService\Images\";
        private string path = "";
        
        //za pretragu
        private string selectedTypeUredjaj = string.Empty;
        private string selectedTypeUredjaj2 = string.Empty;
        
        
        private Uredjaj selectedUredjaj;//selektovan u listi 

        private string idText; //za vrednosti polja
        private string nameText;

        private Uredjaj trenutniUredjaj = new Uredjaj();

        private string idString;
        public string IdString { get => idString; set => idString = value; }


        public MyICommand DeleteCommand { get; set; }//kontrola komande
        public MyICommand AddCommand { get; set; }
        public MyICommand SearchCommand { get; set; }
        public MyICommand ResetCommand { get; set; }
        public MyICommand UndoCommand { get; set; }
        public MyICommand HomeCommand { get; set; }

        public UredjajViewModel()
        {
            RbName_isChecked = true;
            
            DeleteCommand = new MyICommand(OnDelete, CanDelete);
            AddCommand = new MyICommand(OnAdd, CanAdd);

            SearchCommand = new MyICommand(OnSearch);
            ResetCommand = new MyICommand(OnReset);

            UndoCommand = new MyICommand(OnUndo, CanUndo);
            HomeCommand = new MyICommand(OnHomeCommand);

        }
        private void OnHomeCommand()
        {
            // Messenger.Default.Send<int>(0);
        }

        public Uredjaj SelectedUredjaj
        {
            get
            {
                return selectedUredjaj;
            }
            set
            {
                selectedUredjaj = value;
                DeleteCommand.RaiseCanExecuteChanged();
            }

        }

        public string SelectedTypeUredjaj2
        {
            get => selectedTypeUredjaj2;
            set
            {
                if (selectedTypeUredjaj2 != value)
                {
                    selectedTypeUredjaj2 = value;
                    Path = pathFirst + value.ToString() + ".jpg";
                    OnPropertyChanged("Path");
                    OnPropertyChanged("SelectedTypeUredjaj2");
                    AddCommand.RaiseCanExecuteChanged();
                }
            }
        }

        public string Path
        {
            get => path;
            set
            {
                path = value;
                OnPropertyChanged("Path");
            }
        }

        public string SelectedTypeUredjaj
        {
            get => selectedTypeUredjaj;
            set
            {
                if (selectedTypeUredjaj != value)
                {
                    selectedTypeUredjaj = value;
                    OnPropertyChanged("SelectedTypeUredjaj");

                }
            }
        }


        private void OnDelete()
        {
            int i = SelectedUredjaj.Id;
            Uredjaj zaBrisanje = new Uredjaj(SelectedUredjaj);
            
                SelectedUredjaj.Ids.Remove(i);
                Uredjaji.Remove(SelectedUredjaj);
                
                foreach (Uredjaj uredj in UredjajiCopy.ToList())
                {
                    if (uredj.Id == zaBrisanje.Id)
                        UredjajiCopy.Remove(uredj);
                }
                poslednjaAkcija = "delete";
                obrisano = new Uredjaj(zaBrisanje);
                Undo1 = true;
        }
        private bool CanDelete()//treba dodati da se ne moze obrisati ako je postavljen u drag and drop
        {
            return SelectedUredjaj != null;
        }
        private bool CanAdd()
        {
            if (SelectedTypeUredjaj2 != null && IdText != null && NameText != null)
                return true;
            return false;
        }
       
        private void OnAdd()
        {
            int tempID = 0;
            try
            {
                tempID = Int32.Parse(IdText);
            }
            catch
            {
                System.Windows.MessageBox.Show("ID must be a number!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            string tempS = NameText;
            if (string.IsNullOrWhiteSpace(tempS))
            {
                System.Windows.MessageBox.Show("The name must not be a white space!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            bool postojiUredjaj = false;
            foreach (Uredjaj uredj in Uredjaji)
            {
                if (uredj.Id == tempID)
                {
                    postojiUredjaj = true;
                }
            }
            if (postojiUredjaj)
            {
                System.Windows.MessageBox.Show("ID must be unique!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            Model.Type temp = new Model.Type(selectedTypeUredjaj2, @"C:\Users\TheMachine\Desktop\gajic\SelenicPz3\PZ3-NetworkService\PZ3-NetworkService\Images\" + SelectedTypeUredjaj2.ToString() + ".jpg");
            Uredjaj uredj1 = new Uredjaj{ Id = tempID, Name = NameText, Value = 700, TypeUredjaj = temp };
            Uredjaji.Add(uredj1);
            

            /*poslednjaAkcija = "add";
            dodato = new Uredjaj(uredj1);
            Undo1 = true;*/
        }

        public Uredjaj TrenutniUredjaj
        {
            get { return trenutniUredjaj; }
            set
            {
                trenutniUredjaj = value;
                OnPropertyChanged("TrenutniUredjaj");
            }
        }
        //===============



        public string IdText
        {
            get
            {
                return idText;
            }
            set
            {
                if (idText != value)
                {
                    idText = value;
                    OnPropertyChanged("IdText");
                    AddCommand.RaiseCanExecuteChanged();
                }
            }
        }
        public string NameText
        {
            get
            {
                return nameText;
            }
            set
            {
                if (nameText != value)
                {
                    nameText = value;
                    OnPropertyChanged("NameText");
                    AddCommand.RaiseCanExecuteChanged();
                }
            }
        }
        //SEARCH
        private bool rbName_isChecked;
        private bool rbType_isChecked;
        private string search;
        private string searchError;

        public bool RbName_isChecked
        {
            get { return rbName_isChecked; }
            set
            {
                if (rbName_isChecked != value)
                    rbName_isChecked = value;
            }
        }


        public bool RbType_isChecked
        {
            get { return rbType_isChecked; }
            set
            {
                if (rbType_isChecked != value)
                    rbType_isChecked = value;
            }
        }


        public string Search
        {
            get { return search; }
            set
            {
                search = value;
            }
        }


        public string SearchError
        {
            get { return searchError; }
            set
            {
                searchError = value;
                OnPropertyChanged("SearchError");
            }
        }

        int copy = 0;
        private void OnSearch()
        {
            if (copy == 0)
            {
                if (string.IsNullOrWhiteSpace(Search))
                {
                    System.Windows.MessageBox.Show("Unesite tekst u polje SEARCH!!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                else
                {
                    SearchError = "";
                }
                string s = Search;

                foreach (Uredjaj uredj in Uredjaji)
                {
                    UredjajiCopy.Add(uredj); //prvo sve stavim  u kopiju liste(tabele)                
                }
                copy = 1; // uradjen je search 
                Uredjaji.Clear();

                if (RbName_isChecked)
                {
                    foreach (Uredjaj uredj in UredjajiCopy) //iz glavne liste treba da obrisem sve elemente koji ne odgovaraju name
                    {
                        if (uredj.Name.Contains(s))
                        {
                            Uredjaji.Add(uredj);
                        }
                    }
                }
                else if (RbType_isChecked)
                {
                    foreach (Uredjaj uredj in UredjajiCopy) //iz glavne liste treba da obrisem sve elemente koji ne odgovaraju type
                    {
                        if (uredj.TypeUredjaj.Name.Contains(s))
                        {
                            Uredjaji.Add(uredj);
                        }
                    }
                }
            }
        }
        
        private void OnReset()
        {
            if(copy == 1)
            {
                Uredjaji.Clear();
                foreach (Uredjaj uredj in UredjajiCopy)
                {
                    Uredjaji.Add(uredj);
                }
                
                 UredjajiCopy.Clear();
                copy = 0; // da znam da je copy lista prazna
                 ResetCommand.RaiseCanExecuteChanged();                
            }          
        }




        private bool undo;
        private string poslednjaAkcija;
        private Uredjaj dodato;
        private Uredjaj obrisano;
        private bool CanUndo()
        {
            return undo;
        }

        private void OnUndo()
        {
            if (undo)
            {
                if (poslednjaAkcija == "add")
                {
                    undoAdd();
                }
                else if (poslednjaAkcija == "delete")
                {
                    undoDelete();
                }
            }
        }
        public bool Undo1
        {
            get { return undo; }
            set
            {
                if (undo != value)
                {
                    undo = value;
                    UndoCommand.RaiseCanExecuteChanged();
                }
            }
        }

        private void undoAdd()
        {
            /*dodato.Ids.Remove(dodato.Id);
            foreach (Uredjaj uredj in MainWindow.ListObj.ToList())
            {
                if (uredj.Id == dodato.Id)
                {
                    MainWindow.ListObj.Remove(uredj);
                }
            }
            foreach (Uredjaj uredj in UredjajiCopy.ToList())
            {
                if (uredj.Id == dodato.Id)
                    UredjajiCopy.Remove(uredj);
            }
            poslednjaAkcija = "delete";
            obrisano = new Uredjaj(dodato);
            Undo1 = true;*/
        }
        private void undoDelete()
        {
            if (dodato != obrisano) { 
            Uredjaji.Add(obrisano);
            Uredjaj unDelUredjaji = obrisano;
            UredjajiCopy.Add(unDelUredjaji);
            }

            poslednjaAkcija = "add";
            dodato = obrisano;
            Undo1 = true;
        }

        
        
    }
}
