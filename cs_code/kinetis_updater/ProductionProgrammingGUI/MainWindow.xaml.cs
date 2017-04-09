﻿using System;
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

        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            // pass ...
        }
    }
}
