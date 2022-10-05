using BuggyMaui.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using MetroLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuggyMaui.ViewModels
{
    [QueryProperty(nameof(Selection), nameof(Selection))]
    public partial class ReviewViewModel : ObservableObject
    {
        #region Private fields

        IConnectivity connectivity;

        private ILogger _logger = InternalLogger.Current;

        private Person selection;

        #endregion

        #region Public properties

        public Person Selection
        {
            get => selection;
            set => SetProperty(ref selection, value);
        }

        #endregion

        #region View model constructor

        public ReviewViewModel(IConnectivity connectivity)
        {
            this.connectivity = connectivity;
            _logger.Info("[ReviewViewModel]: constructor initialized");
        }

        #endregion
    }
}
