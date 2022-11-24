using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PZ3_NetworkService.ViewModel
{
    public class GrafViewModel:BindableBase
    {
        private string t1;
        private string t2;
        private string t3;
        private string t4;
        private string t5;
        private string t6;

        private string path = @"C:\Users\TheMachine\Desktop\gajic\SelenicPz3\PZ3-NetworkService\LogFile.txt";

        public MyICommand PlotCommand { get; set; }

        public GrafViewModel()
        {
            PlotCommand = new MyICommand(OnPlot, CanPlot);
        }

        public string T1
        {
            get { return t1; }
            set
            {
                t1 = value;
                OnPropertyChanged("T1");
            }
        }
        public string T2
        {
            get { return t2; }
            set
            {
                t2 = value;
                OnPropertyChanged("T2");
            }
        }
        public string T3
        {
            get { return t3; }
            set
            {
                t3 = value;
                OnPropertyChanged("T3");
            }
        }
        public string T4
        {
            get { return t4; }
            set
            {
                t4 = value;
                OnPropertyChanged("T4");
            }
        }
        public string T5
        {
            get { return t5; }
            set
            {
                t5 = value;
                OnPropertyChanged("T5");
            }
        }
        public string T6
        {
            get { return t6; }
            set
            {
                t6 = value;
                OnPropertyChanged("T6");
            }
        }

        private string selectedId = "";
        public string SelectedId
        {
            get => selectedId;
            set
            {
                selectedId = value;
                OnPropertyChanged("SelectedId");
                PlotCommand.RaiseCanExecuteChanged();
            }
        }

        private bool CanPlot()
        {
            return SelectedId != null;
        }

        private void OnPlot()
        {
            int IdUredjaja = -1;
            try
            {
                IdUredjaja = int.Parse(SelectedId);
            }
            catch
            { }

            if (IdUredjaja != -1)
            {
                List<double> UredjajValue = new List<double>();
                try
                {
                    using (StreamReader sr = new StreamReader(path))
                    {
                        List<List<string>> fileData = new List<List<string>>();
                        string textFile = sr.ReadToEnd();
                        string[] str_split = textFile.Split('\t', ' ', '\n', '_');
                        int length = str_split.Length;
                        for (int i = 2; i < length; i = i + 9)
                        {
                            fileData.Add(new List<string> { str_split[i], str_split[i + 1], str_split[i + 4], str_split[i + 6] });
                        }

                        for (int i = 0; i < fileData.Count; i++)
                        {
                            if (IdUredjaja == int.Parse(fileData[i][2]))
                                UredjajValue.Add(double.Parse(fileData[i][3]));
                        }


                        int SVLength = UredjajValue.Count;
                        if (SVLength > 6)
                        {
                            for (int i = 0; i < SVLength - 6; i++)
                            {
                                UredjajValue.RemoveAt(i);
                            }
                        }
                        else
                        {
                            for (int i = SVLength; i < 6; i++)
                            {
                                UredjajValue.Add(UredjajValue[SVLength - 1]);
                            }
                        }
                    }
                }
                catch
                { }

                if (UredjajValue.Count == 6)
                {
                    T1 = "0," + (400 - 4 * UredjajValue[0]).ToString();
                    T2 = "130," + (400 - 4 * UredjajValue[1]).ToString();
                    T3 = "260," + (400 - 4 * UredjajValue[2]).ToString();
                    T4 = "390," + (400 - 4 * UredjajValue[3]).ToString();
                    T5 = "520," + (400 - 4 * UredjajValue[4]).ToString();
                    T6 = "650," + (400 - 4 * UredjajValue[5]).ToString();
                }

            }
        }

        /* public static List<string> UredjajiGraf { get; set; } = new List<string>();
         private List<string> values = new List<string>();
         private List<string> time = new List<string>();
         private string selectedId = "";
         //private string path = @"C:\Users\TheMachine\Desktop\gajic\SelenicPz3\PZ3-NetworkService\LogFile.txt";

         public MyICommand PlotGraphCommand { get; set; }


         public GrafViewModel()
         {
             PlotGraphCommand = new MyICommand(OnPlot, CanPlot);
         }
         public string SelectedId
         {
             get => selectedId;
             set
             {
                 selectedId = value;
                 OnPropertyChanged("SelectedId");
                 PlotGraphCommand.RaiseCanExecuteChanged();
             }
         }
         public void OnPlot()
         {

         }

         public bool CanPlot()
         {
             if (SelectedId.Equals(""))
                 return false;
             else
                 return true;
         }*/
    }
}
