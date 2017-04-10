using System;
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

        #region Properties

        #region ViewModel-properties
        /// <summary>
        /// ViewModels wrapped by TVM.
        /// </summary>
        private DeviceManagerViewModel _devVM = null;
            public DeviceManagerViewModel devVM
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

        #region Other properties (= state properties)

        private bool _updateAllowed = false;
            public bool updateAllowed
            {
                get
                {
                    return _updateAllowed;
                }
                set
                {
                    _updateAllowed = value; RaisePropertyChangedEvent("updateAllowed");
                }
            }

        #endregion

        #endregion

        #endregion
    }

}
