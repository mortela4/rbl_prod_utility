﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//
using KinetisUpdater.ViewModel;

namespace ProductionProgrammingGUI
{
    class ToplevelViewModel : ObservableObject
        {
            public ToplevelViewModel() { }

            ~ToplevelViewModel() { }

            private DeviceViewModel _devVM = null;
            public DeviceViewModel devVM
            {
                get
                {
                    return _devVM;
                }
                set
                {
                    _devVM = value;
                    RaisePropertyChangedEvent("devVM");
                }
            }
            private ImageFileManagerViewModel _imgFileVM = null;
            public ImageFileManagerViewModel imgFileVM
            {
                get
                {
                    return _imgFileVM;
                }
                set
                {
                _imgFileVM = value;
                    RaisePropertyChangedEvent("imgFileVM");
                }
            }
            private UpdaterViewModel _updVM = null;
            public UpdaterViewModel updVM
            {
                get
                {
                    return _updVM;
                }
                set
                {
                    _updVM = value;
                    RaisePropertyChangedEvent("updVM");
                }
            }
        }

}