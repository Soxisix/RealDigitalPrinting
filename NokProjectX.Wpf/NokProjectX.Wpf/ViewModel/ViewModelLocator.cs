/*
  In App.xaml:
  <Application.Resources>
      <vm:ViewModelLocator xmlns:vm="clr-namespace:NokProjectX.Wpf"
                           x:Key="Locator" />
  </Application.Resources>
  
  In the View:
  DataContext="{Binding Source={StaticResource Locator}, Path=ViewModelName}"

  You can also use Blend to do all this with the tool's support.
  See http://www.galasoft.ch/mvvm
*/

using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;
using NokProjectX.Wpf.Context;
using NokProjectX.Wpf.ViewModel.Inventory;

namespace NokProjectX.Wpf.ViewModel
{
    /// <summary>
    /// This class contains static references to all the view models in the
    /// application and provides an entry point for the bindings.
    /// </summary>
    public class ViewModelLocator
    {
        /// <summary>
        /// Initializes a new instance of the ViewModelLocator class.
        /// </summary>
        
         static ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            if (ViewModelBase.IsInDesignModeStatic)
            {
                // Create design time view services and models
                SimpleIoc.Default.Register<YumiContext>();
            }
            else

            {
                // Create run time view services and models
                SimpleIoc.Default.Register<YumiContext>();
            }
            
        
        SimpleIoc.Default.Register<MainViewModel>();
        SimpleIoc.Default.Register<SideBarViewModel>();
        SimpleIoc.Default.Register<TopBarViewModel>();
        SimpleIoc.Default.Register<InventoryViewModel>();
            
        }

        public MainViewModel Main
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MainViewModel>();
            }
        }
        public SideBarViewModel SideBar
        {
            get
            {
                return ServiceLocator.Current.GetInstance<SideBarViewModel>();
            }
        }
        public TopBarViewModel TopBar
        {
            get
            {
                return ServiceLocator.Current.GetInstance<TopBarViewModel>();
            }
        }
        public InventoryViewModel Inventory
        {
            get
            {
                return ServiceLocator.Current.GetInstance<InventoryViewModel>();
            }
        }

        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }
    }
}