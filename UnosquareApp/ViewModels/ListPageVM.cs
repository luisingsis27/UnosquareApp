using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using UnosquareApp.Models;
using UnosquareApp.Services;
using UnosquareApp.Views;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace UnosquareApp.ViewModels
{
    public class ListPageVM : BaseViewModel
    {
        private IPackageService _packageService;
        public ICommand AgregarCommand { private set; get; }
        AutosPage autosPage;
        private ObservableCollection<Autos> _autos = new ObservableCollection<Autos>();
        public ListPageVM()
        {
            _packageService = DependencyService.Get<IPackageService>();

            _packageName = _packageService.GetPackageName();

            _autos.Add(new Autos() { Modelo = "GTX", Marca = "Nissan", Anio = "2020" });
            _autos.Add(new Autos() { Modelo = "Xtrail", Marca = "Nissan", Anio = "2020" });
            AgregarCommand = new Command(async () => { Nuevo(); });
        }

        async void Nuevo()
        {
            autosPage = new AutosPage();
            AutosPageVM autosPageMV = new AutosPageVM(OBAutos);
            autosPage.BindingContext = autosPageMV;
            await Application.Current.MainPage.Navigation.PushModalAsync(autosPage);
        }

        public ObservableCollection<Autos> OBAutos
        {
            get
            {
                return _autos;
            }
            set
            {
                _autos = value;
                OnPropertyChanged();
            }
        }

        private string _packageName;

        public string PackageName
        {
            get { return _packageName; }
            set { _packageName = value; OnPropertyChanged(); }
        }
    }
}
