using System;
using Foundation;
using UnosquareApp.iOS;
using UnosquareApp.Services;
using Xamarin.Forms;

[assembly: Dependency(typeof(PackageService))]
namespace UnosquareApp.iOS
{
    public class PackageService : IPackageService
    {

        public string GetPackageName()
        {
            try
            {
                return NSBundle.MainBundle.BundleIdentifier;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return string.Empty;
            }
        }
    }
}
