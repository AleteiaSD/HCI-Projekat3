using PZ3_NetworkService.Model;
using PZ3_NetworkService.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PZ3_NetworkService
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int count = 15; // Inicijalna vrednost broja objekata u sistemu
        private int id;
        private double value;
        private bool file = false;
        private string path = @"C:\Users\TheMachine\Desktop\gajic\SelenicPz3\PZ3-NetworkService\LogFile.txt";
        
        public static ObservableCollection<Uredjaj> ListObj { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            ListObj = new ObservableCollection<Uredjaj>();
            //LoadUredjaji1();
            createListener(); //Povezivanje sa serverskom aplikacijom
        }
        public static Model.Type tip1 = new Model.Type() { Name = "Badger25", ImgSrc = "Badger25.jpg" };
        public static Model.Type tip2 = new Model.Type() { Name = "Nik7001", ImgSrc = "Nik7001.png" };
        public void LoadUredjaji1()
        {
            //ObservableCollection<Road> roads = new ObservableCollection<Road>();
            Uredjaj ur1 = new Uredjaj() { Id = 1, Name = "a", Value = 700, TypeUredjaj = tip1};
            Uredjaj ur2 = new Uredjaj() { Id = 2, Name = "b", Value = 700, TypeUredjaj = tip2};
            
            ListObj.Add(ur1);
            MainWindowViewModel.Referenca.Add(ur1);
            ListObj.Add(ur2);
            MainWindowViewModel.Referenca.Add(ur2);



        }

        private void createListener()
        {
            var tcp = new TcpListener(IPAddress.Any, 25565);
            tcp.Start();

            var listeningThread = new Thread(() =>
            {
                while (true)
                {
                    var tcpClient = tcp.AcceptTcpClient();
                    ThreadPool.QueueUserWorkItem(param =>
                    {
                        //Prijem poruke
                        NetworkStream stream = tcpClient.GetStream();
                        string incomming;
                        byte[] bytes = new byte[1024];
                        int i = stream.Read(bytes, 0, bytes.Length);
                        //Primljena poruka je sacuvana u incomming stringu
                        incomming = System.Text.Encoding.ASCII.GetString(bytes, 0, i);

                        //Ukoliko je primljena poruka pitanje koliko objekata ima u sistemu -> odgovor
                        if (incomming.Equals("Need object count"))
                        {
                            //Response
                            /* Umesto sto se ovde salje count.ToString(), potrebno je poslati 
                             * duzinu liste koja sadrzi sve objekte pod monitoringom, odnosno
                             * njihov ukupan broj (NE BROJATI OD NULE, VEC POSLATI UKUPAN BROJ)
                             * */
                            Byte[] data = System.Text.Encoding.ASCII.GetBytes(count.ToString());
                            stream.Write(data, 0, data.Length);
                            file = false;
                        }
                        else
                        {
                            //U suprotnom, server je poslao promenu stanja nekog objekta u sistemu
                            Console.WriteLine(incomming); //Na primer: "Objekat_1:272"
                            string[] split = incomming.Split('_', ':');
                            int index = Int32.Parse(split[1]);
                            if (UredjajViewModel.Uredjaji.Count> index)
                                id = UredjajViewModel.Uredjaji[index].Id;
                            else
                                id = -1;
                            value = double.Parse(split[2]);
                            Uredjaj v = new Uredjaj(id);
                             if (id !=-1)
                            {
                                UredjajViewModel.Uredjaji[index].Value = value;
                                 UpisUFajl();
                            }
                            //################ IMPLEMENTACIJA ####################
                            // Obraditi poruku kako bi se dobile informacije o izmeni
                            // Azuriranje potrebnih stvari u aplikaciji
                            //UpisUFajl();
                        }
                    }, null);
                }
            });

            listeningThread.IsBackground = true;
            listeningThread.Start();
        }
        private void UpisUFajl()
        {
            if(!file)
            {
                StreamWriter wr;
                using (wr = new StreamWriter(path))
                {
                    wr.WriteLine("Date Time:\t" + DateTime.Now.ToString() + "\tObject_" + id + "\tValue:\t" + value);
                }
            }
            else
            {
                StreamWriter wr;
                using (wr = new StreamWriter(path,true))
                {
                    wr.WriteLine("Date Time:\t" + DateTime.Now.ToString() + "\tObject_" + id + "\tValue:\t" + value);
                }
            }
            file = true;
        }

    }
}
