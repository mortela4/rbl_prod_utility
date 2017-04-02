﻿/*
 * Copyright (c) 2014, Freescale Semiconductor, Inc.
 * All rights reserved.
 *
 * Redistribution and use in source and binary forms, with or without modification,
 * are permitted provided that the following conditions are met:
 *
 * o Redistributions of source code must retain the above copyright notice, this list
 *   of conditions and the following disclaimer.
 *
 * o Redistributions in binary form must reproduce the above copyright notice, this
 *   list of conditions and the following disclaimer in the documentation and/or
 *   other materials provided with the distribution.
 *
 * o Neither the name of Freescale Semiconductor, Inc. nor the names of its
 *   contributors may be used to endorse or promote products derived from this
 *   software without specific prior written permission.
 *
 * THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND
 * ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED
 * WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE
 * DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT HOLDER OR CONTRIBUTORS BE LIABLE FOR
 * ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES
 * (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES;
 * LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON
 * ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT
 * (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS
 * SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
 */

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

using KinetisUpdater.ViewModel;

namespace KinetisUpdater
{
    /// <summary>
    /// Interaction logic for HomePage.xaml
    /// </summary>
    public partial class HomePage : Page
    {
        private DevicePage _DevicePage;
        private ImagePage _ImagePage;
        private UpdatePage _UpdatePage;

        public HomePage(DeviceManagerViewModel deviceManagerModel)
        {
            InitializeComponent();
            this.DataContext = deviceManagerModel;
        }

        private void ConfigDeviceButton_Click(object sender, RoutedEventArgs e)
        {
            if (_DevicePage == null)
                _DevicePage = new DevicePage((DeviceManagerViewModel)this.DataContext);

            this.NavigationService.Navigate(_DevicePage);
        }

        private void ConfigImageButton_Click(object sender, RoutedEventArgs e)
        {
            if (_ImagePage == null)
                _ImagePage = new ImagePage(((DeviceManagerViewModel)this.DataContext).ImageFileManager);

            this.NavigationService.Navigate(_ImagePage);
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            var devManager = (DeviceManagerViewModel)this.DataContext;
            var updaterModel = devManager.CurrentDevice.UpdaterModel;
            updaterModel.ImageFileModel = devManager.ImageFileManager.CurrentImageFile;

            _UpdatePage = new UpdatePage(updaterModel);
            
            this.NavigationService.Navigate(_UpdatePage);
        }

        private void CloseCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            Application.Current.MainWindow.Close();
        }
    }
}