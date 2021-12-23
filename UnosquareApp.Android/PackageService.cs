using System;
using UnosquareApp.Services;
using Xamarin.Forms;

[assembly: Dependency(typeof(UnosquareApp.Droid.PackageService))]
namespace UnosquareApp.Droid
{
    public class PackageService : IPackageService
    {
        public string GetPackageName()
        {
            try
            {
                
                return MainActivity.PackageName;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return string.Empty;
            }
        }
    }
}
