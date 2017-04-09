using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
//
using KinetisUpdater.ViewModel;


namespace ProductionProgrammingGUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ToplevelViewModel TVM = new ToplevelViewModel();

        public MainWindow()
        {
            // Init
            TVM.devVM = new DeviceManagerViewModel();
            TVM.imgFileVM = new ImageFileManagerViewModel();
            //TVM.updVM = new UpdaterViewModel(null);           // TODO: construct w. device as argument!
            //
            InitializeComponent();
            this.DataContext = TVM;
        }

        private void ConnectToBootloader(object sender, RoutedEventArgs e)
        {
            // IF-clause should NEVER be taken, but - we must ensure NULL-handling is in place.
            if ( TVM.devVM.CurrentDevice.IsNull )
            {
                // Emit warning - take corrective actions
                Console.WriteLine("ERROR: no device chosen - cannot create updater object!");
                //
                return;
            }
            TVM.updVM = new UpdaterViewModel(TVM.devVM.CurrentDevice);

            // Now is the time to run "Connect"-button handler:
            //TVM.updVM.ConnectButtonHandler();
            if (TVM.devVM.CurrentDevice.IsSerial && !TVM.updVM.IsConnectedTimer.IsEnabled)
                TVM.updVM.IsConnectedTimer.Start();
            if (TVM.devVM.CurrentDevice.IsUsbHid)
                TVM.updVM.AutoConnectUSBDevice = true;
            TVM.updVM.Ping();
        }
    }
}
