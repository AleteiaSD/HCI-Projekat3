using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PZ3_NetworkService.Model
{
    public class UredjajModel
    {
    }
    public class Uredjaj : INotifyPropertyChanged
    {

        private int id;
        private string name;
        private double value;
        private Type typeUredjaj;

        public Uredjaj()
        {

        }
        public Uredjaj(int id)
        {
            this.id = id;
        }
        public Uredjaj(Uredjaj v)
        {
            Id = v.Id;
            Name = v.Name;
            Value = v.Value;
            TypeUredjaj = v.TypeUredjaj;

        }
        public int Id
        {
            get => id;
            set
            {
                if (this.id != value)
                {
                    this.id = value;
                    RaisePropertyChanged("Id");
                }
            }
        }

        public string Name
        {
            get => name;
            set
            {
                if (this.name != value)
                {
                    this.name = value;
                    RaisePropertyChanged("Name");
                }
            }
        }

        public double Value
        {
            get => value;
            set
            {
                if (this.value != value)
                {
                    this.value = value;
                    RaisePropertyChanged("Value");
                }
            }
        }     
        
        public Type TypeUredjaj
        {
            get => typeUredjaj;
            set
            {
                /*  typeV.Name = value.Name;
                  typeV.ImgSrc = value.ImgSrc;*/
                typeUredjaj = value;
                RaisePropertyChanged("TypeUredjaj");
            }
        }

        private static List<int> ids = new List<int>();
        public List<int> Ids { get => ids; set => ids = value; }  



        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }
    }
}
