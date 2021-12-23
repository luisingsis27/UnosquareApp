using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using UnosquareApp.Models;
using Xamarin.Forms;

namespace UnosquareApp.ViewModels
{
    public class AutosPageVM : BaseViewModel
    {

        public ICommand GuardarCommand { private set; get; }
        public ICommand CancelarCommand { private set; get; }
        ObservableCollection<Autos> autos;
        public AutosPageVM(ObservableCollection<Autos> autos)
        {

            this.autos = autos;
            GuardarCommand = new Command(async () => { Guardar(); });
            CancelarCommand = new Command(async () => { Cancelar(); });
        }

        void Cancelar()
        {
            Application.Current.MainPage.Navigation.PopModalAsync();
        }

        async void Guardar()
        {
            try
            {
                Autos auto = new Autos();
                auto.Anio = Anio;
                auto.Marca = Marca;
                auto.Modelo = Modelo;
                var ss = autos.Where(Z => Z.Modelo == auto.Modelo && Z.Marca == auto.Marca && Z.Anio == auto.Anio);
                if (ss.Count() > 0)
                {
                    await Application.Current.MainPage.DisplayAlert(string.Empty, "Ya existe este registro", "Aceptar");
                }
                else
                {
                    autos.Add(auto);
                    await Application.Current.MainPage.DisplayAlert(string.Empty, "Guardado Correctamente", "Aceptar");
                    //ActionActualizarClientes?.Invoke();
                    Application.Current.MainPage.Navigation.PopModalAsync();
                }
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private string _marca;

        public string Marca
        {
            get { return _marca; }
            set { _marca = value; OnPropertyChanged(); }
        }

        private string _modelo;

        public string Modelo
        {
            get { return _modelo; }
            set { _modelo = value; OnPropertyChanged(); }
        }

        private string _anio;

        public string Anio
        {
            get { return _anio; }
            set { _anio = value; OnPropertyChanged(); }
        }
    }
}
