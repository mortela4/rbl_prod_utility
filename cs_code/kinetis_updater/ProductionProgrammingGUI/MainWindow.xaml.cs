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
        //private ToplevelViewModel TVM = new ToplevelViewModel();    // TODO: remove - no point in using this, as it is encapsulated in 'DeviceManagerViewModel'!!
        private DeviceManagerViewModel DVM = new DeviceManagerViewModel();

        public MainWindow()
        {
            // Init
            //TVM.devVM = new DeviceManagerViewModel();
            //TVM.imgFileVM = new ImageFileManagerViewModel();
            //TVM.imgFileVM = TVM.devVM.ImageFileManager;
            //TVM.updVM = TVM.devVM.CurrentDevice.UpdaterModel;   // NOTE: UpdaterModel=null at this point - cannot use!
            //
            InitializeComponent();
            this.DataContext = DVM;
        }

       private void ConnectToBootloader(object sender, RoutedEventArgs e)
        {
            // IF-clause should NEVER be taken, but - we must ensure NULL-handling is in place.
            if (DVM.CurrentDevice.IsNull )
            {
                // Emit warning - take corrective actions
                Console.WriteLine("ERROR: no device chosen - cannot use updater object!");
                //
                return;
            }
            //TVM.updVM = new UpdaterViewModel(TVM.devVM.CurrentDevice);

            // Now is the time to run "Connect"-button handler:
            //TVM.updVM.ConnectButtonHandler();
            //if (TVM.devVM.CurrentDevice.IsSerial && !TVM.updVM.IsConnectedTimer.IsEnabled)
            //    TVM.updVM.IsConnectedTimer.Start();
            //if (TVM.devVM.CurrentDevice.IsUsbHid)
            //    TVM.updVM.AutoConnectUSBDevice = true;
            //TVM.updVM.Ping();

            // Update property (TODO: assess - no point in checking IsConnected again here?):
            if ( DVM.ImageFileManager.CurrentImageFile.IsEnabled && DVM.CurrentDevice.UpdaterModel.IsConnected )
            {
                DVM.CurrentDevice.UpdaterModel.ImageFileModel = DVM.ImageFileManager.CurrentImageFile;
                DVM.UpdateAllowed = true;
            }
        }
    }
}
